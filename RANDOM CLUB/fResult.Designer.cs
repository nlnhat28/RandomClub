namespace RANDOM_CLUB
{
    partial class fResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fResult));
            this.lbNameOfLeague = new System.Windows.Forms.Label();
            this.lbFullName = new System.Windows.Forms.Label();
            this.pbxLogoTeam = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxLogoOfLeague = new System.Windows.Forms.PictureBox();
            this.lbDelay = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbDrop = new System.Windows.Forms.Label();
            this.lbShortName = new System.Windows.Forms.Label();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoTeam)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoOfLeague)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNameOfLeague
            // 
            this.lbNameOfLeague.BackColor = System.Drawing.Color.Transparent;
            this.lbNameOfLeague.Font = new System.Drawing.Font("UTM Penumbra", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameOfLeague.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbNameOfLeague.Location = new System.Drawing.Point(119, 3);
            this.lbNameOfLeague.Name = "lbNameOfLeague";
            this.lbNameOfLeague.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNameOfLeague.Size = new System.Drawing.Size(500, 35);
            this.lbNameOfLeague.TabIndex = 1;
            this.lbNameOfLeague.Text = "NAME OF LEAGUE";
            this.lbNameOfLeague.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFullName
            // 
            this.lbFullName.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.Location = new System.Drawing.Point(3, 218);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(616, 60);
            this.lbFullName.TabIndex = 2;
            this.lbFullName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pbxLogoTeam
            // 
            this.pbxLogoTeam.Location = new System.Drawing.Point(119, 60);
            this.pbxLogoTeam.Name = "pbxLogoTeam";
            this.pbxLogoTeam.Size = new System.Drawing.Size(383, 155);
            this.pbxLogoTeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogoTeam.TabIndex = 3;
            this.pbxLogoTeam.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.pbxLogoOfLeague);
            this.panel1.Controls.Add(this.lbDelay);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lbDrop);
            this.panel1.Controls.Add(this.lbNameOfLeague);
            this.panel1.Controls.Add(this.lbShortName);
            this.panel1.Controls.Add(this.pbxLogoTeam);
            this.panel1.Controls.Add(this.lbFullName);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 347);
            this.panel1.TabIndex = 4;
            // 
            // pbxLogoOfLeague
            // 
            this.pbxLogoOfLeague.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogoOfLeague.Location = new System.Drawing.Point(3, 3);
            this.pbxLogoOfLeague.Name = "pbxLogoOfLeague";
            this.pbxLogoOfLeague.Size = new System.Drawing.Size(110, 87);
            this.pbxLogoOfLeague.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogoOfLeague.TabIndex = 5;
            this.pbxLogoOfLeague.TabStop = false;
            // 
            // lbDelay
            // 
            this.lbDelay.Location = new System.Drawing.Point(3, 60);
            this.lbDelay.Name = "lbDelay";
            this.lbDelay.Size = new System.Drawing.Size(633, 263);
            this.lbDelay.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(250, 162);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(139, 31);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // lbDrop
            // 
            this.lbDrop.AutoSize = true;
            this.lbDrop.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.lbDrop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDrop.Location = new System.Drawing.Point(578, 323);
            this.lbDrop.Name = "lbDrop";
            this.lbDrop.Size = new System.Drawing.Size(54, 18);
            this.lbDrop.TabIndex = 6;
            this.lbDrop.Text = "Drop▽";
            this.lbDrop.Click += new System.EventHandler(this.lbDrop_Click);
            this.lbDrop.MouseLeave += new System.EventHandler(this.lbDrop_MouseLeave);
            this.lbDrop.MouseHover += new System.EventHandler(this.lbDrop_MouseHover);
            // 
            // lbShortName
            // 
            this.lbShortName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShortName.Location = new System.Drawing.Point(3, 274);
            this.lbShortName.Name = "lbShortName";
            this.lbShortName.Size = new System.Drawing.Size(616, 34);
            this.lbShortName.TabIndex = 4;
            this.lbShortName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrDelay
            // 
            this.tmrDelay.Interval = 25;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // fResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(645, 350);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESULT";
            this.Load += new System.EventHandler(this.fResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoTeam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoOfLeague)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbNameOfLeague;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.PictureBox pbxLogoTeam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbShortName;
        private System.Windows.Forms.PictureBox pbxLogoOfLeague;
        private System.Windows.Forms.Label lbDrop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbDelay;
        private System.Windows.Forms.Timer tmrDelay;
    }
}