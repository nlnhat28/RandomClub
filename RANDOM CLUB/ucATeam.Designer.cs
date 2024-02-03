namespace RANDOM_CLUB
{
    partial class ucATeam
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
            this.components = new System.ComponentModel.Container();
            this.txbFullName = new System.Windows.Forms.TextBox();
            this.cmsLogo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbShortName = new System.Windows.Forms.TextBox();
            this.eraserIcon = new System.Windows.Forms.PictureBox();
            this.exAsIcon = new System.Windows.Forms.PictureBox();
            this.exportIcon = new System.Windows.Forms.PictureBox();
            this.importIcon = new System.Windows.Forms.PictureBox();
            this.pbxBulb = new System.Windows.Forms.PictureBox();
            this.pbxATeam = new System.Windows.Forms.PictureBox();
            this.ttTool = new System.Windows.Forms.ToolTip(this.components);
            this.txbRegion = new System.Windows.Forms.TextBox();
            this.cmsLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eraserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAsIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBulb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxATeam)).BeginInit();
            this.SuspendLayout();
            // 
            // txbFullName
            // 
            this.txbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.Location = new System.Drawing.Point(43, 0);
            this.txbFullName.MaxLength = 20;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Size = new System.Drawing.Size(251, 33);
            this.txbFullName.TabIndex = 0;
            this.txbFullName.TextChanged += new System.EventHandler(this.txbFullName_TextChanged);
            // 
            // cmsLogo
            // 
            this.cmsLogo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsLogo.Name = "cmsATeam";
            this.cmsLogo.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::RANDOM_CLUB.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // txbShortName
            // 
            this.txbShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbShortName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbShortName.Location = new System.Drawing.Point(300, 0);
            this.txbShortName.MaxLength = 6;
            this.txbShortName.Name = "txbShortName";
            this.txbShortName.Size = new System.Drawing.Size(90, 33);
            this.txbShortName.TabIndex = 3;
            this.txbShortName.TextChanged += new System.EventHandler(this.txbShortName_TextChanged);
            // 
            // eraserIcon
            // 
            this.eraserIcon.BackColor = System.Drawing.Color.Transparent;
            this.eraserIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraserIcon.Image = global::RANDOM_CLUB.Properties.Resources.eraser_icon;
            this.eraserIcon.Location = new System.Drawing.Point(598, 3);
            this.eraserIcon.Name = "eraserIcon";
            this.eraserIcon.Size = new System.Drawing.Size(23, 24);
            this.eraserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eraserIcon.TabIndex = 8;
            this.eraserIcon.TabStop = false;
            this.ttTool.SetToolTip(this.eraserIcon, "Eraser");
            this.eraserIcon.Click += new System.EventHandler(this.eraserIcon_Click);
            this.eraserIcon.MouseLeave += new System.EventHandler(this.eraserIcon_MouseLeave);
            this.eraserIcon.MouseHover += new System.EventHandler(this.eraserIcon_MouseHover);
            // 
            // exAsIcon
            // 
            this.exAsIcon.BackColor = System.Drawing.Color.Transparent;
            this.exAsIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exAsIcon.Image = global::RANDOM_CLUB.Properties.Resources.export_as_icon;
            this.exAsIcon.Location = new System.Drawing.Point(569, 3);
            this.exAsIcon.Name = "exAsIcon";
            this.exAsIcon.Size = new System.Drawing.Size(23, 24);
            this.exAsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exAsIcon.TabIndex = 7;
            this.exAsIcon.TabStop = false;
            this.ttTool.SetToolTip(this.exAsIcon, "Export as");
            this.exAsIcon.Click += new System.EventHandler(this.exAsIcon_Click);
            this.exAsIcon.MouseLeave += new System.EventHandler(this.exAsIcon_MouseLeave);
            this.exAsIcon.MouseHover += new System.EventHandler(this.exAsIcon_MouseHover);
            // 
            // exportIcon
            // 
            this.exportIcon.BackColor = System.Drawing.Color.Transparent;
            this.exportIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportIcon.Image = global::RANDOM_CLUB.Properties.Resources.export_icon;
            this.exportIcon.Location = new System.Drawing.Point(540, 3);
            this.exportIcon.Name = "exportIcon";
            this.exportIcon.Size = new System.Drawing.Size(23, 24);
            this.exportIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exportIcon.TabIndex = 6;
            this.exportIcon.TabStop = false;
            this.ttTool.SetToolTip(this.exportIcon, "Export");
            this.exportIcon.Click += new System.EventHandler(this.exportIcon_Click);
            this.exportIcon.MouseLeave += new System.EventHandler(this.exportIcon_MouseLeave);
            this.exportIcon.MouseHover += new System.EventHandler(this.exportIcon_MouseHover);
            // 
            // importIcon
            // 
            this.importIcon.BackColor = System.Drawing.Color.Transparent;
            this.importIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importIcon.Image = global::RANDOM_CLUB.Properties.Resources.import_icon;
            this.importIcon.Location = new System.Drawing.Point(513, 3);
            this.importIcon.Name = "importIcon";
            this.importIcon.Size = new System.Drawing.Size(23, 24);
            this.importIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.importIcon.TabIndex = 5;
            this.importIcon.TabStop = false;
            this.ttTool.SetToolTip(this.importIcon, "Import");
            this.importIcon.Click += new System.EventHandler(this.importIcon_Click);
            this.importIcon.MouseLeave += new System.EventHandler(this.importIcon_MouseLeave);
            this.importIcon.MouseHover += new System.EventHandler(this.importIcon_MouseHover);
            // 
            // pbxBulb
            // 
            this.pbxBulb.BackColor = System.Drawing.Color.Transparent;
            this.pbxBulb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBulb.Image = global::RANDOM_CLUB.Properties.Resources.Bulb;
            this.pbxBulb.Location = new System.Drawing.Point(394, 2);
            this.pbxBulb.Name = "pbxBulb";
            this.pbxBulb.Size = new System.Drawing.Size(23, 24);
            this.pbxBulb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBulb.TabIndex = 4;
            this.pbxBulb.TabStop = false;
            this.ttTool.SetToolTip(this.pbxBulb, "Suggest a short name");
            this.pbxBulb.Click += new System.EventHandler(this.pbxBulb_Click);
            this.pbxBulb.MouseLeave += new System.EventHandler(this.pbxBulb_MouseLeave);
            this.pbxBulb.MouseHover += new System.EventHandler(this.pbxBulb_MouseHover);
            // 
            // pbxATeam
            // 
            this.pbxATeam.BackColor = System.Drawing.Color.Transparent;
            this.pbxATeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxATeam.ContextMenuStrip = this.cmsLogo;
            this.pbxATeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxATeam.Location = new System.Drawing.Point(5, 0);
            this.pbxATeam.Name = "pbxATeam";
            this.pbxATeam.Size = new System.Drawing.Size(32, 29);
            this.pbxATeam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxATeam.TabIndex = 1;
            this.pbxATeam.TabStop = false;
            this.pbxATeam.Click += new System.EventHandler(this.pbxATeam_Click);
            // 
            // ttTool
            // 
            this.ttTool.IsBalloon = true;
            // 
            // txbRegion
            // 
            this.txbRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRegion.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRegion.Location = new System.Drawing.Point(429, 0);
            this.txbRegion.MaxLength = 4;
            this.txbRegion.Name = "txbRegion";
            this.txbRegion.Size = new System.Drawing.Size(60, 33);
            this.txbRegion.TabIndex = 9;
            this.txbRegion.TextChanged += new System.EventHandler(this.txbRegion_TextChanged);
            // 
            // ucATeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txbRegion);
            this.Controls.Add(this.eraserIcon);
            this.Controls.Add(this.exAsIcon);
            this.Controls.Add(this.exportIcon);
            this.Controls.Add(this.importIcon);
            this.Controls.Add(this.pbxBulb);
            this.Controls.Add(this.txbShortName);
            this.Controls.Add(this.txbFullName);
            this.Controls.Add(this.pbxATeam);
            this.Name = "ucATeam";
            this.Size = new System.Drawing.Size(624, 36);
            this.cmsLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eraserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAsIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBulb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxATeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxATeam;
        private System.Windows.Forms.TextBox txbFullName;
        private System.Windows.Forms.ContextMenuStrip cmsLogo;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox txbShortName;
        private System.Windows.Forms.PictureBox pbxBulb;
        private System.Windows.Forms.PictureBox importIcon;
        private System.Windows.Forms.PictureBox exportIcon;
        private System.Windows.Forms.PictureBox exAsIcon;
        private System.Windows.Forms.PictureBox eraserIcon;
        private System.Windows.Forms.ToolTip ttTool;
        private System.Windows.Forms.TextBox txbRegion;
    }
}
