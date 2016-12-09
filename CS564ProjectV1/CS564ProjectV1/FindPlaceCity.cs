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
    public partial class FindPlaceCity : Form
    {
        private string approximately = "≈";
        private string sql;
        private string placeId0;
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

        public FindPlaceCity()
        {
            InitializeComponent();
            cboCrit1SpecialBool.SelectedItem = approximately;
            cboCrit2SpecialBool.SelectedItem = approximately;

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


            DataSet compareCityDataSet = new DataSet();
            SqlDataAdapter compareCitySqlDataAdapter = new SqlDataAdapter();
            SqlCommand compareCityCmd = new SqlCommand("GetCompareCities", Main.connection);
            compareCityCmd.CommandType = CommandType.StoredProcedure;
            compareCityCmd.Parameters.AddWithValue("@login", Main.login);
            compareCitySqlDataAdapter.SelectCommand = compareCityCmd;

            compareCitySqlDataAdapter.Fill(compareCityDataSet);

            Dictionary<string, string> compareCityDictionary = new Dictionary<string, string>();

            foreach (DataRow row in compareCityDataSet.Tables[0].Rows)
            {
                compareCityDictionary.Add(row["placeId"].ToString(), row["name"].ToString() + ", " + row["stateName"].ToString());
            }
            cboCompareCity.DataSource = new BindingSource(compareCityDictionary, null);
            cboCompareCity.DisplayMember = "value"; 
            cboCompareCity.ValueMember = "key";
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
        private void lblFindPlaceCrit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by Criteria form
            this.Close();
            FindPlaceCrit findPlaceCrit = new FindPlaceCrit();
            findPlaceCrit.Show();
        }
        private void cboCriteria1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboCriteria1.Text.Equals(""))
            {
                cboCrit1Bool.Text = "";
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
            placeId0 = (string)cboCompareCity.SelectedValue;

            criteriaValid = addCriteria(cboCriteria1.Text, cboCrit1Bool.Text, cboIndustry1.Text);
            criteriaValid = addCriteria(cboCriteria2.Text, cboCrit2Bool.Text, cboIndustry2.Text);
            criteriaValid = addCriteria(cboCriteria3.Text, cboCrit3Bool.Text, cboIndustry3.Text);
            criteriaValid = addCriteria(cboCriteria4.Text, cboCrit4Bool.Text, cboIndustry4.Text);
            criteriaValid = addCriteria(cboCriteria5.Text, cboCrit5Bool.Text, cboIndustry5.Text);

            sql = @"
SELECT Place.placeId, MAX(Place.name) Place, MAX(PlaceIsIn.stateName) State
  FROM Place Place
    INNER JOIN PlaceIsIn PlaceIsIn
      ON Place.placeId = PlaceIsIn.placeId
    INNER JOIN Place Place0
      ON " + placeId0 + @" = Place0.placeId
    INNER JOIN PlaceIsIn PlaceIsIn0
      ON " + placeId0 + @" = PlaceIsIn0.placeId
";
            foreach (string join in joins)
            {
                sql += FlushWith("    INNER...", join);
                sql += "\n";
            }

            sql += FlushWith("  FROM...", "WHERE 1 = 1");
            sql += "\n";

            foreach (string where in wheres)
            {
                sql += FlushWith("  FROM...", where, 2);
                sql += "\n";
            }

            sql += FlushWith("  FROM...", "GROUP BY Place.PlaceId");
            sql += "\n";

            sql += FlushWith("  FROM...", "HAVING 1 = 1");
            sql += "\n";

            foreach (string having in havings)
            {
                sql += FlushWith("  FROM...", having, 2);
                sql += "\n";
            }

            Debug.WriteLine(sql);
            Main.sql = sql;

            if (!criteriaValid)
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

        private bool addCriteria(string criteria, string relationship, string industry)
        {
            bool criteriaValid = true;

            if (criteria.Equals("Name"))
            {
                AddName();
            }
            else if (criteria.Equals("State"))
            {
                AddState();
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
                    AddIndustry(industry, relationship);
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
                    AddIndustryNumber(industry, relationship);
                }
            }
            else
            {
                AddGenericCriteria(criteria, relationship);
            }

            return criteriaValid;
        }

        private void AddGenericCriteria(string criteria, string relationship)
        {
            Criteria choice = choices[criteria];

            joins.Add(Join(choice.table));
            
            string alias = choice.table;
            string alias0 = alias + "0";
            havings.Add(Having(alias + "." + choice.column, relationship, alias0 + "." + choice.column));
        }

        private void AddIndustry(string type, string relationship)
        {

            string alias = "Industry" + type.Replace(" ", String.Empty).Replace(",", String.Empty);
            alias = alias.Substring(0, Math.Min(50, alias.Length));
            string alias0 = alias + "0";
            joins.Add(JoinIndustry(alias));
            joins.Add(JoinIndustry("IndustryTotal"));
            wheres.Add("AND IndustryTotal.Type = 'Total'");
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            wheres.Add("AND IndustryTotal0.Type = 'Total'");
            wheres.Add("AND " + alias0 + ".Type = '" + type + "'");
            havings.Add(Having(alias + ".numberOfWorkers/IndustryTotal.numberOfWorkers", relationship, alias0 + ".numberOfWorkers/IndustryTotal0.numberOfWorkers"));
        }

        private void AddIndustryNumber(string type, string relationship)
        {

            string alias = "Industry" + type.Replace(" ", String.Empty).Replace(",", String.Empty);
            alias = alias.Substring(0, Math.Min(50, alias.Length));
            string alias0 = alias + "0";
            joins.Add(JoinIndustry(alias));
            wheres.Add("AND " + alias + ".Type = '" + type + "'");
            wheres.Add("AND " + alias0 + ".Type = '" + type + "'");
            havings.Add(Having(alias + ".numberOfWorkers", relationship, alias0 + ".numberOfWorkers"));
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

        private void AddState()
        {
            wheres.Add("AND PlaceIsIn.stateName LIKE '%' + PlaceIsIn0.stateName + '%'");
        }

        private void AddName()
        {
            wheres.Add("AND Place.name LIKE '%' + Place0.name + '%'");
        }


        string Join(string table)
        {
            string alias = table;
            string alias0 = alias + "0";
            if (!table.Equals("State"))
            {
            return "INNER JOIN " + table + " " + alias + "\n"
                 + "  ON Place.placeId = " + alias + ".placeId\n"
                 + "    AND PlaceIsIn.year = " + alias + ".year\n"
                 + "INNER JOIN " + table + " " + alias0 + "\n"
                 + "  ON " + placeId0 + " = " + alias0 + ".placeId\n"
                 + "    AND PlaceIsIn0.year = " + alias0 + ".year";
            }
            else
            {
            return "INNER JOIN State State \n"
                 + "  ON PlaceIsIn.stateName = State.name\n"
                 + "    AND PlaceIsIn.year = State.year\n"
                 + "INNER JOIN State State0 \n"
                 + "  ON PlaceIsIn0.stateName = State0.name\n"
                 + "    AND PlaceIsIn0.year = State0.year";
            }
        }

        string JoinIndustry(string alias)
        {
            string alias0 = alias + "0";
            return "INNER JOIN Industry " + alias + "\n"
                 + "  ON Place.placeId = " + alias + ".placeId\n"
                 + "    AND PlaceIsIn.year = " + alias + ".year\n"
                 + "INNER JOIN Industry " + alias0 + "\n"
                 + "  ON " + placeId0 + " = " + alias0 + ".placeId\n"
                 + "    AND PlaceIsIn0.year = " + alias0 + ".year";
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
