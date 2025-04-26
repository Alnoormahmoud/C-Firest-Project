using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rock_Paper_Scissors
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            lvMy.Items.Clear();
            lvMy2.Items.Clear();
        }

        public void AddItemToListView(string NumberOfRounds, string Player1Wins, string ComputerWins, string DrawTimes, string FinalWinner, string Timer)
        {
            ListViewItem item = new ListViewItem(NumberOfRounds);
            item.SubItems.Add(Player1Wins);
            item.SubItems.Add(ComputerWins);
            item.SubItems.Add(DrawTimes);
            item.SubItems.Add(FinalWinner);
            item.SubItems.Add(Timer);
            lvMy.Items.Add(item);
        }

        public void AddItemToListView2(string NumberOfRound,string RoundWinner, string Player1Choices, string ComputrChoice)
        {
            ListViewItem item2 = new ListViewItem(NumberOfRound);
            item2.SubItems.Add(RoundWinner);
            item2.SubItems.Add(Player1Choices);
            item2.SubItems.Add(ComputrChoice);

            lvMy2.Items.Add(item2);
        }

        private void lvMy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lvMy2.View = View.LargeIcon;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lvMy2.View = View.SmallIcon ;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lvMy2.View = View.Details;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lvMy2.View = View.Tile;

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            lvMy2.View = View.List;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
