using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class ucATeamInDrawing : UserControl
    {
        TeamsInGroupsMode aTeam;
        public bool IsChecked = true;

        public ucATeamInDrawing(TeamsInGroupsMode ATeam)
        {
            InitializeComponent();
            aTeam = ATeam;
            ShowInfo();
        }

        void ShowInfo()
        {
            if (aTeam != null)
            {
                if (aTeam.IsDrawn == true)
                {
                    Enabled = false;
                }
                else Enabled = true;

                if (aTeam.Logo != null)
                {
                    pbxLogo.Image = aTeam.Logo;
                    pbxLogo.BorderStyle = BorderStyle.None;
                }
                else pbxLogo.BorderStyle = BorderStyle.FixedSingle;

                if (string.IsNullOrEmpty(aTeam.Region)) lbShortName.Text = aTeam.ShortName;
                else lbShortName.Text = aTeam.ShortName + " (" + aTeam.Region + ")";          
            }
            else
            {
                pbxLogo.Image = null;
                pbxLogo.BorderStyle = BorderStyle.FixedSingle;
                lbShortName.Text = null;
            }
            
        }

        private void ckbATeam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbATeam.Checked)
            {
                lbShortName.Enabled = true;
                IsChecked = true;
            }
            else
            {
                lbShortName.Enabled = false;
                IsChecked = false;
            }
        }
    }
}
