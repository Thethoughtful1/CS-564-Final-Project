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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        // * GWL TO DO: check out and maybe adjust this data source... idk what it does
        string dbConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Genie\Documents\CS564Locations.mdf;Integrated Security=True;Connect Timeout=30";


        // *GWL hop from the login screen to the new user screen
        private void lblRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frmNewUser newUserForm = new frmNewUser();
            newUserForm.Show();                      
        }

        // *GWL clicking the login button - check existing login users
        //  tutorial source: http://www.ittutorialswithexample.com/2015/01/simple-windows-form-login-application-in-csharp.html

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * from UserDataTable WHERE login=@username and Password=@password",connection);
            cmd.Parameters.AddWithValue("@username",txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            connection.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            
            /* *GWL TO DO - exception here... idk. You cna un-comment this to fix it.
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            connection.Close();

            int count = ds.Tables[0].Rows.Count;
            */ 
  
            // *GWL TO DO - DELTE ME - this is for testing purposes only after SQL query returns success
            int count = 1;    
        
            // *GWL if count is equal to 1, then show user profile

            if (count == 1)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                UserProfile userProfile = new UserProfile();
                userProfile.Show();
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }
    }
}
