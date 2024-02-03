using System.Drawing;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class ucATeamInAGroup : UserControl
    {
        public ucATeamInAGroup()
        {
            InitializeComponent();
        }
        public void ShowInfo(TeamsInGroupsMode aTeam)
        {

            if (aTeam != null)
            {
                lbUnderLine.Visible = false;
                pbxLogo.Image = aTeam.Logo;

                if (string.IsNullOrEmpty(aTeam.Region)) lbName.Text = aTeam.ShortName;
                else lbName.Text = aTeam.ShortName + " ("+aTeam.Region+")";
            }
            else
            {
                pbxLogo.Image = null;
                lbName.Text = null;
                lbUnderLine.Visible = true;
            }
        }
        public bool IsNull()
        {
            if (lbUnderLine.Visible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowInfoFinalResult(TeamsInGroupsMode aTeam)
        {
            Size = new Size(276, 34);

            lbName.Font = new Font("Segoe UI", 14.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pbxLogo.Location = new Point(5, 1);
            lbName.Location = new Point(48, 0);

            if (aTeam != null)
            {
                lbUnderLine.Visible = false;
                pbxLogo.Image = aTeam.Logo;

                lbName.Text = aTeam.FullName;
            }
            else
            {
                pbxLogo.Image = null;
                lbName.Text = null;
                lbUnderLine.Visible = true;
            }
        }
    }
}
