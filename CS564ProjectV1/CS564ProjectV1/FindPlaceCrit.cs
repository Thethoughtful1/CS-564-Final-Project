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
    public partial class FindPlaceCrit : Form
    {
        private string sql;
        HashSet<string> joins = new HashSet<string>();
        HashSet<string> wheres = new HashSet<string>();

        static private Dictionary<string, Criteria> choices = new Dictionary<string, Criteria>()
    {
        { "Name", new Criteria("Place", "name") },                  // Not currently used
        { "State", new Criteria("PlaceIsIn", "name") },             // Not currently used
        { "Industry Participation Rate", new Criteria("Industry", "numberOfWorkers") }, // Not currently used
        { "Population", new Criteria("Demographics", "population") },
        { "Gender Ratio", new Criteria("Demographics", "genderRatio") },
        { "Median Age", new Criteria("Demographics", "medianAge") },
        { "Average Income", new Criteria("Economy", "averageIncome") },
        { "Poverty Level", new Criteria("Economy", "povertyLevel") },
        { "Labor Participation Rate", new Criteria("Economy", "laborParticipation") },
        { "State Population", new Criteria("State", "population") },
        { "State Total Income", new Criteria("State", "incomeTotal") },
        { "State Education Spending", new Criteria("State", "spendingEducation") },
        { "State Natural Resource Spending", new Criteria("State", "spendingNaturalResources") },
        { "State Public Welfare Spending", new Criteria("State", "spendingPublicWelfare") },
        { "State Health Spending Spending", new Criteria("State", "spendingHealth") },
    };

        public FindPlaceCrit()
        {
            InitializeComponent();
            cboCrit1SpecialBool.SelectedItem = "≈";
            cboCrit2SpecialBool.SelectedItem = "≈";

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

            criteriaValid = addCriteria(cboCriteria1.Text, cboCrit1Bool.Text, txtCrit1Str.Text, cboIndustry1.Text);
            criteriaValid = addCriteria(cboCriteria2.Text, cboCrit2Bool.Text, txtCrit2Str.Text, cboIndustry2.Text);
            criteriaValid = addCriteria(cboCriteria3.Text, cboCrit3Bool.Text, txtCrit3Str.Text, cboIndustry3.Text);
            criteriaValid = addCriteria(cboCriteria4.Text, cboCrit4Bool.Text, txtCrit4Str.Text, cboIndustry4.Text);
            criteriaValid = addCriteria(cboCriteria5.Text, cboCrit5Bool.Text, txtCrit5Str.Text, cboIndustry5.Text);

            sql = @"
SELECT Place.placeId, MAX(Place.name) Place, MAX(PlaceIsIn.stateName) State
  FROM Place
    INNER JOIN PlaceIsIn
      ON Place.placeId = PlaceIsIn.placeId
";
            foreach (string join in joins)
            {
                sql += FlushWith("    INNER JOIN PlaceIsIn", join);
                sql += "\n";
            }

            sql += FlushWith("  FROM Place", "WHERE 1 = 1");
            sql += "\n";

            foreach (string where in wheres)
            {
                sql += FlushWith("  FROM Place", where, 2);
                sql += "\n";
            }

            sql += FlushWith("  FROM Place", "GROUP BY Place.PlaceId");
            sql += "\n";

            Debug.WriteLine(sql);

            if(!criteriaValid)
            {
                MessageBox.Show("All partial criteria ignored");
            }
        }

        private bool addCriteria(string criteria, string relationship, string value, string industry)
        {
            bool criteriaValid = true;

            if (value.Length == 0 && criteria.Length == 0)
            {
                criteriaValid = true;
            }
            if (value.Length == 0 || criteria.Length == 0)
            {
                criteriaValid = false;
            }
            else if (criteria.Equals("Name"))
            {
                AddName(value);
            }
            else if (criteria.Equals("State"))
            {
                AddState(value);
            }
            else if (relationship.Length == 0)
            {
            }
            else if (criteria.Equals("Industry Participation Rate"))
            {
                if (industry.Length == 0)
                {
                    criteriaValid = false;
                }
                else
                {
                    AddIndustry(industry, relationship, value);
                }
            }
            else
            {
                AddGenericCriteria(criteria, relationship, value);
            }

            return criteriaValid;
        }

        private void AddGenericCriteria(string criteria, string relationship, string value)
        {
            Criteria choice = choices[criteria];
            
            joins.Add(Join(choice.table));
            wheres.Add(Where(choice.table + "." + choice.column, relationship, value));
        }

        private void AddIndustry(string type, string relationship, string value)
        {

            string alias = "Industry" + type.Replace(" ", String.Empty).Substring(0, 50);
            joins.Add(JoinIndustry(alias));
            joins.Add(JoinIndustry("IndustryTotal"));
            wheres.Add("AND IndustryTotal.Type = 'Total'");
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            wheres.Add(Where(alias + ".NumberOfWorkers/IndustryTotal.Type", relationship, value));
        }

        private string Where(string value1, string relationship, string value2)
        {
            if (relationship == "≈")
            {
                return "AND " + Avg(value1) + " > " + Avg(value2) + " * 0.9" + "\n"
                     + "AND " + Avg(value1) + " < " + Avg(value2) + " * 1.1";
            }
            else
            {
                return "AND " + Avg(value1) + " " + relationship + " " + Avg(value2);
            }

        }

        private string Avg(string value)
        {
            return "AVG( CAST( " + value + " AS float ) )";
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

        class Criteria
        {
            public string table;
            public string column;

            public Criteria(string table, string column)
            {
                this.table = table;
                this.column = column;
            }
        }

        static string FlushWith(string s1, string s2, int i = 0)
        {
            i += s1.TakeWhile(c => char.IsWhiteSpace(c)).Count();
            return FullIndent(i, s2);
        }

        static string FullIndent(int i, string s)
        {
            string indent = new string(' ', i);
            return indent + s.Replace("\n", "\n" + indent);
        }
    }
}
