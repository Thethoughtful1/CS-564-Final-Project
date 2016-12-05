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
    

    public partial class ReviewNotes : Form
    {


        public ReviewNotes()
        {
            InitializeComponent();

            lblUserName.Controls.Clear();
            lblUserName = Main.name();

            notePanel.Controls.Clear();
            int pointX = 0;
            int pointY = 10;

            SqlCommand cmd = new SqlCommand("userNotes", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login", Main.login);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                String content = reader[0].ToString();
                String placeName = reader[1].ToString();
                String placeId = reader[2].ToString();

                LinkLabel l = new LinkLabel();
                l.Text = placeName;
                l.Location = new Point(pointX, pointY);
                notePanel.Controls.Add(l);
                pointY += l.Height;

                TextBox t = new TextBox();
                t.Multiline = true;
                t.ScrollBars = ScrollBars.Vertical;
                t.WordWrap = true;
                t.Width = 450;
                t.Height = 150;
                t.Text = content;
                t.Location = new Point(pointX, pointY);
                notePanel.Controls.Add(t);
                notePanel.Show();
                pointY += t.Height + 20;

            }

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

        private void lblFindPlaceCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by City form
            this.Close();
            FindPlaceCity findPlaceCity = new FindPlaceCity();
            findPlaceCity.Show();
        }
    }
}
