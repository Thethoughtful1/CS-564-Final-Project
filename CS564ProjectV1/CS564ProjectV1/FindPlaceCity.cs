using System;
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
    public partial class FindPlaceCity : Form
    {
        public FindPlaceCity()
        {
            InitializeComponent();
            lblWelcomeUser.Text = "Welcome " + Main.name + " !";
        }


        private void lblReviewNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Review Notes form
            this.Close();
            ReviewNotes reviewNotes = new ReviewNotes();
            reviewNotes.Show();
        }

        private void lblEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Edit Profile screen
            this.Close();
            UserProfile userProfile = new UserProfile();
            userProfile.Show();
        }
        private void lblFindPlaceCrit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by Criteria form
            this.Close();
            FindPlaceCrit findPlaceCrit = new FindPlaceCrit();
            findPlaceCrit.Show();
        }
        
    }
}
