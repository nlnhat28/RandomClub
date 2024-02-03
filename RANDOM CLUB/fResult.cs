using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fResult : Form
    {
        int step;
        int X;

        public string NameOfLeague { get; set; }

        TeamsInGroupsMode aTeam;
        public fResult(TeamsInGroupsMode ATeam)
        {
            InitializeComponent();
            aTeam = ATeam;
        }
        async void Delay(int time)
        {
            await Task.Delay(time);

            if (aTeam.Logo != null) pbxLogoTeam.Image = aTeam.Logo;
            lbFullName.Text = aTeam.FullName;
            if (string.IsNullOrEmpty(aTeam.Region)) lbShortName.Text = aTeam.ShortName;
            else lbShortName.Text = aTeam.ShortName + " (" + aTeam.Region + ")";
        }
        void DelayOpen()
        {

        }
        private void fResult_Load(object sender, EventArgs e)
        {
            //if (BGI != null) BackgroundImage = BGI;
            //else BackColor = BGC;


            if (Drawing.LGI != null && !Drawing.LogoIsHide) pbxLogoOfLeague.Image = Drawing.LGI;
            lbNameOfLeague.Text = NameOfLeague;
            
            if (aTeam.Logo != null) pbxLogoTeam.Image = aTeam.Logo;
            lbFullName.Text = aTeam.FullName;
            if (string.IsNullOrEmpty(aTeam.Region)) lbShortName.Text = aTeam.ShortName;
            else lbShortName.Text = aTeam.ShortName + " (" + aTeam.Region + ")";

            if (Groups.IsDelay)
            {
                lbDelay.Visible = true;
                X = 3;
                step = Convert.ToInt32(Math.Truncate(630.0 * tmrDelay.Interval / Groups.DelayTime));
                tmrDelay.Start();
            }
            else
            {
                lbDelay.Visible = false;
            }
        }
        //
        // DROP TO GROUPS
        //
        private void lbDrop_MouseHover(object sender, EventArgs e)
        {
            lbDrop.ForeColor = Color.Blue;
            lbDrop.Text = "Drop ▼";
        }

        private void lbDrop_MouseLeave(object sender, EventArgs e)
        {
            lbDrop.ForeColor = Color.Black;
            lbDrop.Text = "Drop ▽";
        }

        // DropFunc
        public delegate void MyHandler();
        public event MyHandler MyEventHandler;

        private void lbDrop_Click(object sender, EventArgs e)
        {
            MyEventHandler?.Invoke();
        }

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            if (X < 630)
            {
                X += step;
                lbDelay.Location = new Point(X, lbDelay.Location.Y);
            }
            else tmrDelay.Stop();
        }
    }
}
