﻿using System;
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
    

    public partial class ReviewNotes : Form
    {


        public ReviewNotes()
        {
            InitializeComponent();
            drawForm();            

        }

        private void drawForm()
        {

            lblWelcomeUser.Text = "Welcome " + Main.name + " !";

            notePanel.Controls.Clear();
            int pointX = 0;
            int pointY = 10;

            SqlCommand userNotesCmd = new SqlCommand("userNotes", Main.connection);
            userNotesCmd.CommandType = CommandType.StoredProcedure;
            userNotesCmd.Parameters.AddWithValue("@login", Main.login);
            SqlDataReader userNotesReader = userNotesCmd.ExecuteReader();
            bool doneReading;
            do
            {
                doneReading = true;
                while (userNotesReader.Read())
                {
                    doneReading = false;
                    int noteId = Convert.ToInt32(userNotesReader[0]);
                    String content = userNotesReader[1].ToString();
                    String placeName = userNotesReader[2].ToString();
                    int placeId = Convert.ToInt32(userNotesReader[3]);

                    LinkLabel l = new LinkLabel();
                    l.Text = placeName;
                    l.Location = new Point(pointX, pointY);
                    l.Tag = placeId;
                    l.LinkClicked += myPlaceLinkClick;
                    notePanel.Controls.Add(l);

                    LinkLabel d = new LinkLabel();
                    d.Text = "delete note";
                    d.Location = new Point(pointX + 360, pointY);
                    d.Tag = noteId;
                    d.LinkClicked += myDeleteNoteClick;
                    notePanel.Controls.Add(d);

                    pointY += l.Height;

                    TextBox t = new TextBox();  
                    t.Multiline = true;
                    t.ScrollBars = ScrollBars.Vertical;
                    t.WordWrap = true;
                    t.ReadOnly = true;
                    t.Width = 450;
                    t.Height = 100;
                    t.Font = new Font(t.Font.FontFamily, 12);
                    t.Text = content;
                    t.Location = new Point(pointX, pointY);
                    notePanel.Controls.Add(t);
                    notePanel.Show();
                    pointY += t.Height + 20;

                }
            } while (!doneReading && userNotesReader.NextResult());
            userNotesReader.Close();

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

        private void lblFindPlaceCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // *EAS jump to the Find Place by City form
            this.Close();
            FindPlaceCity findPlaceCity = new FindPlaceCity();
            findPlaceCity.Show();
        }

        private void myPlaceLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            var linkLabel = (LinkLabel)sender;
            Main.placeId = (int)linkLabel.Tag;
            PlaceInfo placeInfo = new PlaceInfo();
            placeInfo.Show();
        }

        private void myDeleteNoteClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SQL code to delete a note
            var linkLabel = (LinkLabel)sender;
            int noteId = (int)linkLabel.Tag;
            SqlCommand deleteCmd = new SqlCommand("deleteNote", Main.connection);
            deleteCmd.CommandType = CommandType.StoredProcedure;
            deleteCmd.Parameters.AddWithValue("@noteId", noteId);
            deleteCmd.ExecuteNonQuery();
            drawForm();
            this.Refresh();
        }

    }
}
