﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS564ProjectV1
{
    public partial class Main : Form
    {
        public static string login;
        public static string name;
        public static string sql;
        public static int placeId = 5548000;        //default to Madison
        //toggle between local DB connection and Epic hosted DB connection
        //static string dbConnectionString = @"Server=Leap;Database=Locations;Integrated Security=true";
        static string dbConnectionString = @"Server=localhost;Database=Locations;Integrated Security=true";
        public static SqlConnection connection = new SqlConnection(dbConnectionString);
        public Main()
        {
            connection.Open();
            InitializeComponent();
        }

        private void cmdLaunch_Click(object sender, EventArgs e)
        {
            // *GWL launch into login screen
            this.WindowState = FormWindowState.Minimized;
            FrmLogin loginScreen = new FrmLogin();
            loginScreen.Show();
        }

        private void lblGoToPlacePg_Click(object sender, EventArgs e)
        {
            Main.login = "guest";
            PlaceInfo newPlaceInfo = new PlaceInfo();
            newPlaceInfo.Show();
        }
    }
}
