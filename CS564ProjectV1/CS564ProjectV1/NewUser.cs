﻿using System;
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

        private void cmdRegister_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("CheckPassword", Main.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login",txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            }
            
            SqlCommand verifyLogin = new SqlCommand("CheckPassword", Main.connection);
            verifyLogin.CommandType = CommandType.StoredProcedure;
            verifyLogin.Parameters.AddWithValue("@login",txtUserName.Text);
            verifyLogin.Parameters.AddWithValue("@password", txtPassword.Text);

            bool loginVerified = ((int)verifyLogin.ExecuteScalar() == 0 ? false : true);

            if (loginVerified)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                Main.login = txtUserName.Text;
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
}
