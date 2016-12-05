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
            
            //get the place name -- inherited from the search results
            SqlCommand cmd = new SqlCommand("GetPlaceName", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placeId", placeId);
            string placeName = (string)cmd.ExecuteScalar();
            lblPlaceName.Text = placeName;

            //get the place's state data
            SqlCommand cmdStateInfo = new SqlCommand("GetStateInfo", Main.connection);
            cmdStateInfo.CommandType = CommandType.StoredProcedure;
            cmdStateInfo.Parameters.AddWithValue("@placeId", placeId);

            SqlDataReader reader = cmdStateInfo.ExecuteReader();

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
    }
}
