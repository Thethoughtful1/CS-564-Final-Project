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
    public partial class PlaceInfo : Form
    {
        public PlaceInfo()
        {
            InitializeComponent();

            int placeId = Main.placeId;
                        
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

            //read the query result
            SqlDataReader reader = cmdGetEconomicData.ExecuteReader();

            //get index of query result
            var indexOfPoverty = reader.GetOrdinal("povertyLevel");
            var indexOfLabor = reader.GetOrdinal("laborParticipation");
            var indexOfIncome = reader.GetOrdinal("averageIncome");

            while (reader.Read())
            {
                double povertyLevel = (double)reader.GetDouble(indexOfPoverty);
                double laborParticipation = (double)reader.GetDouble(indexOfLabor);
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
            string povertyChangeString = povertyChange.ToString("P2");
            if (povertyChange < 0)
            {
                picPovertyDown.Visible = true;
                povertyChangeString = povertyChangeString + " per year";
            }
            else if (povertyChange > .01)
            {
                picPopChangeUp.Visible = true;
                povertyChangeString = "+ " + povertyChangeString + " per year";
            }
            else
            {
                picPopChangeSame.Visible = true;
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
            double ratio = (double)cmd.ExecuteScalar();
            lblGenderRatio.Text = ratio.ToString();
            cmd.Dispose();
        }
    }
}
