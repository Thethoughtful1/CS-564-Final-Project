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
    public partial class Results : Form
    {
        public Results()
        {
            
            InitializeComponent();
            lblWelcomeUser.Text = "Welcome " + Main.name + " !";
            resultPanel.Controls.Clear();
            int pointX = 0;
            int pointY = 10;

            SqlCommand cmd = new SqlCommand(Main.sql, Main.connection);
            SqlDataReader resultReader = cmd.ExecuteReader();
            while (resultReader.Read())
            {
                int placeId = Convert.ToInt32(resultReader[0]);
                String placeName = resultReader[1].ToString();
                String stateName = resultReader[2].ToString();

                LinkLabel l = new LinkLabel();
                l.Width = 200;
                l.Height = 20;
                l.Text = placeName+" ,"+stateName+" ("+ placeId.ToString() + ")";
                l.Location = new Point(pointX, pointY);
                l.Tag = placeId;
                l.LinkClicked += resultLinkClick;
                resultPanel.Controls.Add(l);

                Button b = new Button();
                b.Width = 250;
                b.Height = 20;
                b.Text = "Add to "+ placeName + " to my Compare List";
                b.Location = new Point(210, pointY-5);
                b.Tag = placeId;
                b.Click += buttonClick;
                resultPanel.Controls.Add(b);

                pointY += l.Height;
            }
            resultReader.Close();
        }

        private void lblEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Edit Profile screen
            this.Close();
            UserProfile userProfile = new UserProfile();
            userProfile.Show();
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

        private void resultLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            var linkLabel = (LinkLabel)sender;
            Main.placeId = (int)linkLabel.Tag;
            PlaceInfo placeInfo = new PlaceInfo();
            placeInfo.Show();
        }
        
        private void buttonClick(object sender, EventArgs e)
        {
            var b = (Button)sender;
            int placeId = (int)b.Tag;
            string login = Main.login;
            bool addLine = false;

            SqlCommand check = new SqlCommand("CanAddToCompareList", Main.connection);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.AddWithValue("@login", login);
            check.Parameters.AddWithValue("@placeId", placeId);

            addLine = ((int)check.ExecuteScalar() == 0 ? false : true);

            if (addLine)
            {
                SqlCommand add = new SqlCommand("AddToCompareList", Main.connection);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@login", login);
                add.Parameters.AddWithValue("@placeId", placeId);
                add.ExecuteNonQuery();
            }
        }
    }
}
