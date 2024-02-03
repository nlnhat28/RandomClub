using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RANDOM_CLUB
{
    public partial class ucATeam : UserControl
    {
        string FullName, ShortName;
        new string Region;
        Image Logo;
        string LogoLink, imLogoLink;
        string imFolderLink, exFolderLink;
        TeamsInGroupsMode aTeam;

        AutoCompleteStringCollection ListACSCTeams;
        AutoCompleteStringCollection ListACSCRegions;

        public ucATeam(TeamsInGroupsMode ATeam)
        {          
            InitializeComponent();
            aTeam = ATeam;
            ShowInfo();

            LoadAllACSCtxt();
            LoadAllACSC();        
        }
        void ShowInfo()
        {
            if (aTeam != null)
            {
                if (aTeam.IsDrawn == true) Enabled = false;
                else Enabled = true;

                if (aTeam.Logo != null)
                {
                    pbxATeam.Image = aTeam.Logo;
                    pbxATeam.BorderStyle = BorderStyle.None;
                }
                else pbxATeam.BorderStyle = BorderStyle.FixedSingle;

                txbFullName.Text = aTeam.FullName;
                txbShortName.Text = aTeam.ShortName;
                txbRegion.Text = aTeam.Region;
            }
            else
            {
                Enabled = true;
                pbxATeam.Image = null;
                pbxATeam.BorderStyle = BorderStyle.FixedSingle;
                txbFullName.Text = txbShortName.Text = txbRegion.Text = null;
            }
        }
        AutoCompleteStringCollection LoadACSCtxt(string LinkLoadACS)
        {
            AutoCompleteStringCollection ListACSC = new AutoCompleteStringCollection();
            if (File.Exists(LinkLoadACS))
            {
                FileStream fs = new FileStream(LinkLoadACS, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string str = sr.ReadLine();

                while (str != null)
                {
                    ListACSC.Add(str.Trim());
                    str = sr.ReadLine();
                }
                sr.Close();
                sr.Dispose();
                fs.Close();
            }
            return ListACSC;
        }
        //
        // ACSC - Load ACSC
        //
        void LoadACSC(TextBox Txb, AutoCompleteStringCollection ListACSC)
        {
            if (ListACSC.Count > 0)
            {
                Txb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Txb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                Txb.AutoCompleteCustomSource = ListACSC;
            }
        }
        void LoadAllACSCtxt()
        {
            ListACSCTeams = LoadACSCtxt(Application.StartupPath + "\\ACSCTeams.txt");
            ListACSCRegions = LoadACSCtxt(Application.StartupPath + "\\ACSCRegions.txt");
        }
        void LoadAllACSC()
        {
            LoadACSC(txbFullName, ListACSCTeams);
            LoadACSC(txbRegion, ListACSCRegions);
        }
        //
        // FULL NAME, SHORT NAME, REGION
        //
        private void txbFullName_TextChanged(object sender, EventArgs e)
        {
            FullName = txbFullName.Text;
        }

        private void txbShortName_TextChanged(object sender, EventArgs e)
        {
            ShortName = txbShortName.Text;
        }
        private void txbRegion_TextChanged(object sender, EventArgs e)
        {
            Region = txbRegion.Text;
        }
        //
        // IMPORT LOGO IMAGE
        //
        private void pbxATeam_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "All files|*.*|PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pbxATeam.Image = Logo = new Bitmap(pic.FileName);
                pbxATeam.BorderStyle = BorderStyle.None;

                LogoLink = pic.FileName;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoLink = null;
            pbxATeam.Image = null;
            pbxATeam.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbxBulb_Click(object sender, EventArgs e) 
        {
            if (txbFullName.Text.Length < 3)
            {
                txbShortName.Text = txbFullName.Text.Substring(0, txbFullName.Text.Length);
            }
            else txbShortName.Text = txbFullName.Text.Substring(0, 3);

        }
        //
        // IMPORT
        //
        void ImFunc(string imLink)
        {
            imFolderLink = imLink;
            Link.StartLinkImportTeam = imFolderLink;
            // Ip Logo
            if (File.Exists(imFolderLink + "\\Logo.png"))
            {
                LogoLink = imLogoLink = imFolderLink + "\\Logo.png";
                pbxATeam.Image = Logo = new Bitmap(imLogoLink);
                pbxATeam.BorderStyle = BorderStyle.None;
            }
            // Ip Name.txt
            if (File.Exists(imFolderLink + "\\Name.txt"))
            {
                FileStream fs = new FileStream(imFolderLink + "\\Name.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                txbFullName.Text = FullName = sr.ReadLine();
                txbShortName.Text = ShortName = sr.ReadLine();
                txbRegion.Text = Region = sr.ReadLine();

                sr.Dispose();
                sr.Close();
                fs.Dispose();
                fs.Close();
            }
            else
            {
                txbFullName.Text = FullName = null;
                txbShortName.Text = ShortName = null;
                txbRegion.Text = null;
            }
        }
        private void importIcon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the folder containing a file Name.txt";
            if (Directory.Exists(Link.StartLinkImportTeam)) fbd.SelectedPath = Link.StartLinkImportTeam;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Link.StartLinkImportTeam = fbd.SelectedPath.ToString();
                if (File.Exists(fbd.SelectedPath.ToString() + "\\Name.txt"))
                {
                    ImFunc(fbd.SelectedPath.ToString());
                }
                else
                {
                    MessageBox.Show("Valid folder must contain a file Name.txt and a image Logo.png", "Invalid folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        // EXPORT
        //
        void ExFunc(string exLink)
        {
            // Ex Logo
            if (File.Exists(LogoLink) && LogoLink != exLink + "\\Logo.png")
            {
                File.Copy(LogoLink, exLink + "\\Logo.png", true);
            }
            // Ex Name
            string NameTxtPath = exLink + "\\Name.txt";
            if (File.Exists(NameTxtPath))
            {
                File.WriteAllText(NameTxtPath, string.Empty);
            }

            FileStream fs = new FileStream(NameTxtPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(FullName + "\n" + ShortName + "\n" + Region);

            sw.Dispose();
            sw.Close();
            fs.Dispose();
            fs.Close();

            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ExAs()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the folder to contain the folder exported";
            if (Directory.Exists(Link.StartLinkExportTeam)) fbd.SelectedPath = Link.StartLinkExportTeam;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Link.StartLinkExportTeam = fbd.SelectedPath.ToString();
                string tmpExLink = fbd.SelectedPath.ToString() + "\\" + FullName;
                while (Directory.Exists(tmpExLink))
                {
                    tmpExLink = tmpExLink + " - Copy";
                }
                exFolderLink = tmpExLink;
                Directory.CreateDirectory(exFolderLink);

                ExFunc(exFolderLink);      
                ImFunc(exFolderLink);
            }
        }
        //
        // Export
        //
        private void exportIcon_Click(object sender, EventArgs e)
        {
            if (imFolderLink != null && Directory.Exists(imFolderLink))
            {
                exFolderLink = imFolderLink;
                ExFunc(exFolderLink);
            }
            else
            {
                ExAs();
            }
        }

        private void importIcon_MouseHover(object sender, EventArgs e)
        {
            importIcon.BackColor = Color.LightSkyBlue;
        }

        private void importIcon_MouseLeave(object sender, EventArgs e)
        {
            importIcon.BackColor = Color.Transparent;
        }
        private void exportIcon_MouseHover(object sender, EventArgs e)
        {
            exportIcon.BackColor = Color.LightSkyBlue;
        }
        private void exportIcon_MouseLeave(object sender, EventArgs e)
        {
            exportIcon.BackColor = Color.Transparent;
        }
        private void exAsIcon_MouseHover(object sender, EventArgs e)
        {
            exAsIcon.BackColor = Color.LightSkyBlue;
        }
        private void exAsIcon_MouseLeave(object sender, EventArgs e)
        {
            exAsIcon.BackColor = Color.Transparent;
        }
        private void eraserIcon_MouseHover(object sender, EventArgs e)
        {
            eraserIcon.BackColor = Color.Red;
        }
        private void eraserIcon_MouseLeave(object sender, EventArgs e)
        {
            eraserIcon.BackColor = Color.Transparent;
        }
        private void pbxBulb_MouseHover(object sender, EventArgs e)
        {
            pbxBulb.BackColor = Color.Moccasin;
        }
        private void pbxBulb_MouseLeave(object sender, EventArgs e)
        {
            pbxBulb.BackColor = Color.Transparent;
        }
        //
        // Export As
        //
        private void exAsIcon_Click(object sender, EventArgs e)
        {
            ExAs();
        }
        //
        // Eraser
        //
        private void eraserIcon_Click(object sender, EventArgs e)
        {
            txbFullName.Text = txbShortName.Text = txbRegion.Text = null;
            pbxATeam.Image = null;
            LogoLink = null;
            pbxATeam.BorderStyle = BorderStyle.FixedSingle;
        }
        //
        //
        //
        public TeamsInGroupsMode GetATeam()
        {
            TeamsInGroupsMode ATeam = new TeamsInGroupsMode();

            if (pbxATeam.Image == null && string.IsNullOrEmpty(txbFullName.Text)
                && string.IsNullOrEmpty(txbFullName.Text = null) && string.IsNullOrEmpty(txbRegion.Text = null))
            {
                return null;
            }
            else
            {
                if (aTeam != null)
                {
                    ATeam.IsDrawn = aTeam.IsDrawn;
                }
                ATeam.LogoLink = LogoLink;
                ATeam.Logo = pbxATeam.Image;
                ATeam.FullName = txbFullName.Text;
                ATeam.ShortName = txbShortName.Text;
                ATeam.Region = txbRegion.Text;

                return ATeam;
            }
        }
    }
}
