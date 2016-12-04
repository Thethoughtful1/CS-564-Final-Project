namespace CS564ProjectV1
{
    partial class ReviewNotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEditProfile = new System.Windows.Forms.LinkLabel();
            this.lblFindPlaceCity = new System.Windows.Forms.LinkLabel();
            this.lblFindPlaceCrit = new System.Windows.Forms.LinkLabel();
            this.lblUserExclamation = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.lblYourNotes = new System.Windows.Forms.Label();
            this.notePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblEditProfile
            // 
            this.lblEditProfile.AutoSize = true;
            this.lblEditProfile.Location = new System.Drawing.Point(468, 58);
            this.lblEditProfile.Name = "lblEditProfile";
            this.lblEditProfile.Size = new System.Drawing.Size(57, 13);
            this.lblEditProfile.TabIndex = 12;
            this.lblEditProfile.TabStop = true;
            this.lblEditProfile.Text = "Edit Profile";
            // 
            // lblFindPlaceCity
            // 
            this.lblFindPlaceCity.AutoSize = true;
            this.lblFindPlaceCity.Location = new System.Drawing.Point(801, 58);
            this.lblFindPlaceCity.Name = "lblFindPlaceCity";
            this.lblFindPlaceCity.Size = new System.Drawing.Size(100, 13);
            this.lblFindPlaceCity.TabIndex = 11;
            this.lblFindPlaceCity.TabStop = true;
            this.lblFindPlaceCity.Text = "Find a Place by City";
            // 
            // lblFindPlaceCrit
            // 
            this.lblFindPlaceCrit.AutoSize = true;
            this.lblFindPlaceCrit.Location = new System.Drawing.Point(630, 58);
            this.lblFindPlaceCrit.Name = "lblFindPlaceCrit";
            this.lblFindPlaceCrit.Size = new System.Drawing.Size(115, 13);
            this.lblFindPlaceCrit.TabIndex = 10;
            this.lblFindPlaceCrit.TabStop = true;
            this.lblFindPlaceCrit.Text = "Find a Place by Criteria";
            // 
            // lblUserExclamation
            // 
            this.lblUserExclamation.AutoSize = true;
            this.lblUserExclamation.Location = new System.Drawing.Point(754, 28);
            this.lblUserExclamation.Name = "lblUserExclamation";
            this.lblUserExclamation.Size = new System.Drawing.Size(10, 13);
            this.lblUserExclamation.TabIndex = 9;
            this.lblUserExclamation.Text = "!";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(650, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "TODO: Current User";
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Location = new System.Drawing.Point(599, 28);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(55, 13);
            this.lblWelcomeUser.TabIndex = 7;
            this.lblWelcomeUser.Text = "Welcome ";
            // 
            // lblYourNotes
            // 
            this.lblYourNotes.AutoSize = true;
            this.lblYourNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourNotes.Location = new System.Drawing.Point(468, 95);
            this.lblYourNotes.Name = "lblYourNotes";
            this.lblYourNotes.Size = new System.Drawing.Size(70, 13);
            this.lblYourNotes.TabIndex = 13;
            this.lblYourNotes.Text = "Your Notes";
            // 
            // notePanel
            // 
            this.notePanel.Location = new System.Drawing.Point(471, 123);
            this.notePanel.Name = "notePanel";
            this.notePanel.Size = new System.Drawing.Size(430, 400);
            this.notePanel.TabIndex = 14;
            // 
            // ReviewNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.notePanel);
            this.Controls.Add(this.lblYourNotes);
            this.Controls.Add(this.lblEditProfile);
            this.Controls.Add(this.lblFindPlaceCity);
            this.Controls.Add(this.lblFindPlaceCrit);
            this.Controls.Add(this.lblUserExclamation);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblWelcomeUser);
            this.Name = "ReviewNotes";
            this.Text = "Review Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblEditProfile;
        private System.Windows.Forms.LinkLabel lblFindPlaceCity;
        private System.Windows.Forms.LinkLabel lblFindPlaceCrit;
        private System.Windows.Forms.Label lblUserExclamation;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Label lblYourNotes;
        private System.Windows.Forms.Panel notePanel;
    }
}