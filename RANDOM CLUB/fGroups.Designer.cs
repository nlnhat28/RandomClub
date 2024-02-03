namespace RANDOM_CLUB
{
    partial class fGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGroups));
            this.label1 = new System.Windows.Forms.Label();
            this.nudNoPots = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbTitlePot = new System.Windows.Forms.ComboBox();
            this.cbbOTPot = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbExPot = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbExGroup = new System.Windows.Forms.Label();
            this.nudNoGroups = new System.Windows.Forms.NumericUpDown();
            this.cbbOTGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbTitleGroup = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbNoT = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ttNudPots = new System.Windows.Forms.ToolTip(this.components);
            this.ttNudGroups = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbSerial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDelayTime = new System.Windows.Forms.NumericUpDown();
            this.ckbDelay = new System.Windows.Forms.CheckBox();
            this.rbtnRandom = new System.Windows.Forms.RadioButton();
            this.rbtnSerial = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoPots)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of pots:";
            // 
            // nudNoPots
            // 
            this.nudNoPots.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudNoPots.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoPots.Location = new System.Drawing.Point(170, 33);
            this.nudNoPots.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudNoPots.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoPots.Name = "nudNoPots";
            this.nudNoPots.Size = new System.Drawing.Size(120, 22);
            this.nudNoPots.TabIndex = 1;
            this.ttNudPots.SetToolTip(this.nudNoPots, "1 ÷ 8\r\n ");
            this.nudNoPots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoPots.ValueChanged += new System.EventHandler(this.nudNoPots_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Title:";
            // 
            // cbbTitlePot
            // 
            this.cbbTitlePot.AutoCompleteCustomSource.AddRange(new string[] {
            "POT",
            "SEED NO.",
            "LEVEL",
            "TOP",
            "LIST"});
            this.cbbTitlePot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTitlePot.FormattingEnabled = true;
            this.cbbTitlePot.Location = new System.Drawing.Point(169, 72);
            this.cbbTitlePot.Name = "cbbTitlePot";
            this.cbbTitlePot.Size = new System.Drawing.Size(121, 24);
            this.cbbTitlePot.TabIndex = 8;
            this.cbbTitlePot.TextChanged += new System.EventHandler(this.cbbTitlePot_TextChanged);
            // 
            // cbbOTPot
            // 
            this.cbbOTPot.AutoCompleteCustomSource.AddRange(new string[] {
            "1, 2, 3, ...",
            "A, B, C, ...",
            "I, II, III, ..."});
            this.cbbOTPot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbOTPot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOTPot.FormattingEnabled = true;
            this.cbbOTPot.Location = new System.Drawing.Point(169, 114);
            this.cbbOTPot.Name = "cbbOTPot";
            this.cbbOTPot.Size = new System.Drawing.Size(121, 24);
            this.cbbOTPot.TabIndex = 12;
            this.cbbOTPot.SelectedIndexChanged += new System.EventHandler(this.cbbOTPot_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Order type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbExPot);
            this.groupBox1.Controls.Add(this.nudNoPots);
            this.groupBox1.Controls.Add(this.cbbOTPot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbTitlePot);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 228);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "POT";
            // 
            // lbExPot
            // 
            this.lbExPot.AutoSize = true;
            this.lbExPot.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExPot.Location = new System.Drawing.Point(25, 179);
            this.lbExPot.Name = "lbExPot";
            this.lbExPot.Size = new System.Drawing.Size(43, 16);
            this.lbExPot.TabIndex = 13;
            this.lbExPot.Text = "label9";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbExGroup);
            this.groupBox2.Controls.Add(this.nudNoGroups);
            this.groupBox2.Controls.Add(this.cbbOTGroup);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbbTitleGroup);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(411, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 228);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GROUP";
            // 
            // lbExGroup
            // 
            this.lbExGroup.AutoSize = true;
            this.lbExGroup.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExGroup.Location = new System.Drawing.Point(25, 179);
            this.lbExGroup.Name = "lbExGroup";
            this.lbExGroup.Size = new System.Drawing.Size(43, 16);
            this.lbExGroup.TabIndex = 14;
            this.lbExGroup.Text = "label9";
            // 
            // nudNoGroups
            // 
            this.nudNoGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudNoGroups.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoGroups.Location = new System.Drawing.Point(170, 33);
            this.nudNoGroups.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudNoGroups.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoGroups.Name = "nudNoGroups";
            this.nudNoGroups.Size = new System.Drawing.Size(120, 22);
            this.nudNoGroups.TabIndex = 1;
            this.ttNudGroups.SetToolTip(this.nudNoGroups, "1 ÷ 12");
            this.nudNoGroups.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoGroups.ValueChanged += new System.EventHandler(this.nudNoGroups_ValueChanged);
            // 
            // cbbOTGroup
            // 
            this.cbbOTGroup.AutoCompleteCustomSource.AddRange(new string[] {
            "1, 2, 3, ...",
            "A, B, C, ...",
            "I, II, III, ..."});
            this.cbbOTGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbOTGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOTGroup.FormattingEnabled = true;
            this.cbbOTGroup.Location = new System.Drawing.Point(170, 114);
            this.cbbOTGroup.Name = "cbbOTGroup";
            this.cbbOTGroup.Size = new System.Drawing.Size(120, 24);
            this.cbbOTGroup.TabIndex = 12;
            this.cbbOTGroup.SelectedIndexChanged += new System.EventHandler(this.cbbOTGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of groups";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Order type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Title:";
            // 
            // cbbTitleGroup
            // 
            this.cbbTitleGroup.AutoCompleteCustomSource.AddRange(new string[] {
            "POT",
            "SEED NO.",
            "LEVEL",
            "TOP",
            "LIST"});
            this.cbbTitleGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbTitleGroup.FormattingEnabled = true;
            this.cbbTitleGroup.Location = new System.Drawing.Point(170, 72);
            this.cbbTitleGroup.Name = "cbbTitleGroup";
            this.cbbTitleGroup.Size = new System.Drawing.Size(120, 24);
            this.cbbTitleGroup.TabIndex = 8;
            this.cbbTitleGroup.TextChanged += new System.EventHandler(this.cbbTitleGroup_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(648, 492);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 33);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(32, 492);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 33);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbNoT
            // 
            this.lbNoT.AutoSize = true;
            this.lbNoT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoT.Location = new System.Drawing.Point(28, 25);
            this.lbNoT.Name = "lbNoT";
            this.lbNoT.Size = new System.Drawing.Size(145, 19);
            this.lbNoT.TabIndex = 17;
            this.lbNoT.Text = "Number of teams:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::RANDOM_CLUB.Properties.Resources.Groups_icon_02;
            this.pictureBox2.Location = new System.Drawing.Point(340, 450);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbSerial);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudDelayTime);
            this.groupBox3.Controls.Add(this.ckbDelay);
            this.groupBox3.Controls.Add(this.rbtnRandom);
            this.groupBox3.Controls.Add(this.rbtnSerial);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(32, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 109);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DROP INTO GROUP";
            // 
            // cbbSerial
            // 
            this.cbbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSerial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSerial.FormattingEnabled = true;
            this.cbbSerial.Items.AddRange(new object[] {
            "LeftToRight",
            "RightToLeft"});
            this.cbbSerial.Location = new System.Drawing.Point(145, 59);
            this.cbbSerial.Name = "cbbSerial";
            this.cbbSerial.Size = new System.Drawing.Size(172, 24);
            this.cbbSerial.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time(ms) :";
            // 
            // nudDelayTime
            // 
            this.nudDelayTime.Enabled = false;
            this.nudDelayTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDelayTime.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudDelayTime.Location = new System.Drawing.Point(597, 35);
            this.nudDelayTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDelayTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudDelayTime.Name = "nudDelayTime";
            this.nudDelayTime.Size = new System.Drawing.Size(68, 22);
            this.nudDelayTime.TabIndex = 3;
            this.nudDelayTime.ThousandsSeparator = true;
            this.nudDelayTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ckbDelay
            // 
            this.ckbDelay.AutoSize = true;
            this.ckbDelay.Checked = true;
            this.ckbDelay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDelay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDelay.Location = new System.Drawing.Point(403, 36);
            this.ckbDelay.Name = "ckbDelay";
            this.ckbDelay.Size = new System.Drawing.Size(95, 20);
            this.ckbDelay.TabIndex = 2;
            this.ckbDelay.Text = "Delay effect";
            this.ckbDelay.UseVisualStyleBackColor = true;
            this.ckbDelay.CheckedChanged += new System.EventHandler(this.ckbDelay_CheckedChanged);
            // 
            // rbtnRandom
            // 
            this.rbtnRandom.AutoSize = true;
            this.rbtnRandom.Checked = true;
            this.rbtnRandom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRandom.Location = new System.Drawing.Point(60, 34);
            this.rbtnRandom.Name = "rbtnRandom";
            this.rbtnRandom.Size = new System.Drawing.Size(74, 20);
            this.rbtnRandom.TabIndex = 1;
            this.rbtnRandom.TabStop = true;
            this.rbtnRandom.Text = "Random";
            this.rbtnRandom.UseVisualStyleBackColor = true;
            // 
            // rbtnSerial
            // 
            this.rbtnSerial.AutoSize = true;
            this.rbtnSerial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSerial.Location = new System.Drawing.Point(60, 63);
            this.rbtnSerial.Name = "rbtnSerial";
            this.rbtnSerial.Size = new System.Drawing.Size(59, 20);
            this.rbtnSerial.TabIndex = 0;
            this.rbtnSerial.Text = "Serial";
            this.rbtnSerial.UseVisualStyleBackColor = true;
            this.rbtnSerial.CheckedChanged += new System.EventHandler(this.rbtnSerial_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(562, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 548);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbNoT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GROUPS MODE SETTING";
            this.Load += new System.EventHandler(this.fGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNoPots)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNoPots;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbTitlePot;
        private System.Windows.Forms.ComboBox cbbOTPot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudNoGroups;
        private System.Windows.Forms.ComboBox cbbOTGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbTitleGroup;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbExPot;
        private System.Windows.Forms.Label lbExGroup;
        private System.Windows.Forms.Label lbNoT;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip ttNudPots;
        private System.Windows.Forms.ToolTip ttNudGroups;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDelayTime;
        private System.Windows.Forms.CheckBox ckbDelay;
        private System.Windows.Forms.RadioButton rbtnRandom;
        private System.Windows.Forms.RadioButton rbtnSerial;
        private System.Windows.Forms.Button btnSave;
    }
}