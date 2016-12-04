﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS564ProjectV1
{
    public partial class ReviewNotes : Form
    {
        public ReviewNotes()
        {
            InitializeComponent();
        }

        private void lblEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Edit Profile screen
            this.Close();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
        }

        private void lblFindPlaceCrit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by Criteria form
            this.Close();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
        }

        private void lblFindPlaceCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *GWL hop from the new user screen to the login screen
            this.Close();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
        }
    }
}