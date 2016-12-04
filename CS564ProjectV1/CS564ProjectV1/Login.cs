using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CS564ProjectV1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        // *GWL hop from the login screen to the new user screen
        private void lblRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frmNewUser newUserForm = new frmNewUser();
            newUserForm.Show();                      
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("CheckPassword", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login",txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            bool loginVerified = ((int)cmd.ExecuteScalar() == 0 ? false : true);

            if (loginVerified)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                Main.login = txtUserName.Text;
                
                SqlCommand getName = new SqlCommand("GetName", Main.connection);
                getName.CommandType = CommandType.StoredProcedure;
                getName.Parameters.AddWithValue("@login",txtUserName.Text);
                Main.name = (string)getName.ExecuteScalar();

                UserProfile userProfile = new UserProfile();
                userProfile.Show();
            }
            else
            {
                MessageBox.Show("User Name or Password is incorrect");
            }
        }
    }
}
