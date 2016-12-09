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
using System.Diagnostics;

namespace CS564ProjectV1
{
    public partial class PlaceInfo : Form
    {
        public double povertyRate = 0.0;
        public double laborRate = 0.0;
        public string year;
        public PlaceInfo(string year = "Max")
        {
            InitializeComponent();
            this.year = year;
            cboYear.SelectedItem = year;

            Debug.WriteLine("XXX \n\n\n\nI'm having a good time\n\n\n\nXXX");
            int placeId = Main.placeId;
            
            lblWelcomeUser.Text = "Welcome " + Main.name + " !";

            drawForm(placeId);

            //Return to search results button is available if we have a recent search query
            string sql = Main.sql;

            if (!String.IsNullOrEmpty(sql))
            {
                btnReturnToResults.Visible = true;
                btnReturnToResults.Enabled = true;
            }
            else
            {
                btnReturnToResults.Visible = false;
                btnReturnToResults.Enabled = false;
            }
            
        }

        private void drawForm(int placeId)
        {
            getPlaceName(placeId);
            getStateData(placeId);
            getCurrentPopulation(placeId);
            getPopulationChange(placeId);
            getEconomicData(placeId);
            getPovertyChange(placeId);
            getAvgIncomeChange(placeId);
            getLaborChange(placeId);
            getTopIndustries(placeId);
            getMedianAge(placeId);
            getGenderRatio(placeId);
            getPlaceNotes(placeId);
            getUserNote(placeId);
        }

        private void getPlaceName(int placeId)
        {
            //get the place name -- inherited from the search results
            SqlCommand cmdGetPlaceName = new SqlCommand("GetPlaceName", Main.connection);
            cmdGetPlaceName.CommandType = CommandType.StoredProcedure;
            cmdGetPlaceName.Parameters.AddWithValue("@placeId", placeId);
            string placeName = (string)cmdGetPlaceName.ExecuteScalar();
            lblPlaceName.Text = placeName;
            cmdGetPlaceName.Dispose();
        }
        
        private void getStateData(int placeId)
        {
            //get the place's state data
            SqlCommand cmdStateInfo = new SqlCommand("GetStateInfo", Main.connection);
            cmdStateInfo.CommandType = CommandType.StoredProcedure;
            cmdStateInfo.Parameters.AddWithValue("@placeId", placeId);
            if (!year.Equals("Max"))
            {
                cmdStateInfo.Parameters.AddWithValue("@year", year);
            }

            //read the query result
            SqlDataReader reader = cmdStateInfo.ExecuteReader();

            //get index of query result
            var indexOfName = reader.GetOrdinal("name");
            var indexOfAvgIncome = reader.GetOrdinal("avgIncome");
            var indexOfAvgEdu = reader.GetOrdinal("avgEdu");
            var indexOfAvgNatRec = reader.GetOrdinal("avgNatRec");
            var indexOfAvgWelfare = reader.GetOrdinal("avgWelfare");
            var indexOfAvgPop = reader.GetOrdinal("avgPop");

            while (reader.Read())
            {
                string stateName = (string)reader.GetValue(indexOfName);
                double avgIncome = (double)reader.GetValue(indexOfAvgIncome);
                double avgEdu = (double)reader.GetValue(indexOfAvgEdu);
                double avgNatRec = (double)reader.GetValue(indexOfAvgNatRec);
                double avgWelfare = (double)reader.GetValue(indexOfAvgWelfare);
                long avgPop = (long)reader.GetValue(indexOfAvgPop);

                grpStateInfo.Text = stateName + " Info: ";
                lblAvgIncome.Text = avgIncome.ToString("C0");
                lblAvgEdu.Text = avgEdu.ToString("C0");
                lblAvgNatRec.Text = avgNatRec.ToString("C0");
                lblAvgWelfare.Text = avgWelfare.ToString("C0");
                lblAvgPop.Text = String.Format("{0:#,##0}", avgPop);
            }

            reader.Close();
        }

        private void getCurrentPopulation(int placeId)
        {
            // Get the place current popluation
            SqlCommand cmdGetPopulation = new SqlCommand("GetPlacePopulation", Main.connection);
            cmdGetPopulation.CommandType = CommandType.StoredProcedure;
            cmdGetPopulation.Parameters.AddWithValue("@placeId", placeId);
            if (!year.Equals("Max"))
            {
                cmdGetPopulation.Parameters.AddWithValue("@year", year);
                
            }
            string placePopulation = String.Format("{0:#,##0}", (long)cmdGetPopulation.ExecuteScalar());
            lblCurPop.Text = placePopulation;
            cmdGetPopulation.Dispose();
        }
        private void getPopulationChange(int placeId)
        {
            // Get the place population change and show arrow    
            SqlCommand cmdGetPopChange = new SqlCommand("GetPopChange", Main.connection);
            cmdGetPopChange.CommandType = CommandType.StoredProcedure;
            cmdGetPopChange.Parameters.AddWithValue("@placeId", placeId);
            double popChange = (double)cmdGetPopChange.ExecuteScalar();
            string popChangeString = popChange.ToString("P2");
            if (popChange < 0)
            {
                picPopChangeDown.Visible = true;
                popChangeString = popChangeString + " per year";
            }
            else if (popChange > .01)
            {
                picPopChangeUp.Visible = true;
                popChangeString = "+ " + popChangeString + " per year";
            }
            else
            {
                picPopChangeSame.Visible = true;
                popChangeString = "+ " + popChangeString + " per year";
            }
            lblPopChangeInfo.Text = popChangeString;
        } 
        private void getEconomicData(int placeId)
        {
            //get the place's economic data
            SqlCommand cmdGetEconomicData= new SqlCommand("GetEconomicData", Main.connection);
            cmdGetEconomicData.CommandType = CommandType.StoredProcedure;
            cmdGetEconomicData.Parameters.AddWithValue("@placeId", placeId);
            if (!year.Equals("Max"))
            {
                cmdGetEconomicData.Parameters.AddWithValue("@year", year);
            }

            //read the query result
            SqlDataReader reader = cmdGetEconomicData.ExecuteReader();

            //get index of query result
            var indexOfPoverty = reader.GetOrdinal("povertyLevel");
            var indexOfLabor = reader.GetOrdinal("laborParticipation");
            var indexOfIncome = reader.GetOrdinal("averageIncome");

            while (reader.Read())
            {
                double povertyLevel = (double)reader.GetDouble(indexOfPoverty);
                povertyRate = povertyLevel;
                double laborParticipation = (double)reader.GetDouble(indexOfLabor);
                laborRate = laborParticipation;
                double avgIncome = (double  )reader.GetValue(indexOfIncome);

                lblPovertyRate.Text = povertyLevel.ToString("P2");
                lblCurLabor.Text = laborParticipation.ToString("P2");
                lblCurAvgIncome.Text = avgIncome.ToString("C0");
            }

            reader.Close();
        }
        private void getPovertyChange(int placeId)
        {
            // Get the place population change and show arrow    
            SqlCommand cmdGetPovertyChange = new SqlCommand("GetPovertyChange", Main.connection);
            cmdGetPovertyChange.CommandType = CommandType.StoredProcedure;
            cmdGetPovertyChange.Parameters.AddWithValue("@placeId", placeId);
            double povertyChange = (double)cmdGetPovertyChange.ExecuteScalar();
            povertyChange = povertyRate * povertyChange;

            string povertyChangeString = povertyChange.ToString("P2");
            if (povertyChange < 0)
            {
                picPovertyDown.Visible = true;
                povertyChangeString = povertyChangeString + " per year";
            }
            else if (povertyChange > .01)
            {
                picPovertyUp.Visible = true;
                povertyChangeString = "+ " + povertyChangeString + " per year";
            }
            else
            {
                picPovertySame.Visible = true;
                povertyChangeString = "+ " + povertyChangeString + " per year";
            }
            lblPovertyChangeInfo.Text = povertyChangeString;
        }
        private void getLaborChange(int placeId)
        {
            // Get the place labor change and show arrow    
            SqlCommand cmdLaborChange = new SqlCommand("GetLaborParticipationChange", Main.connection);
            cmdLaborChange.CommandType = CommandType.StoredProcedure;
            cmdLaborChange.Parameters.AddWithValue("@placeId", placeId);
            double laborChange = (double)cmdLaborChange.ExecuteScalar();
            laborChange = laborRate * laborChange;
            string laborChangeString = laborChange.ToString("P2");
            if (laborChange < 0)
            {
                picLaborDown.Visible = true;
                laborChangeString = laborChangeString + " per year";
            }
            else if (laborChange > .01)
            {
                picLaborUp.Visible = true;
                laborChangeString = "+ " + laborChangeString + " per year";
            }
            else
            {
                picLaborSame.Visible = true;
                laborChangeString = "+ " + laborChangeString + " per year";
            }
            lblLaborChangeInfo.Text = laborChangeString;
        }
        private void getAvgIncomeChange(int placeId)
        {
            // Get the place average income change and show arrow    
            SqlCommand cmdGetIncomeChange = new SqlCommand("GetAvgIncomeChange", Main.connection);
            cmdGetIncomeChange.CommandType = CommandType.StoredProcedure;
            cmdGetIncomeChange.Parameters.AddWithValue("@placeId", placeId);
            double incomeChange = (double)cmdGetIncomeChange.ExecuteScalar();
            string incomeChangeString = incomeChange.ToString("P2");
            if (incomeChange < 0)
            {
                picIncomeDown.Visible = true;
                incomeChangeString = incomeChangeString + " per year";
            }
            else if (incomeChange > .01)
            {
                picIncomeUp.Visible = true;
                incomeChangeString = "+ " + incomeChangeString + " per year";
            }
            else
            {
                picIncomeSame.Visible = true;
                incomeChangeString = "+ " + incomeChangeString + " per year";
            }
            lblIncomeChangeInfo.Text = incomeChangeString;
        }
        private void getTopIndustries(int placeId)
        {
            //get the place's top 3 industries
            SqlCommand cmdGetIndustry = new SqlCommand("GetTopIndustries", Main.connection);
            cmdGetIndustry.CommandType = CommandType.StoredProcedure;
            cmdGetIndustry.Parameters.AddWithValue("@placeId", placeId);

            //read the query result
            SqlDataReader reader = cmdGetIndustry.ExecuteReader();

            //get index of query result
            var indexOfType= reader.GetOrdinal("type");

            int cnt = 0;

            while (reader.Read())
            {
                cnt++;
                string type = (string)reader.GetString(indexOfType);
                switch (cnt)
                {
                    case 1:
                        txtIndustry1.Text = type;
                        break;
                    case 2:
                        txtIndustry2.Text = type;
                        break;
                    case 3:
                        txtIndustry3.Text = type;
                        break;
                }
            }

            reader.Close();
        }
        private void getMedianAge(int placeId)
        {
            // Get the place median age of popluation
            SqlCommand cmd= new SqlCommand("GetMedianAge", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placeId", placeId);
            if (!year.Equals("Max"))
            {
                cmd.Parameters.AddWithValue("@year", year);
            }
            double medianAge = (double)cmd.ExecuteScalar();
            lblMedianAge.Text = medianAge.ToString();
            cmd.Dispose();
        }
        private void getGenderRatio(int placeId)
        {
            // Get the place gender ratio of popluation
            SqlCommand cmd = new SqlCommand("GetGenderRatio", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placeId", placeId);
            if (!year.Equals("Max"))
            {
                cmd.Parameters.AddWithValue("@year", year);
            }
            double ratio = (double)cmd.ExecuteScalar();
            lblGenderRatio.Text = ratio.ToString()+":1";
            cmd.Dispose();
        }
        private void getPlaceNotes(int placeId)
        {
            notePanel.Controls.Clear();
            int pointX = 0;
            int pointY = 10;

            SqlCommand cmd = new SqlCommand("placeNotes", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login", Main.login);
            cmd.Parameters.AddWithValue("@placeId", placeId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String content = reader[0].ToString();
                String user = reader[1].ToString();

                Label l = new Label();
                l.Text = user;
                l.Font = new Font(l.Font.FontFamily, 10);
                l.Location = new Point(pointX + 250, pointY);
                notePanel.Controls.Add(l);

                pointY += l.Height;

                TextBox t = new TextBox();
                t.Multiline = true;
                t.ReadOnly = true;
                t.ScrollBars = ScrollBars.Vertical;
                t.WordWrap = true;
                t.Width = 330;
                t.Height = 80;
                t.Font = new Font(t.Font.FontFamily, 12);
                t.Text = content;
                t.Location = new Point(pointX, pointY);
                notePanel.Controls.Add(t);
                notePanel.Show();
                pointY += t.Height + 20;

            }
            reader.Close();
            cmd.Dispose();
        }
        private void getUserNote(int placeId)
        {
            SqlCommand userNote = new SqlCommand("userPlaceNote", Main.connection);
            userNote.CommandType = CommandType.StoredProcedure;
            userNote.Parameters.AddWithValue("@login", Main.login);
            userNote.Parameters.AddWithValue("@placeId", placeId);
            SqlDataReader reader = userNote.ExecuteReader();
            int noteId = 0;
            String content;
            while (reader.Read())
            {
                noteId = Convert.ToInt32(reader[0]);
                content = reader[1].ToString();
                noteTextBox.Text = content;

            }


            lblDeleteNote.Tag = noteId;
            cmdSaveNotes.Tag = noteId;
            noteTextBox.Font = new Font(noteTextBox.Font.FontFamily, 12);
            if (noteId > 0)
            {
                lblDeleteNote.Visible = true;
            }


            reader.Close();

        }


        private void lblDeleteNote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SQL code to delete a note
            var linkLabel = (LinkLabel)sender;
            int noteId = (int)linkLabel.Tag;
            SqlCommand deleteCmd = new SqlCommand("deleteNote", Main.connection);
            deleteCmd.CommandType = CommandType.StoredProcedure;
            deleteCmd.Parameters.AddWithValue("@noteId", noteId);
            deleteCmd.ExecuteNonQuery();
            lblDeleteNote.Visible = false;
            noteTextBox.Clear();
            drawForm(Main.placeId);
            this.Refresh();
        }

        private void cmdSaveNotes_Click(object sender, EventArgs e)
        {
            //SQL code to update a note
            var button = (Button)sender;
            int noteId = (int)button.Tag;
            if (noteId == 0)
            {
                SqlCommand saveCmd = new SqlCommand("createNote", Main.connection);
                saveCmd.CommandType = CommandType.StoredProcedure;
                saveCmd.Parameters.AddWithValue("@content", noteTextBox.Text);
                saveCmd.Parameters.AddWithValue("@placeId", Main.placeId);
                saveCmd.Parameters.AddWithValue("@userLogin", Main.login);
                saveCmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand saveCmd = new SqlCommand("updateNote", Main.connection);
                saveCmd.CommandType = CommandType.StoredProcedure;
                saveCmd.Parameters.AddWithValue("@noteId", noteId);
                saveCmd.Parameters.AddWithValue("@content", noteTextBox.Text);
                saveCmd.ExecuteNonQuery();
            }
            drawForm(Main.placeId);
            this.Refresh();
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

        private void btnReturnToResults_Click(object sender, EventArgs e)
        {
            this.Close();
            Results results = new Results();
            results.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.Close();
            PlaceInfo placeInfo = new PlaceInfo((string)cboYear.SelectedItem);
            placeInfo.Show();
        }
    }
}
