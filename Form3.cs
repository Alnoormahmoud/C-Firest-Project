using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rock_Paper_Scissors
{
    public partial class Form3 : Form
    {
        public string SetName(string PlayerName)
        {
            return PlayerName;
        }
        public Form3()
        {
            InitializeComponent();
            txtName.Focus();

        }

         private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text =="")
            {
                MessageBox.Show ("Can't Start Game Enter Your Name First ","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string playerName = txtName.Text;
            Form frm = new Form2(playerName);

            // Open the next form and pass the name
       
 
            frm.ShowDialog();

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Name Is Empty");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(txtName, "");

            }
        }

        private void Form3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbFriend_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFriend.Checked)
            {
                txtPlayer2.ReadOnly = false;
                txtPlayer2.Text = "";
            }
            else
            {
                txtPlayer2.ReadOnly = true;
                txtPlayer2.Text = "Computer";
            }
        }

        private void gpPlayWith_Enter(object sender, EventArgs e)
        {
         
        }
    }
}
