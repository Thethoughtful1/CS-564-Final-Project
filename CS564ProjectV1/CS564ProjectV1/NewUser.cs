using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS564ProjectV1
{
    public partial class frmNewUser : Form
    {
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void lblRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *GWL hop from the new user screen to the login screen
            this.Close();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
        }


        private void cmdRegister_Click_1(object sender, EventArgs e)
        {
            string login = txtUserName.Text;
            string password = txtPassword.Text;
            string firstName = txtFName.Text;
            string lastName = txtFName.Text;

            SqlCommand verifyLogin = new SqlCommand("CheckLogin", Main.connection);
            verifyLogin.CommandType = CommandType.StoredProcedure;
            verifyLogin.Parameters.AddWithValue("@login", login);

            bool loginVerified = ((int)verifyLogin.ExecuteScalar() == 0 ? false : true);

            if (login == "" || login.Length > 50)
            {
                MessageBox.Show("Please enter a user name of up to 50 characters.");
            }
            else if (password == "" || password.Length > 500)
            {
                MessageBox.Show("Please enter a password of up to 500 characters.");
            }
            else if (!loginVerified)
            {
                MessageBox.Show("Your login has been taken, please try another.");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("CreateUser", Main.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.ExecuteScalar();
                this.Hide();
                Main.login = login;
                Main.name = (firstName == "" ? "Dude" : firstName);
                UserProfile userProfile = new UserProfile();
                userProfile.Show();
            }
        }
    }
}
