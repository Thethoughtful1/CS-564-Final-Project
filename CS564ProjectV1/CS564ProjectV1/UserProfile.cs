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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
            lblLogin.Text = Main.login;
            lblWelcomeUser.Text = "Welcome " + Main.name + "!";
        }

        private void lblReviewNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Review Notes form
            this.Close();
            ReviewNotes reviewNotes = new ReviewNotes();
            reviewNotes.Show();
        }

        private void lblFindPlaceCrit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by Criteria form
            this.Close();
            FindPlaceCrit findPlaceCrit = new FindPlaceCrit();
            findPlaceCrit.Show();
        }

        private void lblFindPlaceCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by City form
            this.Close();
            FindPlaceCity findPlaceCity = new FindPlaceCity();
            findPlaceCity.Show();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {

<<<<<<< HEAD
            string login = Main.login;
=======
            string login = txtUserName.Text;
>>>>>>> refs/remotes/origin/master
            string password = txtPassword.Text;
            string firstName = txtFnam.Text;
            string lastName = textBox2.Text;


<<<<<<< HEAD
=======
            if (password == "" || password.Length > 500)
            {
                MessageBox.Show("Please enter a password of up to 500 characters.");
            }
            else
            {
>>>>>>> refs/remotes/origin/master
                SqlCommand cmd = new SqlCommand("UpdateUser", Main.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
<<<<<<< HEAD
                cmd.ExecuteScalar();
                Main.name = (firstName == "" ? "Dude" : firstName);
                lblWelcomeUser.Text = "Welcome " + Main.name + "!";
                this.Refresh();
=======
                Main.name = (firstName == "" ? "Dude" : firstName);
                lblUserName.Text = Main.name;
                this.Refresh();
            }
>>>>>>> refs/remotes/origin/master
        }
    }
}
