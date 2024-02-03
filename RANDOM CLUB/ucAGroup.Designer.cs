namespace RANDOM_CLUB
{
    partial class ucAGroup
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
            this.lbTitleGroup = new System.Windows.Forms.Label();
            this.pnlTitleGroup = new System.Windows.Forms.Panel();
            this.ckb = new System.Windows.Forms.CheckBox();
            this.flpTeamInAGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitleGroup
            // 
            this.lbTitleGroup.AutoSize = true;
            this.lbTitleGroup.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleGroup.Font = new System.Drawing.Font("Futura Md BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbTitleGroup.Location = new System.Drawing.Point(22, 3);
            this.lbTitleGroup.Name = "lbTitleGroup";
            this.lbTitleGroup.Size = new System.Drawing.Size(109, 32);
            this.lbTitleGroup.TabIndex = 0;
            this.lbTitleGroup.Text = "GROUP";
            this.lbTitleGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTitleGroup
            // 
            this.pnlTitleGroup.BackColor = System.Drawing.Color.Blue;
            this.pnlTitleGroup.Controls.Add(this.ckb);
            this.pnlTitleGroup.Controls.Add(this.lbTitleGroup);
            this.pnlTitleGroup.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleGroup.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitleGroup.Name = "pnlTitleGroup";
            this.pnlTitleGroup.Size = new System.Drawing.Size(226, 38);
            this.pnlTitleGroup.TabIndex = 1;
            // 
            // ckb
            // 
            this.ckb.AutoSize = true;
            this.ckb.Checked = true;
            this.ckb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb.Location = new System.Drawing.Point(8, 12);
            this.ckb.Name = "ckb";
            this.ckb.Size = new System.Drawing.Size(15, 14);
            this.ckb.TabIndex = 1;
            this.ckb.UseVisualStyleBackColor = true;
            this.ckb.CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
            // 
            // flpTeamInAGroup
            // 
            this.flpTeamInAGroup.AutoSize = true;
            this.flpTeamInAGroup.BackColor = System.Drawing.Color.Transparent;
            this.flpTeamInAGroup.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTeamInAGroup.Location = new System.Drawing.Point(0, 42);
            this.flpTeamInAGroup.Margin = new System.Windows.Forms.Padding(0);
            this.flpTeamInAGroup.Name = "flpTeamInAGroup";
            this.flpTeamInAGroup.Size = new System.Drawing.Size(226, 10);
            this.flpTeamInAGroup.TabIndex = 2;
            // 
            // ucAGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.flpTeamInAGroup);
            this.Controls.Add(this.pnlTitleGroup);
            this.Margin = new System.Windows.Forms.Padding(12);
            this.Name = "ucAGroup";
            this.Size = new System.Drawing.Size(226, 316);
            this.pnlTitleGroup.ResumeLayout(false);
            this.pnlTitleGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitleGroup;
        private System.Windows.Forms.Panel pnlTitleGroup;
        private System.Windows.Forms.CheckBox ckb;
        private System.Windows.Forms.FlowLayoutPanel flpTeamInAGroup;
    }
}
