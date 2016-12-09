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
        private string approximately = "≈";
        private string sql;
        HashSet<string> joins = new HashSet<string>();
        HashSet<string> wheres = new HashSet<string>();
        HashSet<string> havings = new HashSet<string>();
        

        static private Dictionary<string, Criteria> choices = new Dictionary<string, Criteria>()
    {
        { "Name", new Criteria("Place", "name") },                  // Not currently used
        { "State", new Criteria("PlaceIsIn", "name") },             // Not currently used
        { "Industry Participation Number", new Criteria("Industry", "numberOfWorkers") }, // Not currently used
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
            cboCrit1SpecialBool.SelectedItem = approximately;
            cboCrit2SpecialBool.SelectedItem = approximately;
            cboYear.SelectedItem = "Average";

            lblWelcomeUser.Text = "Welcome " + Main.name + " !";

            DataSet industryDataSet = new DataSet();
            SqlDataAdapter industrySqlDataAdapter = new SqlDataAdapter();
            SqlCommand industryCmd = new SqlCommand("GetIndustries", Main.connection);
            industryCmd.CommandType = CommandType.StoredProcedure;
            industrySqlDataAdapter.SelectCommand = industryCmd;

            industrySqlDataAdapter.Fill(industryDataSet);
            cboIndustry1.DataSource = industryDataSet.Tables[0];
            cboIndustry1.DisplayMember = industryDataSet.Tables[0].Columns[0].ToString();

            cboIndustry2.DataSource = industryDataSet.Tables[0];
            cboIndustry2.DisplayMember = industryDataSet.Tables[0].Columns[0].ToString();

            cboIndustry3.DataSource = industryDataSet.Tables[0];
            cboIndustry3.DisplayMember = industryDataSet.Tables[0].Columns[0].ToString();

            cboIndustry4.DataSource = industryDataSet.Tables[0];
            cboIndustry4.DisplayMember = industryDataSet.Tables[0].Columns[0].ToString();

            cboIndustry5.DataSource = industryDataSet.Tables[0];
            cboIndustry5.DisplayMember = industryDataSet.Tables[0].Columns[0].ToString();
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
            if (cboCriteria1.Text.Equals(""))
            {
                cboCrit1Bool.Text = "";
                txtCrit1Str.Text = "";
            }
            else
            {
                cboCrit1Bool.Text = approximately;
            }
            
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
            if (cboCriteria1.Text.Equals("Industry Participation Rate") || cboCriteria1.Text.Equals("Industry Participation Number"))
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
            if (cboCriteria2.Text.Equals(""))
            {
                cboCrit2Bool.Text = "";
                txtCrit2Str.Text = "";
            }
            else
            {
                cboCrit2Bool.Text = approximately;
            }

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

            if (cboCriteria2.Text.Equals("Industry Participation Rate") || cboCriteria2.Text.Equals("Industry Participation Number"))
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
            if (cboCriteria3.Text.Equals(""))
            {
                cboCrit3Bool.Text = "";
                txtCrit3Str.Text = "";
            }
            else
            {
                cboCrit3Bool.Text = approximately;
            }

            if (cboCriteria3.Text.Equals("Industry Participation Rate") || cboCriteria3.Text.Equals("Industry Participation Number"))
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
            if (cboCriteria4.Text.Equals(""))
            {
                cboCrit4Bool.Text = "";
                txtCrit4Str.Text = "";
            }
            else
            {
                cboCrit4Bool.Text = approximately;
            }

            if (cboCriteria4.Text.Equals("Industry Participation Rate") || cboCriteria4.Text.Equals("Industry Participation Number"))
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
            if (cboCriteria5.Text.Equals(""))
            {
                cboCrit5Bool.Text = "";
                txtCrit5Str.Text = "";
            }
            else
            {
                cboCrit5Bool.Text = approximately;
            }

            if (cboCriteria5.Text.Equals("Industry Participation Rate") || cboCriteria5.Text.Equals("Industry Participation Number"))
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

            if (!cboYear.Text.Equals("Average"))
            {
                wheres.Add("AND PlaceIsIn.Year = " + cboYear.Text);
            }
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

            sql += FlushWith("  FROM Place", "HAVING 1 = 1");
            sql += "\n";

            foreach (string having in havings)
            {
                sql += FlushWith("  FROM Place", having, 2);
                sql += "\n";
            }

            sql += FlushWith("  FROM Place", "ORDER BY MAX(Place.Name)");
            sql += "\n";

            Debug.WriteLine(sql);
            Main.sql = sql;

            if(!criteriaValid)
            {
                MessageBox.Show("All partial criteria ignored");
            }

            // Clear criteria
            joins = new HashSet<string>();
            wheres = new HashSet<string>();
            havings = new HashSet<string>();

            this.Close();
            Results results = new Results();
            results.Show();
        }

        private bool addCriteria(string criteria, string relationship, string value, string industry)
        {
            bool criteriaValid = true;

            if (value.Length == 0 && criteria.Length == 0)
            {
                criteriaValid = true;
            }
            else if (value.Length == 0 || criteria.Length == 0)
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
            else if (criteria.Equals("Industry Participation Number"))
            {
                if (industry.Length == 0)
                {
                    criteriaValid = false;
                }
                else
                {
                    AddIndustryNumber(industry, relationship, value);
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
            havings.Add(Having(choice.table + "." + choice.column, relationship, value));
        }

        private void AddIndustry(string type, string relationship, string value)
        {

            string alias = "Industry" + type.Replace(" ", String.Empty).Replace(",", String.Empty);
            alias = alias.Substring(0, Math.Min(50, alias.Length));
            joins.Add(JoinIndustry(alias));
            joins.Add(JoinIndustry("IndustryTotal"));
            wheres.Add("AND IndustryTotal.Type = 'Total'");
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            havings.Add(Having(alias + ".numberOfWorkers/IndustryTotal.numberOfWorkers", relationship, value));
        }


        private void AddIndustryNumber(string type, string relationship, string value)
        {

            string alias = "Industry" + type.Replace(" ", String.Empty).Replace(",", String.Empty);
            alias = alias.Substring(0, Math.Min(50, alias.Length));
            joins.Add(JoinIndustry(alias));
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            havings.Add(Having(alias + ".numberOfWorkers", relationship, value));
        }

        private string Having(string value1, string relationship, string value2)
        {
            if (relationship.Equals(approximately))
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

        string Join(string table)
        {
            if (!table.Equals("State"))
            {
                return "INNER JOIN " + table + " " + table + "\n"
                     + "  ON Place.placeId = " + table + ".placeId\n"
                     + "    AND PlaceIsIn.year = " + table + ".year";
            }
            else
            {
                return "INNER JOIN " + table + " " + table + "\n"
                     + "  ON Place.placeId = " + table + ".placeId\n"
                     + "    AND PlaceIsIn.year = " + table + ".year";
            }
        }

        string JoinIndustry(string alias)
        {
            return "INNER JOIN Industry " + alias + "\n"
                 + "  ON Place.placeId = " + alias + ".placeId\n"
                 + "    AND PlaceIsIn.year = " + alias + ".year";
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
