using System;
 using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Rock_Paper_Scissors
{
    public partial class Form2 : Form
    {
        string PlayerName;
        public Form2(string Name)
        {
            InitializeComponent();
            Disable();
            PlayerName = Name;
            
        }

        private int Counter = 0;
        private int NumberOfRounds = 0;
        private int DrawTimes = 0;
        private int ComputerTimes = 0;
        private int PlayerTimes = 0;
        private string Winer = "";
        private string ComputerRoundChoice = "";
        string RoundWiner = "";


        private Form4 form4 = new Form4(); // Or use a shared instance if it's already open
        private Form3 form3 = new Form3(); // Or use a shared instance if it's already open

        string GetComputerChoice()
        {
            Random rand = new Random();
            int ComputerChoice = rand.Next(1, 4);

            if (ComputerChoice == 1)
            {
                pbCom.Image = Properties.Resources.Rock;
                ComputerRoundChoice = "Rock";
                return ComputerRoundChoice;
            }
            else if (ComputerChoice == 2)
            {
                pbCom.Image = Properties.Resources.Paper1;
                ComputerRoundChoice= "Paper";
                return ComputerRoundChoice;
            }
            else
            {
                pbCom.Image = Properties.Resources.Scissors;
                ComputerRoundChoice = "Scissors";
                return ComputerRoundChoice; 
            }
        }

        string WhoWon(string PlayerChoice, string ComputerChoice)
        {

            if (ComputerChoice.ToLower() == PlayerChoice.ToString().ToLower())
            {
                DrawTimes++;
                RoundWiner = "It's Draw";
            }

            else if (ComputerChoice.ToLower() == "rock" && PlayerChoice.ToString().ToLower() == "scissors")
            {
                ComputerTimes++;
                RoundWiner = "Computer";
            }
            else if (ComputerChoice.ToLower() == "paper" && PlayerChoice.ToString().ToLower() == "rock")
            {
                ComputerTimes++;
                RoundWiner = "Computer";
            }
            else if (ComputerChoice.ToLower() == "scissors" && PlayerChoice.ToString().ToLower() == "paper")
            {
                ComputerTimes++;
                RoundWiner = "Computer";
            }

            else if (PlayerChoice.ToLower() == "rock" && ComputerChoice.ToString().ToLower() == "scissors")
            {
                PlayerTimes++;
                RoundWiner = "Player1";
            }
            else if (PlayerChoice.ToLower() == "paper" && ComputerChoice.ToString().ToLower() == "rock")
            {
                PlayerTimes++;
                RoundWiner = "Player1";
            }
            else if (PlayerChoice.ToLower() == "scissors" && ComputerChoice.ToString().ToLower() == "paper")
            {
                PlayerTimes++;
                RoundWiner = "Player1";
            }
            else
            {
                RoundWiner = "UnKnown";
            }

            return RoundWiner;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
         
            comboBox1.SelectedIndex = 0;
            StopTimer();
            NumberOfRounds = 0;
            DrawTimes = 0;
            ComputerTimes = 0;
            PlayerTimes = 0;
            Enable();

 
            btnStart.Visible = false;
            btnSeeResult.Visible = false;
            contextMenuStrip1.Visible = false;

            form4.Clear();
        }

        void Disable()
        {
             pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;     

            btnStart.Visible = false;
            btnSeeResult.Visible = false;

            contextMenuStrip1.Visible = false;
        }   
        
        void Enable()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;

            lblComputerWin.Text = ComputerTimes.ToString();
            lblNameWin.Text = PlayerTimes.ToString();
            lblDrawTimes.Text = DrawTimes.ToString();
            lblRoundNum .Text = NumberOfRounds.ToString();
             
            comboBox1.Enabled = true;
            btnStart.Visible = true ;
         }

        string WhoWonTheGame(int ComputerWinTime, int PlayerWinTime )
        {
            if (ComputerWinTime < PlayerTimes)
            {
                Winer = "Player1 Is The Winer";
                return Winer;
            }

            else if (ComputerWinTime > PlayerTimes)
            {
                Winer = "Computer Is The Winer";
                return Winer;
            }
            else
            {
                Winer = "The Result Is Draw";
                return Winer;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (NumberOfRounds < comboBox1.SelectedIndex)
            {
                lblRoundNum.Text = (NumberOfRounds + 1).ToString();
                pbPlayer.Image = Properties.Resources.Rock;


                RoundWiner = WhoWon(pictureBox1.Tag.ToString(), GetComputerChoice());

                lblComputerWin.Text = ComputerTimes.ToString();
                lblNameWin.Text = PlayerTimes.ToString();
                lblDrawTimes.Text = DrawTimes.ToString();
                form4.AddItemToListView2((NumberOfRounds+1).ToString(), RoundWiner, pictureBox1.Tag.ToString(), ComputerRoundChoice);
 

                NumberOfRounds++;
                MessageBox.Show("Round " + (NumberOfRounds).ToString() + " Winner Is " + RoundWiner, "Winer", MessageBoxButtons.OK, MessageBoxIcon.Stop);

           

            }
            else
            {
                if (ComputerTimes == 0 && PlayerTimes == 0 && DrawTimes == 0)
                {
                    return;
                }
                else
                {
                    contextMenuStrip1.Visible = true;
                    StopTimer();
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;

                    string Winer = WhoWonTheGame(ComputerTimes, PlayerTimes);
                    MessageBox.Show("Game Over, "+Winer, "Winer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSeeResult.Visible = true;
                    btnSeeResult.Enabled = true;

                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {        

            if (NumberOfRounds < comboBox1.SelectedIndex)
            {
                lblRoundNum.Text = (NumberOfRounds + 1).ToString();
                pbPlayer.Image = Properties.Resources.Paper1;



                RoundWiner = WhoWon(pictureBox2.Tag.ToString(), GetComputerChoice());

                lblComputerWin.Text = ComputerTimes.ToString();
                lblNameWin.Text = PlayerTimes.ToString();
                lblDrawTimes.Text = DrawTimes.ToString();

                form4.AddItemToListView2((NumberOfRounds + 1).ToString(),  RoundWiner, pictureBox2.Tag.ToString(), ComputerRoundChoice);

                NumberOfRounds++;
                MessageBox.Show("Round " + (NumberOfRounds).ToString() + " Winner Is " + RoundWiner, "Winer", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
            else
            {
                if (ComputerTimes == 0 && PlayerTimes == 0 && DrawTimes == 0)
                {
                    return;
                }
                else
                {
                     contextMenuStrip1.Visible = true;
                    StopTimer();

                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    string Winer = WhoWonTheGame(ComputerTimes, PlayerTimes);
                    MessageBox.Show("Game Over, "+Winer, "Winer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSeeResult.Visible = true;
                    btnSeeResult.Enabled = true;


                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           

            if (NumberOfRounds < comboBox1.SelectedIndex)
            {
                lblRoundNum.Text = (NumberOfRounds + 1).ToString();
                pbPlayer.Image = Properties.Resources.Scissors;

                RoundWiner = WhoWon(pictureBox3.Tag.ToString(), GetComputerChoice());

                lblComputerWin.Text = ComputerTimes.ToString();
                lblNameWin.Text = PlayerTimes.ToString();
                lblDrawTimes.Text = DrawTimes.ToString();

                form4.AddItemToListView2((NumberOfRounds + 1).ToString(), RoundWiner, pictureBox3.Tag.ToString(), ComputerRoundChoice);
                NumberOfRounds++;

                MessageBox.Show("Round "+(NumberOfRounds).ToString() + " Winner Is " + RoundWiner , "Winer", MessageBoxButtons.OK, MessageBoxIcon.Stop );
                           
             }
            else
            {
                if (ComputerTimes == 0 && PlayerTimes == 0 && DrawTimes == 0)
                {
                    return;
                }
                else
                {
                    btnSeeResult.Enabled = true;
                    StopTimer();
                    contextMenuStrip1.Visible = true;

                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;

                    WhoWonTheGame(ComputerTimes, PlayerTimes);
                    MessageBox.Show("Game Over, "+Winer, "Winer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSeeResult.Visible = true;
                    btnSeeResult.Enabled = true;


                }
            }
        }      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enable();
            lblOutOf.Text = "/  " +(comboBox1.SelectedIndex).ToString();
            comboBox1.Enabled = false;
            btnSeeResult.Visible = false;

            StartTimer();
        }

        private void btnSeeResult_Click(object sender, EventArgs e)
        {
             form4.AddItemToListView(NumberOfRounds.ToString(), PlayerTimes.ToString(), ComputerTimes.ToString(),
                DrawTimes.ToString(), Winer, lblTime.Text.ToString());

            form4.ShowDialog();
        }

        private void hshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form4.AddItemToListView(" ", " ", " ", " ", " ", " ");
              

            form4.ShowDialog();
        }

        private void shhsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(sender, e);
        }
        
        private void bndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form4.AddItemToListView(" ", " ", " ", " ", " ", " ");

            form4.ShowDialog();
        }

        void StartTimer()
        {
            Counter = 0;

            timer1.Enabled = true;
        }
        
        void StopTimer()
        {
            timer1.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Counter++;
            lblTime.Text = Counter.ToString();  
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblName.Text = "Player 1";
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            lblName.Text = PlayerName.ToUpper();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
