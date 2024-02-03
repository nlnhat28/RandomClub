namespace RANDOM_CLUB
{
    partial class ucATeamInDrawing
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
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lbShortName = new System.Windows.Forms.Label();
            this.ckbATeam = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.Location = new System.Drawing.Point(39, 4);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(40, 30);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // lbShortName
            // 
            this.lbShortName.AutoSize = true;
            this.lbShortName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShortName.ForeColor = System.Drawing.Color.Black;
            this.lbShortName.Location = new System.Drawing.Point(85, 4);
            this.lbShortName.Name = "lbShortName";
            this.lbShortName.Size = new System.Drawing.Size(108, 30);
            this.lbShortName.TabIndex = 1;
            this.lbShortName.Text = "MMMMM";
            this.lbShortName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbATeam
            // 
            this.ckbATeam.AutoSize = true;
            this.ckbATeam.Checked = true;
            this.ckbATeam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbATeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbATeam.Location = new System.Drawing.Point(18, 12);
            this.ckbATeam.Name = "ckbATeam";
            this.ckbATeam.Size = new System.Drawing.Size(15, 14);
            this.ckbATeam.TabIndex = 2;
            this.ckbATeam.UseVisualStyleBackColor = true;
            this.ckbATeam.CheckedChanged += new System.EventHandler(this.ckbATeam_CheckedChanged);
            // 
            // ucATeamInDrawing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.ckbATeam);
            this.Controls.Add(this.lbShortName);
            this.Controls.Add(this.pbxLogo);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucATeamInDrawing";
            this.Size = new System.Drawing.Size(209, 37);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lbShortName;
        private System.Windows.Forms.CheckBox ckbATeam;
    }
}
