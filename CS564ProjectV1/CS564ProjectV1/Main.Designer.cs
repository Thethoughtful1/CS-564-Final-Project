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
            this.SuspendLayout();
            // 
            // cmdLaunch
            // 
            this.cmdLaunch.Location = new System.Drawing.Point(610, 373);
            this.cmdLaunch.Name = "cmdLaunch";
            this.cmdLaunch.Size = new System.Drawing.Size(75, 23);
            this.cmdLaunch.TabIndex = 0;
            this.cmdLaunch.Text = "Lauch Tool";
            this.cmdLaunch.UseVisualStyleBackColor = true;
            this.cmdLaunch.Click += new System.EventHandler(this.cmdLaunch_Click);
            // 
            // lblAppIntro
            // 
            this.lblAppIntro.AutoSize = true;
            this.lblAppIntro.Location = new System.Drawing.Point(546, 303);
            this.lblAppIntro.Name = "lblAppIntro";
            this.lblAppIntro.Size = new System.Drawing.Size(202, 13);
            this.lblAppIntro.TabIndex = 1;
            this.lblAppIntro.Text = "<TO DO Description of App, instructions>";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.lblAppIntro);
            this.Controls.Add(this.cmdLaunch);
            this.MaximumSize = new System.Drawing.Size(1360, 768);
            this.MinimumSize = new System.Drawing.Size(1360, 768);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLaunch;
        private System.Windows.Forms.Label lblAppIntro;
    }
}