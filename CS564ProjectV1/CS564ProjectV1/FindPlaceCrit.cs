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
        private string sql = @"
SELECT Place.placeId, MAX(Place.name) Place, MAX(PlaceIsIn.stateName) State
  FROM Place
    INNER JOIN PlaceIsIn
      ON Place.placeId = PlaceIsIn.placeId
";
        HashSet<string> joins = new HashSet<string>();
        HashSet<string> wheres = new HashSet<string>();

        static private Dictionary<string, string> choices = new Dictionary<string, string>()
    {

    };

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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            bool criteriaValid = true;

            if (txtCrit1Str.Text.Length == 0)
            {
                criteriaValid = false;
            }
            else if (cboCriteria1.Text.Equals("Name"))
            {
                AddName(txtCrit1Str.Text);
            }
            else if (cboCriteria1.Text.Equals("State"))
            {
                AddState(txtCrit1Str.Text);
            }
            else if (cboCrit1Bool.Text.Length == 0)
            {
            }
            else if (cboCriteria1.Text.Equals("Industry Participation Rate"))
            {
                if (cboIndustry1.Text.Length == 0)
                { 
                    criteriaValid = false;
                } 
                else
                {
                    AddIndustry(cboIndustry1.Text, cboCrit1Bool.Text, txtCrit1Str.Text);
                }
            }
            else
            {
                AddGenericCriteria(txtCrit1Str.Text, cboCrit1Bool.Text);
            }

            if(!criteriaValid)
            {
                MessageBox.Show("All partial criteria ignored");
            }
        }

        private void AddGenericCriteria(string Criteria, string p2)
        {
            throw new NotImplementedException();
        }

        private void AddIndustry(string type, string relationship, string value)
        {
            joins.Add(JoinIndustry("IndustryTotal"));
            wheres.Add("AND IndustryTotal.Type = 'Total'");

            string alias = "Industry" + type.Replace(" ", String.Empty).Substring(0, 50);
            joins.Add(JoinIndustry(alias));
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            wheres.Add(Where(alias + ".NumberOfWorkers/IndustryTotal.Type", cboCrit1Bool.Text, txtCrit1Str.Text));
        }

        private string Where(string value1, string relationship, string value2)
        {
            throw new NotImplementedException();
            if (relationship == "≈")
            {
                return "AND " + value1 + " > " + value2 + " * 0.9" + "\n"
                     + "AND " + value1 + " < " + value2 + " * 1.1";
            }
            else
            {
                return "AND " + value1 + " " + relationship + " " + value2;
            }

        }

        private void AddState(string state)
        {
            wheres.Add("AND PlaceIsIn.stateName LIKE '%" + state + "%'");
        }

        private void AddName(string name)
        {
            wheres.Add("AND Place.name LIKE '%" + name + "%'");
        }

        string Join(string table1, string column1, string table2, string column2)
        {
            return "INNER JOIN " + table2 + "\n"
                 + "  ON " + table1 + "." + column1 + " = " + table2 + "." + column2 + "\n"
                 + "    AND PlaceIsIn.year = " + table2 + ".year";
        }

        string Join(string table)
        {
            string table1 = (table == "State" ? "PlaceIsIn" : "Place");
            string column1 = (table == "State" ? "name" : "placeId");
            string table2 = table;
            string column2 = (table == "State" ? "stateName" : "placeId");
            return Join(table1, column1, table2, column2);
        }

        string JoinIndustry(string alias)
        {
            return "INNER JOIN Industry " + alias + "\n"
                 + "  ON Place.placeId = " + alias + ".placeId\n"
                 + "    AND PlaceIsIn.year = Industry.year";
        }

        private class Criteria
        {
            string table;
            string column;

            Criteria(string table, string column)
            {
                this.table = table;
                this.column = column;
            }
        }
    }
}
