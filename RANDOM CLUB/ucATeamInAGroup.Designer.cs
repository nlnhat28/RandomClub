namespace RANDOM_CLUB
{
    partial class ucATeamInAGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lbUnderLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(48, 1);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(69, 30);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "TEAM";
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(5, 1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(40, 30);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // lbUnderLine
            // 
            this.lbUnderLine.AutoSize = true;
            this.lbUnderLine.BackColor = System.Drawing.Color.Transparent;
            this.lbUnderLine.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnderLine.Location = new System.Drawing.Point(52, 7);
            this.lbUnderLine.Name = "lbUnderLine";
            this.lbUnderLine.Size = new System.Drawing.Size(148, 13);
            this.lbUnderLine.TabIndex = 2;
            this.lbUnderLine.Text = "                                               ";
            // 
            // ucATeamInAGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbUnderLine);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbxLogo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucATeamInAGroup";
            this.Size = new System.Drawing.Size(226, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbUnderLine;
    }
}
