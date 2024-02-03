using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fPots : Form
    {
        public int NumberOfPots { get; set; }
        public int NumberOfGroups { get; set; }
        public int NumberOfTeams { get; set; }

        public string TitlePot { get; set; }
        public int OTPot { get; set; }

        public string TitleGroup { get; set; }
        public int OTGroup { get; set; }

        public bool IsDelay { get; set; }
        public int DelayTime { get; set; }
        public string DropMode { get; set; }


        FlowLayoutPanel flpListOfTeams = new FlowLayoutPanel();
        TeamsInGroupsMode[,] arrPot;
        ucATeam[] arrUcATeam;

        List<string> ListTitlePot;

        public fPots()
        {
            InitializeComponent();
        }
        private void fPots_Load(object sender, EventArgs e)
        {
            arrPot = new TeamsInGroupsMode[NumberOfPots, NumberOfGroups];
            int MinNoPots = (NumberOfPots <= Groups.NumberOfPots) ? NumberOfPots : Groups.NumberOfPots;
            int MinNoGroups = (NumberOfGroups <= Groups.NumberOfGroups) ? NumberOfGroups : Groups.NumberOfGroups;
            if (Groups.ArrPot != null)
                for (int p = 0; p < MinNoPots; p++)
                    for (int t = 0; t < MinNoGroups; t++)
                        arrPot[p, t] = Groups.ArrPot[p, t];

            arrUcATeam = new ucATeam[NumberOfGroups];
            LoadCbbPot();

            Groups.CreateNew = Groups.Save = false;

            flpListOfTeams.AutoSize = true;
            flpListOfTeams.FlowDirection = FlowDirection.TopDown;
            pnlPot.Controls.Add(flpListOfTeams);            
            if (Drawing.Mode == "Groups" && Groups.GroupsIsShown && NumberOfPots == Groups.NumberOfPots && NumberOfGroups == Groups.NumberOfGroups)
                btnSave.Enabled = true;

            if (Groups.FindSameReg == true) ckbFindSameReg.Checked = true;
            else ckbFindSameReg.Checked = false;
        }
        //
        // Load combobox Pots 
        //
        void LoadCbbPot()
        {
            cbbPot.DataSource = ListTitlePot = Groups.ListTitleVsOT(TitlePot, Groups.GetNameArrOT(OTPot), NumberOfPots);
            cbbPot.SelectedIndex = 0;
        }
        //
        // Save To Pot
        //
        void SaveTeamsToPot(int indexPot)
        {
            for (int k = 0; k < NumberOfGroups; k++)
            {
                arrPot[indexPot,k] = arrUcATeam[k].GetATeam();
            }
        }
        private void cbbPot_MouseHover(object sender, EventArgs e)
        {
            SaveTeamsToPot(cbbPot.SelectedIndex);
        }
        private void btnCreate_MouseHover(object sender, EventArgs e)
        {
            SaveTeamsToPot(cbbPot.SelectedIndex);
        }
        //
        // Change Pot
        //
        void ShowTeamsInPot(int indexPot)
        {
            flpListOfTeams.Visible = false;

            flpListOfTeams.Controls.Clear();
            for (int k = 0; k < NumberOfGroups; k++)
            {
                ucATeam ATeam = new ucATeam(arrPot[indexPot, k]);
                flpListOfTeams.Controls.Add(ATeam);
                arrUcATeam[k] = ATeam;
            }
            flpListOfTeams.Visible = true;
        }
        private void cbbPot_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTeamsInPot(cbbPot.SelectedIndex);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        //
        // SAVE ALL
        //
        void Save()
        {
            Drawing.Mode = "Groups";

            Groups.NumberOfPots = NumberOfPots;
            Groups.NumberOfGroups = NumberOfGroups;
            Groups.NumberOfTeams = NumberOfTeams;

            Groups.TitlePot = TitlePot;
            Groups.TitleGroup = TitleGroup;

            Groups.OTPot = OTPot;
            Groups.OTGroup = OTGroup;

            Groups.ArrPot = new TeamsInGroupsMode[Groups.NumberOfPots, Groups.NumberOfPots];
            Groups.ArrPot = arrPot;
            Groups.ListTitlePot = ListTitlePot;

            Groups.ListTitleGroup = Groups.ListTitleVsOT(Groups.TitleGroup, Groups.GetNameArrOT(OTGroup), NumberOfGroups);

            Groups.IsDelay = IsDelay;
            Groups.DelayTime = DelayTime;
            Groups.DropMode = DropMode;

            if (ckbFindSameReg.Checked == true) Groups.FindSameReg = true;
            else Groups.FindSameReg = false;

            fMode objMode = (fMode)Application.OpenForms["fMode"];
            if (objMode != null) objMode.Close();

            fGroups objGroups = (fGroups)Application.OpenForms["fGroups"];
            if (objGroups != null) objGroups.Close();

            Close();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Groups.CreateNew = true;
            Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Groups.Save = true;
            Save();
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            SaveTeamsToPot(cbbPot.SelectedIndex);
        }
    }
}
