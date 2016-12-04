namespace CS564ProjectV1
{
    partial class UserProfile
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
            this.lblReviewNotes = new System.Windows.Forms.LinkLabel();
            this.lblFindPlaceCity = new System.Windows.Forms.LinkLabel();
            this.lblFindPlaceCrit = new System.Windows.Forms.LinkLabel();
            this.lblUserExclamation = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.txtFnam = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCurrentLocation = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMyProfile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReviewNotes
            // 
            this.lblReviewNotes.AutoSize = true;
            this.lblReviewNotes.Location = new System.Drawing.Point(468, 58);
            this.lblReviewNotes.Name = "lblReviewNotes";
            this.lblReviewNotes.Size = new System.Drawing.Size(74, 13);
            this.lblReviewNotes.TabIndex = 18;
            this.lblReviewNotes.TabStop = true;
            this.lblReviewNotes.Text = "Review Notes";
            this.lblReviewNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReviewNotes_LinkClicked);
            // 
            // lblFindPlaceCity
            // 
            this.lblFindPlaceCity.AutoSize = true;
            this.lblFindPlaceCity.Location = new System.Drawing.Point(801, 58);
            this.lblFindPlaceCity.Name = "lblFindPlaceCity";
            this.lblFindPlaceCity.Size = new System.Drawing.Size(100, 13);
            this.lblFindPlaceCity.TabIndex = 17;
            this.lblFindPlaceCity.TabStop = true;
            this.lblFindPlaceCity.Text = "Find a Place by City";
            this.lblFindPlaceCity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFindPlaceCity_LinkClicked);
            // 
            // lblFindPlaceCrit
            // 
            this.lblFindPlaceCrit.AutoSize = true;
            this.lblFindPlaceCrit.Location = new System.Drawing.Point(630, 58);
            this.lblFindPlaceCrit.Name = "lblFindPlaceCrit";
            this.lblFindPlaceCrit.Size = new System.Drawing.Size(115, 13);
            this.lblFindPlaceCrit.TabIndex = 16;
            this.lblFindPlaceCrit.TabStop = true;
            this.lblFindPlaceCrit.Text = "Find a Place by Criteria";
            this.lblFindPlaceCrit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFindPlaceCrit_LinkClicked);
            // 
            // lblUserExclamation
            // 
            this.lblUserExclamation.AutoSize = true;
            this.lblUserExclamation.Location = new System.Drawing.Point(754, 28);
            this.lblUserExclamation.Name = "lblUserExclamation";
            this.lblUserExclamation.Size = new System.Drawing.Size(10, 13);
            this.lblUserExclamation.TabIndex = 15;
            this.lblUserExclamation.Text = "!";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(650, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "TODO: Current User";
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Location = new System.Drawing.Point(599, 28);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(55, 13);
            this.lblWelcomeUser.TabIndex = 13;
            this.lblWelcomeUser.Text = "Welcome ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(664, 192);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 27;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(576, 196);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(58, 13);
            this.lblLname.TabIndex = 26;
            this.lblLname.Text = "Last Name";
            // 
            // txtFnam
            // 
            this.txtFnam.Location = new System.Drawing.Point(664, 162);
            this.txtFnam.Name = "txtFnam";
            this.txtFnam.Size = new System.Drawing.Size(100, 20);
            this.txtFnam.TabIndex = 25;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(576, 166);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(57, 13);
            this.lblFname.TabIndex = 24;
            this.lblFname.Text = "First Name";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(633, 305);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 23;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(664, 252);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 22;
            // 
            // lblCurrentLocation
            // 
            this.lblCurrentLocation.AutoSize = true;
            this.lblCurrentLocation.Location = new System.Drawing.Point(576, 256);
            this.lblCurrentLocation.Name = "lblCurrentLocation";
            this.lblCurrentLocation.Size = new System.Drawing.Size(85, 13);
            this.lblCurrentLocation.TabIndex = 21;
            this.lblCurrentLocation.Text = "Current Location";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(664, 222);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "User Name";
            // 
            // lblMyProfile
            // 
            this.lblMyProfile.AutoSize = true;
            this.lblMyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyProfile.Location = new System.Drawing.Point(632, 124);
            this.lblMyProfile.Name = "lblMyProfile";
            this.lblMyProfile.Size = new System.Drawing.Size(77, 20);
            this.lblMyProfile.TabIndex = 28;
            this.lblMyProfile.Text = "My Profile";
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.lblMyProfile);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.txtFnam);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblCurrentLocation);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReviewNotes);
            this.Controls.Add(this.lblFindPlaceCity);
            this.Controls.Add(this.lblFindPlaceCrit);
            this.Controls.Add(this.lblUserExclamation);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblWelcomeUser);
            this.MaximumSize = new System.Drawing.Size(1360, 768);
            this.MinimumSize = new System.Drawing.Size(1360, 768);
            this.Name = "UserProfile";
            this.Text = "UserProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblReviewNotes;
        private System.Windows.Forms.LinkLabel lblFindPlaceCity;
        private System.Windows.Forms.LinkLabel lblFindPlaceCrit;
        private System.Windows.Forms.Label lblUserExclamation;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.TextBox txtFnam;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblCurrentLocation;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMyProfile;
    }
}