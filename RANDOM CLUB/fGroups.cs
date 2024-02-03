using System;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fGroups : Form
    {
        int NumberOfPots;
        int NumberOfGroups;
        int NumberOfTeams;
        string TitlePot;
        int OTPot;
        string TitleGroup;
        int OTGroup;
        bool IsDelay;
        int DelayTime;
        string DropMode;

        public fGroups()
        {
            InitializeComponent();
        }
        //
        // Load Form
        //
        private void fGroups_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            Groups.CreateNew = false;

            nudNoPots.Value = NumberOfPots = Groups.NumberOfPots;
            nudNoGroups.Value = NumberOfGroups = Groups.NumberOfGroups;
            lbNoT.Text = "Numeber of teams: " + (nudNoPots.Value * nudNoGroups.Value).ToString();

            cbbTitlePot.Text = TitlePot = Groups.TitlePot;
            cbbOTPot.SelectedIndex = OTPot = Groups.OTPot;
            cbbOTGroup.SelectedIndex = OTGroup = Groups.OTGroup;
            cbbTitleGroup.Text = TitleGroup = Groups.TitleGroup;

            if (Groups.DropMode == "Random")
            {
                rbtnRandom.Checked = true;
                cbbSerial.Enabled = false;
            }
            else
            {
                cbbSerial.Enabled = true;
                rbtnSerial.Checked = true;

                if (Groups.DropMode == "RightToLeft")
                {
                    cbbSerial.SelectedIndex = 1;
                }
                else cbbSerial.SelectedIndex = 0;
            }
                

            if (Groups.IsDelay)
            {
                ckbDelay.Checked = true;
                nudDelayTime.Enabled = true;
            }
            else
            {
                ckbDelay.Checked = false;
                nudDelayTime.Enabled = false;
            }

            nudDelayTime.Value = Groups.DelayTime;


        }
        //
        // Load Cbb
        //
        void LoadCombobox()
        {
            string[] arrTitlePot = { "POT ", "TOP ", "NO.", "LEVEL ", "LIST " };
            string[] arrTitleGroup = { "GROUP ", "TABLE ", "LIST ", "RANGE "};
            string[] arrOTPot = { "1, 2, 3, ... ", "A, B, C, ... ", "I, II, III, ..." };
            string[] arrOTGroup = { "1, 2, 3, ... ", "A, B, C, ... ", "I, II, III, ..." };

            cbbTitlePot.DataSource = arrTitlePot;
            cbbTitlePot.SelectedIndex = 0;

            cbbOTPot.DataSource = arrOTPot;
            cbbOTPot.SelectedIndex = 0;

            cbbTitleGroup.DataSource = arrTitleGroup;
            cbbTitleGroup.SelectedIndex = 0;

            cbbOTGroup.DataSource = arrOTGroup;
            cbbOTGroup.SelectedIndex = 1;

            string[] arrSerial = { "LeftToRight", "RightToLeft" };
            cbbSerial.DataSource = arrSerial;
        }
        //
        // SET EXAMPLE POT
        //
        void SetlbExLabel(Label lbEx, string Title, int OT)
        {
            if (OT == 0) lbEx.Text = Title + "1, " + Title + "2, " + Title + "3, " + " ...";
            if (OT == 1) lbEx.Text = Title + "A, " + Title + "B, " + Title + "C, " + " ...";
            if (OT == 2) lbEx.Text = Title + "I, " + Title + "II, " + Title + "III, " + " ...";
        }
        //private void cbbTitlePot_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    //TitlePot = cbbTitlePot.SelectedValue.ToString();
        //    TitlePot = cbbTitlePot.GetItemText(cbbTitlePot.SelectedItem);
        //    SetlbExLabel(lbExPot, TitlePot, OTPot);
        //}
        private void cbbTitlePot_TextChanged(object sender, EventArgs e)
        {
            TitlePot = cbbTitlePot.Text;
            SetlbExLabel(lbExPot, TitlePot, OTPot);
        }
        private void cbbOTPot_SelectedIndexChanged(object sender, EventArgs e)
        {
            OTPot = cbbOTPot.SelectedIndex;
            SetlbExLabel(lbExPot, TitlePot, OTPot);
        }
        private void cbbTitleGroup_TextChanged(object sender, EventArgs e)
        {
            TitleGroup = cbbTitleGroup.Text;
            SetlbExLabel(lbExGroup, TitleGroup, OTGroup);
        }
        //private void cbbTitleGroup_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    TitleGroup = cbbTitleGroup.SelectedValue.ToString();
        //    SetlbExLabel(lbExGroup, TitleGroup, OTGroup);
        //}
        private void cbbOTGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            OTGroup = cbbOTGroup.SelectedIndex;
            SetlbExLabel(lbExGroup, TitleGroup, OTGroup);
        }
        //
        // Numeric Value Changed
        //  
        private void nudNoPots_ValueChanged(object sender, EventArgs e)
        {
            lbNoT.Text = "Numeber of teams: " + (nudNoPots.Value * nudNoGroups.Value).ToString();
        }
        private void nudNoGroups_ValueChanged(object sender, EventArgs e)
        {
            lbNoT.Text = "Numeber of teams: " + (nudNoPots.Value * nudNoGroups.Value).ToString();
        }
        //
        // DROP INTO GROUP SETTING
        //
        private void rbtnSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSerial.Checked)
            {
                cbbSerial.Enabled = true;
            }
            else
            {
                cbbSerial.Enabled = false;
            }
        }
        private void ckbDelay_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDelay.Checked) nudDelayTime.Enabled = true;
            else nudDelayTime.Enabled = false;
        }
        //
        // SAVE
        //
        void Save()
        {
            if (rbtnRandom.Checked) DropMode = "Random";
            else
            {
                if (cbbSerial.SelectedIndex == 0) DropMode = "LeftToRight";
                else DropMode = "RightToLeft";
            }

            if (ckbDelay.Checked)
            {
                IsDelay = true;
                DelayTime = Convert.ToInt32(nudDelayTime.Value);
            }
            else IsDelay = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Groups.TitlePot = TitlePot;
            Groups.TitleGroup = TitleGroup;

            Groups.OTPot = OTPot;
            Groups.OTGroup = OTGroup;

            Groups.ListTitlePot = Groups.ListTitleVsOT(Groups.TitlePot, Groups.GetNameArrOT(OTPot), NumberOfPots);
            Groups.ListTitleGroup = Groups.ListTitleVsOT(Groups.TitleGroup, Groups.GetNameArrOT(OTGroup), NumberOfGroups);

            Save();
            Groups.IsDelay = IsDelay;
            Groups.DelayTime = DelayTime;
            Groups.DropMode = DropMode;

            Groups.Save2 = true;

            fMode objMode = (fMode)Application.OpenForms["fMode"];
            if (objMode != null) objMode.Close();
           
            Close();
        }
        // 
        // NEXT
        //
        private void btnNext_Click(object sender, EventArgs e)
        {
            NumberOfPots = Convert.ToInt32(nudNoPots.Value);
            NumberOfGroups = Convert.ToInt32(nudNoGroups.Value);
            NumberOfTeams = NumberOfPots * NumberOfGroups;

            Save();

            fPots f = new fPots();
            f.NumberOfGroups = NumberOfGroups;
            f.NumberOfPots = NumberOfPots;
            f.NumberOfTeams = NumberOfTeams;
            f.TitlePot = TitlePot;
            f.OTPot = OTPot;
            f.TitleGroup = TitleGroup;
            f.OTGroup = OTGroup;
            f.IsDelay = IsDelay;
            f.DelayTime = DelayTime;
            f.DropMode = DropMode;
            f.ShowDialog();
        }
        //
        // BACK
        //
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
