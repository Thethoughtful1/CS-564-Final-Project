namespace CS564ProjectV1
{
    partial class Results
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
            this.lblFindPlaceCity = new System.Windows.Forms.LinkLabel();
            this.lblEditProfile = new System.Windows.Forms.LinkLabel();
            this.lblFindPlaceCrit = new System.Windows.Forms.LinkLabel();
            this.lblReviewNotes = new System.Windows.Forms.LinkLabel();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.lblYourResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFindPlaceCity
            // 
            this.lblFindPlaceCity.AutoSize = true;
            this.lblFindPlaceCity.Location = new System.Drawing.Point(867, 55);
            this.lblFindPlaceCity.Name = "lblFindPlaceCity";
            this.lblFindPlaceCity.Size = new System.Drawing.Size(100, 13);
            this.lblFindPlaceCity.TabIndex = 61;
            this.lblFindPlaceCity.TabStop = true;
            this.lblFindPlaceCity.Text = "Find a Place by City";
            this.lblFindPlaceCity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFindPlaceCity_LinkClicked);
            // 
            // lblEditProfile
            // 
            this.lblEditProfile.AutoSize = true;
            this.lblEditProfile.Location = new System.Drawing.Point(376, 55);
            this.lblEditProfile.Name = "lblEditProfile";
            this.lblEditProfile.Size = new System.Drawing.Size(57, 13);
            this.lblEditProfile.TabIndex = 60;
            this.lblEditProfile.TabStop = true;
            this.lblEditProfile.Text = "Edit Profile";
            this.lblEditProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditProfile_LinkClicked);
            // 
            // lblFindPlaceCrit
            // 
            this.lblFindPlaceCrit.AutoSize = true;
            this.lblFindPlaceCrit.Location = new System.Drawing.Point(709, 55);
            this.lblFindPlaceCrit.Name = "lblFindPlaceCrit";
            this.lblFindPlaceCrit.Size = new System.Drawing.Size(115, 13);
            this.lblFindPlaceCrit.TabIndex = 59;
            this.lblFindPlaceCrit.TabStop = true;
            this.lblFindPlaceCrit.Text = "Find a Place by Criteria";
            this.lblFindPlaceCrit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFindPlaceCrit_LinkClicked);
            // 
            // lblReviewNotes
            // 
            this.lblReviewNotes.AutoSize = true;
            this.lblReviewNotes.Location = new System.Drawing.Point(538, 55);
            this.lblReviewNotes.Name = "lblReviewNotes";
            this.lblReviewNotes.Size = new System.Drawing.Size(74, 13);
            this.lblReviewNotes.TabIndex = 58;
            this.lblReviewNotes.TabStop = true;
            this.lblReviewNotes.Text = "Review Notes";
            this.lblReviewNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReviewNotes_LinkClicked);
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Location = new System.Drawing.Point(599, 28);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(55, 13);
            this.lblWelcomeUser.TabIndex = 57;
            this.lblWelcomeUser.Text = "Welcome ";
            // 
            // resultPanel
            // 
            this.resultPanel.AutoScroll = true;
            this.resultPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultPanel.Location = new System.Drawing.Point(379, 146);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(600, 450);
            this.resultPanel.TabIndex = 62;
            // 
            // lblYourResults
            // 
            this.lblYourResults.AutoSize = true;
            this.lblYourResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourResults.Location = new System.Drawing.Point(376, 112);
            this.lblYourResults.Name = "lblYourResults";
            this.lblYourResults.Size = new System.Drawing.Size(113, 20);
            this.lblYourResults.TabIndex = 14;
            this.lblYourResults.Text = "Your Results";
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 693);
            this.Controls.Add(this.lblYourResults);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.lblFindPlaceCity);
            this.Controls.Add(this.lblEditProfile);
            this.Controls.Add(this.lblFindPlaceCrit);
            this.Controls.Add(this.lblReviewNotes);
            this.Controls.Add(this.lblWelcomeUser);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblFindPlaceCity;
        private System.Windows.Forms.LinkLabel lblEditProfile;
        private System.Windows.Forms.LinkLabel lblFindPlaceCrit;
        private System.Windows.Forms.LinkLabel lblReviewNotes;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label lblYourResults;
    }
}