using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fFinalResult : Form
    {
        int SizeYUcAGroup;
        public string imFolderLink { get; set; }

        public fFinalResult()
        {
            InitializeComponent();

            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            CreateFinalGroups();
            ShowInfo();

            if (Drawing.BGIsImage && Drawing.BGI != null) BackgroundImage = Drawing.BGI;
            else
            {
                if (Drawing.BGC != null) BackColor = Drawing.BGC;
                else BackColor = Drawing.DefaultColor;
            }
        }
        void ShowInfo()
        {
            lbTitle.Text = Drawing.Title;
            lbPlaceDate.Text = Drawing.PlaceDate;
            lbTextBox.Text = "FINAL RESULT";


            if (Drawing.LGI != null && !Drawing.LogoIsHide)
            {
                pbxLogo.Image = Drawing.LGI;
            }

        }

        void AlignFlpFR1(int NoG1)
        {
            int x = 34 + (6 - NoG1) * 154;
            int y = 400 - SizeYUcAGroup / 2 + 34;
            flpGroupsFR1.Location = new Point(x, y);
        }
        void AlignFlpFR2(int NoG2)
        {
            int x = 34 + (6 - NoG2) * 154;
            int y = 740 - SizeYUcAGroup / 2 + 34;
            flpGroupsFR2.Location = new Point(x, y);
        }
        void AddToFlpFR1(int NoG1)
        {
            for (int g = 0; g < NoG1; g++)
            {
                ucAGroup ucAG = new ucAGroup();
                ucAG.Size = new Size(276, 42 + 34 * Groups.NumberOfPots + 2);
                ucAG.ShowFinalResult(Groups.ListTitleGroup[g]);
                for (int t = 0; t < Groups.NumberOfPots; t++)
                {
                    ucAG.AddATeamFinalResult(Groups.ArrGroup[g, t]);
                }
                flpGroupsFR1.Controls.Add(ucAG);
            }
        }
        void AddToFlpFR2(int NoG2, int NoG1)
        {
            for (int g = NoG1; g < Groups.NumberOfGroups; g++)
            {
                ucAGroup ucAG = new ucAGroup();
                ucAG.Size = new Size(276, 42 + 34 * Groups.NumberOfPots + 2);
                ucAG.ShowFinalResult(Groups.ListTitleGroup[g]);
                for (int t = 0; t < Groups.NumberOfPots; t++)
                {
                    ucAG.AddATeamFinalResult(Groups.ArrGroup[g, t]);
                }
                flpGroupsFR2.Controls.Add(ucAG);
            }
        }
        void CreateFinalGroups()
        {
            SizeYUcAGroup = 42 + 34 * Groups.NumberOfPots + 2 + 24;

            if (Groups.NumberOfGroups < 7)
            {
                int x = 39 + (6 - Groups.NumberOfGroups) * 154;
                int y = 570 - SizeYUcAGroup / 2 + 34;
                flpGroupsFR1.Location = new Point(x, y);

            }
            else
            {
                if (Groups.NumberOfGroups % 2 == 0)
                {
                    AlignFlpFR1(Groups.NumberOfGroups / 2);
                    AlignFlpFR2(Groups.NumberOfGroups / 2);
                }
                else
                {
                    AlignFlpFR1((Groups.NumberOfGroups + 1) / 2);
                    AlignFlpFR2((Groups.NumberOfGroups - 1) / 2);
                }
            }

            if (Groups.NumberOfGroups < 7)
            {
                AddToFlpFR1(Groups.NumberOfGroups);
                flpGroupsFR1.Visible = true;
            }
            else
            {
                if (Groups.NumberOfGroups % 2 == 0)
                {
                    AddToFlpFR1(Groups.NumberOfGroups / 2);
                    AddToFlpFR2(Groups.NumberOfGroups / 2, Groups.NumberOfGroups / 2);
                }
                else
                {
                    AddToFlpFR1((Groups.NumberOfGroups + 1) / 2);
                    AddToFlpFR2((Groups.NumberOfGroups - 1) / 2, (Groups.NumberOfGroups + 1) / 2);
                }

                flpGroupsFR1.Visible = flpGroupsFR2.Visible = true;
            }
        }
        private void fFinalResult_Load(object sender, EventArgs e)
        {

        }

        private void lbBack_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void lbBack_MouseLeave(object sender, EventArgs e)
        {
            lbBack.ForeColor = Color.Blue;
        }

        private void lbBack_MouseHover(object sender, EventArgs e)
        {
            lbBack.ForeColor = Color.White;
        }

        private void lbCapture_MouseHover(object sender, EventArgs e)
        {

            lbCapture.ForeColor = Color.White;
        }

        private void lbCapture_MouseLeave(object sender, EventArgs e)
        {
            lbCapture.ForeColor = Color.Blue;
        }

        private void lbCapture_Click(object sender, EventArgs e)
        {
            fExportResult f = new fExportResult();

            f.ShowDialog();

            Groups.Delay(1000);
            if (f.ExportPicture) ExportPicture(f.ExLink);

        }

        void ExportPicture(string SaveLink)
        {
            Rectangle bounds = Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(SaveLink, ImageFormat.Png);
            }
            MessageBox.Show("Image was saved at the link: " + SaveLink, "Screenshot successful!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

