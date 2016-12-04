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

            int placeId = 5548000;
            //get the place name -- inherited from the search results
            SqlCommand cmd = new SqlCommand("GetPlaceName", Main.connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@placeId", placeId);
            string placeName = (string)cmd.ExecuteScalar();
            lblPlaceName.Text = placeName;

            //get the place's state data
        }
    }
}
