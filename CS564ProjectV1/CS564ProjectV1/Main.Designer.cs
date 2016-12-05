namespace CS564ProjectV1
{
    partial class Main
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
            this.cmdLaunch = new System.Windows.Forms.Button();
            this.lblAppIntro = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGoToPlacePg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdLaunch
            // 
            this.cmdLaunch.Location = new System.Drawing.Point(605, 370);
            this.cmdLaunch.Name = "cmdLaunch";
            this.cmdLaunch.Size = new System.Drawing.Size(97, 23);
            this.cmdLaunch.TabIndex = 0;
            this.cmdLaunch.Text = "Click to Begin";
            this.cmdLaunch.UseVisualStyleBackColor = true;
            this.cmdLaunch.Click += new System.EventHandler(this.cmdLaunch_Click);
            // 
            // lblAppIntro
            // 
            this.lblAppIntro.AutoSize = true;
            this.lblAppIntro.Location = new System.Drawing.Point(327, 338);
            this.lblAppIntro.Name = "lblAppIntro";
            this.lblAppIntro.Size = new System.Drawing.Size(653, 13);
            this.lblAppIntro.TabIndex = 1;
            this.lblAppIntro.Text = "You\'re using the Place Finder! This application will assist you in learning, disc" +
    "overing, and comparing locations in the US and Puerto Rico!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CS564ProjectV1.Properties.Resources.USA_orthographic_svg;
            this.pictureBox1.Location = new System.Drawing.Point(531, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblGoToPlacePg
            // 
            this.lblGoToPlacePg.AutoSize = true;
            this.lblGoToPlacePg.Location = new System.Drawing.Point(32, 646);
            this.lblGoToPlacePg.Name = "lblGoToPlacePg";
            this.lblGoToPlacePg.Size = new System.Drawing.Size(91, 13);
            this.lblGoToPlacePg.TabIndex = 3;
            this.lblGoToPlacePg.Text = "Go to Place Page";
            this.lblGoToPlacePg.Click += new System.EventHandler(this.lblGoToPlacePg_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 693);
            this.Controls.Add(this.lblGoToPlacePg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAppIntro);
            this.Controls.Add(this.cmdLaunch);
            this.MaximumSize = new System.Drawing.Size(1360, 768);
            this.MinimumSize = new System.Drawing.Size(1278, 678);
            this.Name = "Main";
            this.Text = "Welcome to Place Finder!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLaunch;
        private System.Windows.Forms.Label lblAppIntro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGoToPlacePg;
    }
}