namespace CS564ProjectV1
{
    partial class frmNewUser
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
            this.lblRegisterLink = new System.Windows.Forms.LinkLabel();
            this.cmdRegister = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRegisterLink
            // 
            this.lblRegisterLink.AutoSize = true;
            this.lblRegisterLink.Location = new System.Drawing.Point(558, 350);
            this.lblRegisterLink.Name = "lblRegisterLink";
            this.lblRegisterLink.Size = new System.Drawing.Size(158, 13);
            this.lblRegisterLink.TabIndex = 11;
            this.lblRegisterLink.TabStop = true;
            this.lblRegisterLink.Text = "Already Registered? Login here.";
            this.lblRegisterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRegisterLink_LinkClicked);
            // 
            // cmdRegister
            // 
            this.cmdRegister.Location = new System.Drawing.Point(600, 300);
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Size = new System.Drawing.Size(75, 23);
            this.cmdRegister.TabIndex = 10;
            this.cmdRegister.Text = "Register";
            this.cmdRegister.UseVisualStyleBackColor = true;
            this.cmdRegister.Click += new System.EventHandler(this.cmdRegister_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(638, 256);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(550, 260);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(638, 226);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(550, 230);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "User Name";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(638, 166);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 13;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(550, 170);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(57, 13);
            this.lblFname.TabIndex = 12;
            this.lblFname.Text = "First Name";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(638, 196);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 15;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(550, 200);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(58, 13);
            this.lblLname.TabIndex = 14;
            this.lblLname.Text = "Last Name";
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.lblRegisterLink);
            this.Controls.Add(this.cmdRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.MaximumSize = new System.Drawing.Size(1360, 768);
            this.MinimumSize = new System.Drawing.Size(1360, 768);
            this.Name = "frmNewUser";
            this.Text = "Create User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblRegisterLink;
        private System.Windows.Forms.Button cmdRegister;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label lblLname;
    }
}