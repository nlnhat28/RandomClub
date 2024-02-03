using System;
using System.Drawing;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class ucAGroup : UserControl
    {
        public bool IsChecked = true;

        public ucAGroup()
        {
            InitializeComponent();
        }
        public void SetTittleGroup(string TitleGroup)
        {
            lbTitleGroup.Text = TitleGroup;
        }
        public void Add(int NumberOfTeamsInGroup, int indexGroup)
        {
            for (int t = 0; t < NumberOfTeamsInGroup; t++)
            {
                ucATeamInAGroup uc = new ucATeamInAGroup();
                uc.ShowInfo(null);
                flpTeamInAGroup.Controls.Add(uc);
                fMain.arrUcTeamInGroups[indexGroup, t] = uc;
            }
        }
        public void UncheckBox()
        {
            ckb.Checked = false;
        }
        public void CheckBox()
        {
            ckb.Checked = true;
        }
        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb.Checked)
            {
                lbTitleGroup.Enabled = true;
                pnlTitleGroup.BackColor = Color.Blue;
                IsChecked = true;
            }
            else
            {
                lbTitleGroup.Enabled = false;
                pnlTitleGroup.BackColor = Color.Lavender;
                IsChecked = false;
            }
        }
        public void RedPanel()
        {
            pnlTitleGroup.BackColor = Color.Red;
        }

        public void BluePanel()
        { 
            pnlTitleGroup.BackColor = Color.Blue;
        }

        public void MaroonPanel()
        {
            pnlTitleGroup.BackColor = Color.Maroon;
        }
        //
        // Final Result
        //
        public void ShowFinalResult(string Title)
        {
            lbTitleGroup.Text = Title;
            lbTitleGroup.Location = new Point(8, 3);

            pnlTitleGroup.Size = new Size(276, 38);
            ckb.Visible = false;
            Margin = new Padding(16, 12, 16, 12);
        }

        public void AddATeamFinalResult(TeamsInGroupsMode ATeam)
        {
            ucATeamInAGroup uc = new ucATeamInAGroup();
            uc.ShowInfoFinalResult(ATeam);
            flpTeamInAGroup.Controls.Add(uc);
        }
    }
}
