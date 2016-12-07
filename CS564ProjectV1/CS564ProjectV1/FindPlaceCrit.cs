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
    public partial class FindPlaceCrit : Form
    {
        public FindPlaceCrit()
        {
            InitializeComponent();
            lblWelcomeUser.Text = "Welcome " + Main.name + " !";

            DataSet ds = new DataSet();
            string getIndustryTypes = "SELECT DISTINCT type FROM dbo.Industry WHERE type <>'Total'";
            SqlDataAdapter sda = new SqlDataAdapter(getIndustryTypes, Main.connection);

            sda.Fill(ds);
            cboIndustry1.DataSource = ds.Tables[0];
            cboIndustry1.DisplayMember = ds.Tables[0].Columns[0].ToString();

            cboIndustry2.DataSource = ds.Tables[0];
            cboIndustry2.DisplayMember = ds.Tables[0].Columns[0].ToString();

            cboIndustry3.DataSource = ds.Tables[0];
            cboIndustry3.DisplayMember = ds.Tables[0].Columns[0].ToString();

            cboIndustry4.DataSource = ds.Tables[0];
            cboIndustry4.DisplayMember = ds.Tables[0].Columns[0].ToString();

            cboIndustry5.DataSource = ds.Tables[0];
            cboIndustry5.DisplayMember = ds.Tables[0].Columns[0].ToString();
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
        private void lblFindPlaceCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by City form
            this.Close();
            FindPlaceCity findPlaceCity = new FindPlaceCity();
            findPlaceCity.Show();
        }

        private void cboCriteria1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria1.Text.Equals("Name") || cboCriteria1.Text.Equals("State"))
            {
                cboCrit1Bool.Visible = false;
                cboCrit1SpecialBool.Visible = true;
            }
            else
            {
                cboCrit1Bool.Visible = true;
                cboCrit1SpecialBool.Visible = false;
            }
            if (cboCriteria1.Text.Equals("Industry Participation Rate"))
            {
                cboIndustry1.Visible = true;
            }
            else
            {
                cboIndustry1.Visible = false;
            }
        }

        private void cboCriteria2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria2.Text.Equals("Name") || cboCriteria2.Text.Equals("State"))
            {
                cboCrit2Bool.Visible = false;
                cboCrit2SpecialBool.Visible = true;
            }
            else
            {
                cboCrit2Bool.Visible = true;
                cboCrit2SpecialBool.Visible = false;
            }

            if (cboCriteria2.Text.Equals("Industry Participation Rate"))
            {
                cboIndustry2.Visible = true;
            }
            else
            {
                cboIndustry2.Visible = false;
            }
        }

        private void cboCriteria3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria3.Text.Equals("Industry Participation Rate"))
            {
                cboIndustry3.Visible = true;
            }
            else
            {
                cboIndustry3.Visible = false;
            }
        }

        private void cboCriteria4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria4.Text.Equals("Industry Participation Rate"))
            {
                cboIndustry4.Visible = true;
            }
            else
            {
                cboIndustry4.Visible = false;
            }
        }

        private void cboCriteria5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria5.Text.Equals("Industry Participation Rate"))
            {
                cboIndustry5.Visible = true;
            }
            else
            {
                cboIndustry5.Visible = false;
            }
        }
    }
    }
