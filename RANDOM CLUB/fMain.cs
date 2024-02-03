using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace RANDOM_CLUB
{
    public partial class fMain : Form
    {
        List<string> ListRePj;
        AutoCompleteStringCollection ListACSCTitle;
        AutoCompleteStringCollection ListACSCPlaceDate;
        AutoCompleteStringCollection ListACSCNOL;
        AutoCompleteStringCollection ListACSCGrt;


        string LogoPath, BGIPath, imLogoPath, imBGIPath;
        string[] SpsLPath = new string[5];
        string[] imSpsLPath = new string[5];
        //int idSps;
        string exFolderLink, imFolderLink;
        string imPrTxt, exPrTxt;
        string NameofLeague, Greeting;
        bool SthChanged, SettingChanged, exPorted;
        string BGSetting, LGSetting;
        string[] SpsLSetting = new string[5];
        string SumSpsLSetting = null;

        bool LogoIsDeleted, BGIIsDeleted;
        bool[] SpsLIsDeleted = new bool[5];

        ucATeamInDrawing[] arrUcATeamInDrawing;
        public static ucATeamInAGroup[,] arrUcTeamInGroups;

        ucAGroup[] arrUcGroup;

        TeamsInGroupsMode TeamHasDrawn;
        int IndexPotHasDrawn;
        int IndexTeamHasDrawn;
        //int col;

        int OldIdCbbPot = 0;

        int SizeYUcAGroup;

        bool FullScreen = false;
        bool MenuIsHide = false;
        

        public fMain()
        {
            InitializeComponent();
        }
        //
        //
        //
        void Test()
        {
            label1.Visible = false;
            timer1.Start();
            label1.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        //
        //
        //
        private void fMain_Load(object sender, EventArgs e)
        {
            

            lbTitle.Text = Drawing.Title = "*TITLE*";
            lbPlaceDate.Text = Drawing.PlaceDate = "*PLACE, DATE*";
            NameofLeague = "*NAME OF LEAGUE*";
            lbTextBox.Text = Greeting = "Welcome";


            cbbSponsors.SelectedIndex = 0;
            btnDraw.Enabled = false;


            SetBGColor.Checked = true;

            Drawing.BGC = Drawing.DefaultColor = Color.MidnightBlue;

            LoadRePjtxt();

            LoadAllACSCtxt();

            imPrTxt =
                "<Begin>\n" +
                "Drawing.Title=*TITLE*\n" +
                "Place, Date=*PLACE, DATE*\n" +
                "Name of league=*NAME OF LEAGUE*\n" +
                "Greeting=Welcome\n" +
                "Background=MidnightBlue\n" +
                "Logo of league=NULL\n" +
                "Sponsor logos=NULL,NULL,NULL,NULL,NULL\n" +
                "<End>";

            LogoIsDeleted = BGIIsDeleted = false;
            for (int i = 0; i < 5; i++) SpsLIsDeleted[i] = false;

            //
            // MODE
            //
            SthChanged = false;
        }
        //
        //
        //
        void AlignTitle(bool LogoIsNull)
        {
            if (LogoIsNull)
            {
                pnlTitle.Size = new Size(1848, 175);
                pnlTitle.Location = new Point(39, 44);
            }
            else // LogoIsNotNull
            {
                pnlTitle.Size = new Size(1576, 175);
                pnlTitle.Location = new Point(305, 44);
            }
        }
        //
        // AutoComplete Textbox
        //
        //
        // ACSC - Load file txt
        //
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
                    ListACSC.Add(str);
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
        void LoadACSC(ToolStripTextBox toolStripTxb, AutoCompleteStringCollection ListACSC)
        {
            if (ListACSC.Count > 0)
            {
                toolStripTxb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                toolStripTxb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                toolStripTxb.AutoCompleteCustomSource = ListACSC;
            }
        }
        void LoadAllACSCtxt()
        {
            ListACSCTitle = LoadACSCtxt(Application.StartupPath + "\\ACSCTitle.txt");
            ListACSCPlaceDate = LoadACSCtxt(Application.StartupPath + "\\ACSCPlaceDate.txt");
            ListACSCNOL = LoadACSCtxt(Application.StartupPath + "\\ACSCNameOfLeague.txt");
            ListACSCGrt = LoadACSCtxt(Application.StartupPath + "\\ACSCGreeting.txt");
        }
        void LoadAllACSC()
        {
            LoadACSC(txbTitle, ListACSCTitle);
            LoadACSC(txbPlaceDate, ListACSCPlaceDate);
            LoadACSC(txbNameOfLeague, ListACSCNOL);
            LoadACSC(txbGreeting, ListACSCGrt);
        }
        //
        // ACSC - Update ListACSC
        //
        void UpdateListACSC(AutoCompleteStringCollection ListACSC, string NewText)
        {
            if (ListACSC.Contains(NewText)) ListACSC.Remove(NewText);
            ListACSC.Insert(0, NewText);
        }
        //
        // ACSC - Save file ACSC txt
        //
        void SaveACSC(AutoCompleteStringCollection ListACSC, string LinkSaveACSC)
        {
            if (File.Exists(LinkSaveACSC)) File.WriteAllText(LinkSaveACSC, string.Empty);
            if (ListACSC.Count > 0)
            {
                FileStream fs = new FileStream(LinkSaveACSC, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < ListACSC.Count; i++)
                {
                    if (i != 0) sw.WriteLine();
                    sw.Write(ListACSC[i]);
                }
                sw.Close();
                fs.Close();
            }
        }
        void SaveAllACSC()
        {
            SaveACSC(ListACSCTitle, Application.StartupPath + "\\ACSCTitle.txt");
            SaveACSC(ListACSCPlaceDate, Application.StartupPath + "\\ACSCPlaceDate.txt");
            SaveACSC(ListACSCNOL, Application.StartupPath + "\\ACSCNameOfLeague.txt");
            SaveACSC(ListACSCGrt, Application.StartupPath + "\\ACSCGreeting.txt");
        }
        //
        //
        //
        public class StringValue
        {
            public StringValue(string s)
            {
                Value = s;
            }
            public string Value { get; set; }
        }     
        //
        // Context menu strip 
        //
        private void cmsitemFullScreen_Click(object sender, EventArgs e)
        {
            if (!FullScreen)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;

                mstMain.Visible = false;
                MenuIsHide = true;
                HideMenu.Checked = true;

                cmsitemFullScreen.Checked = true;
                FullScreen = true;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;

                mstMain.Visible = true;
                MenuIsHide = false;
                HideMenu.Checked = false;
                
                cmsitemFullScreen.Checked = false;
                FullScreen = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //
        // Hide/Show Mst
        //
        private void lbMst_MouseHover(object sender, EventArgs e)
        {
            if (FullScreen)
            {
                mstMain.Visible = true;
                MenuIsHide = false;
                HideMenu.Checked = false;

            }
        }
        private void hideMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MenuIsHide)
            {
                mstMain.Visible = false;
                MenuIsHide = true;
                HideMenu.Checked = true;
            }
            else
            {
                mstMain.Visible = true;
                MenuIsHide = false;
                HideMenu.Checked = false;
            }
        }
        //
        // SHOW FINAL RESULT
        //
        private void cmsitemShowResult_Click(object sender, EventArgs e)
        {
            fFinalResult f = new fFinalResult();
            f.imFolderLink = imFolderLink;
            f.ShowDialog();
        }
        //
        // MenuStrip
        //
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadRePj();
            LoadAllACSC();

            if (Drawing.BGI == null)
            {
                SetBGColor.Checked = true;
                SetBGImage.Enabled = SetBGImage.Checked = false;
            }
            else
            {
                if (BackgroundImage == null)
                {
                    SetBGImage.Checked = false;
                    SetBGImage.Enabled = SetBGColor.Checked = true;
                }
                else
                {
                    SetBGImage.Enabled = SetBGColor.Checked = false;
                    SetBGImage.Checked = true;
                }
            }

            if (LogoPath != null && File.Exists(LogoPath))
            {
                SetLogoOfLeague.Enabled = true;
            }
            else SetLogoOfLeague.Enabled = false;

            if (pbxLogo.Visible == false)
            {
                ToolShowLogoOfLeague.Enabled = ToolShowNameAndLogo.Enabled = ToolShowGreetingAndLogo.Enabled = false;
            }
            else ToolShowLogoOfLeague.Enabled = ToolShowNameAndLogo.Enabled = ToolShowGreetingAndLogo.Enabled = true;

            for (int i = 0; i < 5; i++)
            {
                if (SpsLPath[i] != null)
                {
                    SetSponsorLogo.Enabled = true;
                    cbbOnSpsLSetting.SelectedIndex = i;

                    EnableAll();

                    break;
                }
                else SetSponsorLogo.Enabled = false;
            }

            if (Drawing.Mode == "Groups")
            {
                ToolGroupsMode.Enabled = true;
            }
            else
            {
                ToolGroupsMode.Enabled = false;
            }
            if (Groups.GroupsIsShown)
            {
                ToolGroupsCheckAll.Enabled = ToolGroupsUncheckAll.Enabled = true;
            }
            else
            {
                ToolGroupsCheckAll.Enabled = ToolGroupsUncheckAll.Enabled = false;
            }
        }
        //
        // PROJECT ------------------------------------------------------------------------
        //
        // PROJECT - New
        //
        void NewProject()
        {
            txbTitle.Text = txbPlaceDate.Text = txbNameOfLeague.Text = txbGreeting.Text = string.Empty;
            lbTitle.Text = Drawing.Title = "*TITLE*";
            lbPlaceDate.Text = Drawing.PlaceDate = "*PLACE, DATE*";
            NameofLeague = "*NAME OF LEAGUE*";
            lbTextBox.Text = Greeting = "Welcome";
            BackColor = Drawing.BGC = Drawing.DefaultColor;
            pbxLogo.Visible = pbxSps1.Visible = pbxSps2.Visible = pbxSps3.Visible = pbxSps4.Visible = pbxSps5.Visible = true;

            BGSetting = LGSetting = SumSpsLSetting = null;
            SthChanged = SettingChanged = false;
            exPorted = false;

            LogoIsDeleted = BGIIsDeleted = false;
            for (int i = 0; i < 5; i++) SpsLIsDeleted[i] = false;

            Drawing.ImFolderLink = imFolderLink = exFolderLink = exPrTxt = null;

            imPrTxt =
                "<Begin>\n" +
                "Drawing.Title=*TITLE*\n" +
                "Place, Date=*PLACE, DATE*\n" +
                "Name of league=*NAME OF LEAGUE*\n" +
                "Greeting=Welcome\n" +
                "Background=MidnightBlue\n" +
                "Logo of league=NULL\n" +
                "Sponsor logos=NULL,NULL,NULL,NULL,NULL\n" +
                "<End>";

            Text = "DRAWING";

            BackgroundImage = Drawing.BGI = Drawing.LGI = pbxLogo.Image = pbxSps1.Image = pbxSps2.Image = pbxSps3.Image = pbxSps4.Image = pbxSps5.Image = null;
            BGIPath = LogoPath = imBGIPath = imLogoPath = null;

            AlignTitle(true);
            pnlListOfTeams.Visible = false;

            Array.Clear(SpsLPath, 0, SpsLPath.Length);
            Array.Clear(imSpsLPath, 0, imSpsLPath.Length);
            Array.Clear(SpsLSetting, 0, SpsLSetting.Length);

            ResetGroupsMode();

            Drawing.Mode = null;

            flpListOfTeams.Controls.Clear();

            flpGroups1.Visible = flpGroups2.Visible = false;

            flpGroups1.Controls.Clear();
            flpGroups2.Controls.Clear();

            cmsitemShowResult.Enabled = false;
        }
        void ResetGroupsMode()
        {
            if (Groups.ArrPot != null)
            {
                Array.Clear(Groups.ArrPot, 0, Groups.ArrPot.Length);
            }
            if (Groups.ArrGroup != null)
            {
                Array.Clear(Groups.ArrGroup, 0, Groups.ArrGroup.Length);
            }
            Groups.NumberOfTeams = 1;
            Groups.NumberOfPots = 1;
            Groups.NumberOfGroups = 1;

            Groups.TitlePot = "POT ";
            Groups.OTPot = 0;

            Groups.TitleGroup = "GROUP ";
            Groups.OTGroup = 1;

            Groups.IsDelay = false;
            Groups.DelayTime = 1000;

            Groups.DropMode = "Random";
            Groups.GroupsIsShown = false;

            Groups.FindSameReg = false;

            GroupsDropRandom();

        }
        private void ProNew_Click(object sender, EventArgs e)
        {
            if (imPrTxt == null) SettingChanged = true;
            else
            {
                BeforeExport();
                if (!exPrTxt.Equals(imPrTxt)) SettingChanged = true;
                else SettingChanged = false;
            }

            if (SthChanged || SettingChanged)
            {
                DialogResult diaRes = MessageBox.Show("Something has changed. Export to save changes?", "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (diaRes == DialogResult.Yes)
                {
                    ExportWhenExit();
                    if (exPorted) NewProject();
                }
                //else if (diaRes == DialogResult.No) e.Cancel = false;
                else if (diaRes == DialogResult.No) NewProject();
            }
            else NewProject();
        }
        //
        // PROJECT - Open
        //
        void ImportFunc(string imLink) //Folder is Valid
        {
            NewProject();
            Drawing.ImFolderLink = imFolderLink = imLink;
            //
            // Ip BackGround
            //
            if (File.Exists(imFolderLink + "\\Background Image"))
            {
                imBGIPath = imFolderLink + "\\Background Image";
                using (FileStream stream = File.Open(imBGIPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Drawing.BGI = new Bitmap(stream);
                    BackgroundImage = null;
                    BGIPath = imBGIPath;
                    stream.Dispose();
                }
            }
            //
            // Ip Logo of league
            //
            if (File.Exists(imFolderLink + "\\Logo of League"))
            {
                imLogoPath = imFolderLink + "\\Logo of League";
                using (FileStream stream = File.Open(imLogoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Drawing.LGI = new Bitmap(stream);
                    pbxLogo.Image = Drawing.LGI;
                    LogoPath = imLogoPath;
                    stream.Dispose();
                }          
            }
            AlignTitle(Drawing.LGI == null);
            //
            // Ip Sponsor Logos
            //
            pbxSps1.Image = pbxSps2.Image = pbxSps3.Image = pbxSps4.Image = pbxSps5.Image = null;
            pbxSps1.Visible = pbxSps2.Visible = pbxSps3.Visible = pbxSps4.Visible = pbxSps5.Visible = true;

            if (Directory.Exists(imFolderLink + "\\Sponsor Logo"))
            {
                for (int i = 1; i < 6; i++)
                    if (File.Exists(imFolderLink + "\\Sponsor Logo\\" + i.ToString()))
                    {
                        string sorPath = imFolderLink + "\\Sponsor Logo\\" + i.ToString();
                        using (FileStream stream = File.Open(sorPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            imSpsLPath[i - 1] = SpsLPath[i - 1] = sorPath;
                            switch (i - 1)
                            {
                                case 0: pbxSps1.Image = new Bitmap(stream); break;
                                case 1: pbxSps2.Image = new Bitmap(stream); break;
                                case 2: pbxSps3.Image = new Bitmap(stream); break;
                                case 3: pbxSps4.Image = new Bitmap(stream); break;
                                case 4: pbxSps5.Image = new Bitmap(stream); break;
                                default: break;
                            }

                            stream.Dispose();
                        }
                    }
            }
            //
            // Ip Properties txt
            //
            FileStream fs2end = new FileStream(imFolderLink + "\\SettingDrawing.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr2end = new StreamReader(fs2end);
            imPrTxt = sr2end.ReadToEnd();
            sr2end.Close();
            fs2end.Close();

            FileStream fs = new FileStream(imFolderLink + "\\SettingDrawing.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            //string[] Property = new string[3];

            int bg = 0;

            while (str != "<Begin>" && bg < 20)
            {
                str = sr.ReadLine();
                bg++;
            }

            if (bg < 20)
            {
                str = sr.ReadLine();
                int l = 0;
                while (str != "<End>" && l < 20)
                {
                    string[] tmp = str.Split('=');

                    switch (tmp[0])
                    {
                        case "Drawing.Title": txbTitle.Text = lbTitle.Text = Drawing.Title = str.Substring(tmp[0].Length + 1); break;
                        case "Place, Date": txbPlaceDate.Text = lbPlaceDate.Text = Drawing.PlaceDate = str.Substring(tmp[0].Length + 1); break;
                        case "Name of league": txbNameOfLeague.Text = NameofLeague = str.Substring(tmp[0].Length + 1); break;
                        case "Greeting": txbGreeting.Text = lbTextBox.Text = Greeting = str.Substring(tmp[0].Length + 1); break;
                        case "Background":
                            if (tmp[1] == "IMAGE")
                            {
                                BackgroundImage = Drawing.BGI;
                                Drawing.BGIsImage = true;
                            }
                            else
                            {
                                BackgroundImage = null;
                                try
                                {
                                    BackColor = Drawing.BGC = Color.FromName(tmp[1]);
                                }
                                catch (Exception)
                                {
                                    BackColor = Drawing.BGC = Drawing.DefaultColor;
                                }
                                Drawing.BGIsImage = false;
                            }
                            break;
                        case "Logo of league":
                            if (tmp[1] == "SHOWED")
                            {
                                //pbxLogo.Image = Drawing.LGI;
                                pbxLogo.Visible = true;
                                SetLOLHidden.Enabled = SetLOLShowed.Checked = true;
                                SetLOLShowed.Enabled = SetLOLHidden.Checked = false;

                                Drawing.LogoIsHide = false;
                            }
                            else if (tmp[1] == "HIDDEN" || tmp[1] == "NULL")
                            {
                                LogoIsHidden();
                            }
                            break;
                        case "Sponsor logos":
                            string[] tmpSpsL = tmp[1].Split(',');
                            if (tmpSpsL[0] == "HIDE" || tmpSpsL[0] == "NULL") pbxSps1.Visible = false;
                            if (tmpSpsL[1] == "HIDE" || tmpSpsL[1] == "NULL") pbxSps2.Visible = false;
                            if (tmpSpsL[2] == "HIDE" || tmpSpsL[2] == "NULL") pbxSps3.Visible = false;
                            if (tmpSpsL[3] == "HIDE" || tmpSpsL[3] == "NULL") pbxSps4.Visible = false;
                            if (tmpSpsL[4] == "HIDE" || tmpSpsL[4] == "NULL") pbxSps5.Visible = false;
                            break;

                        default: break;
                    }
                    l++;
                    str = sr.ReadLine();
                }

            }
            else
            {
                MessageBox.Show("The <Begin> tag was not found.\r\nOr there were too many blank lines at the beginning.\r\n\r\nPlease add <Begin> tag or Remove redundant lines in SettingDrawing.txt file",
                    "Invalid SettingDrawing.txt file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sr.Close();
            fs.Close();

            if (ListRePj.Contains(imLink)) ListRePj.Remove(imLink);
            ListRePj.Insert(0,imLink);

            string TextFoldedrLink = "DRAWING - " + imFolderLink;
            Text = TextFoldedrLink;

            ImportDrawing(imLink);

            SthChanged = false;
        }
        void ImportDrawing(string imFolderLink)
        {
            string imGroupsLink = imFolderLink + "\\Groups";
            if (Directory.Exists(imGroupsLink))
            {
                string imSettingTxtLink = imGroupsLink + "\\SettingGroups.txt";
                if (File.Exists(imSettingTxtLink))
                {
                    FileStream fs = new FileStream(imSettingTxtLink, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string str = sr.ReadLine();

                    int bg = 0;

                    while (str != "<Begin>" && bg < 20)
                    {
                        str = sr.ReadLine();
                        bg++;
                    }

                    if (bg < 20)
                    {
                        str = sr.ReadLine();
                        int l = 0;
                        while (str != "<End>" && l < 20)
                        {
                            string[] tmp = str.Split('=');

                            switch (tmp[0])
                            {
                                case "Number of pots": Groups.NumberOfPots = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Number of groups": Groups.NumberOfGroups = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Number of teams": Groups.NumberOfTeams = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Drawing.Title of pots": Groups.TitlePot = str.Substring(tmp[0].Length + 1); break;
                                case "Drawing.Title of groups": Groups.TitleGroup = str.Substring(tmp[0].Length + 1); break;
                                case "Order type of pots": Groups.OTPot = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Order type of groups": Groups.OTGroup = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Drop mode": Groups.DropMode = str.Substring(tmp[0].Length + 1); break;
                                case "Delay": Groups.IsDelay = (str.Substring(tmp[0].Length + 1) == "TRUE")? true : false; break;
                                case "Delay time": Groups.DelayTime = int.Parse(str.Substring(tmp[0].Length + 1)); break;
                                case "Find same region": Groups.FindSameReg = (str.Substring(tmp[0].Length + 1) == "TRUE") ? true : false; break;

                                default: break;
                            }
                            l++;
                            str = sr.ReadLine();
                        }
                        //
                        // Ip Teams
                        //
                        Groups.ArrPot = new TeamsInGroupsMode[Groups.NumberOfPots, Groups.NumberOfGroups];
                        for ( int p = 0; p < Groups.NumberOfPots; p++)
                        {
                            for (int t = 0; t < Groups.NumberOfGroups; t++)
                            {
                                string imTeamLink = imGroupsLink + "\\Pot " + (p + 1).ToString() + "\\Team " + (t + 1).ToString();
                                if (Directory.Exists(imTeamLink))
                                {
                                    Groups.ArrPot[p, t] = Groups.GetTeamFromFolder(imTeamLink);
                                }
                            }
                        }
                        //
                        //
                        //
                        Groups.ListTitlePot = Groups.ListTitleVsOT(Groups.TitlePot, Groups.GetNameArrOT(Groups.OTPot), Groups.NumberOfPots);
                        Groups.ListTitleGroup = Groups.ListTitleVsOT(Groups.TitleGroup, Groups.GetNameArrOT(Groups.OTGroup), Groups.NumberOfGroups);

                        Drawing.Mode = "Groups";

                        if (Groups.DropMode == "LeftToRight") GroupsDropLefttoRight();
                        else if (Groups.DropMode == "RightToLeft") GroupsDropRighttoLeft();
                        else GroupsDropRandom();

                        if (Groups.IsDelay) DelayIsTrue();
                        else DelayIsFalse();
                    }
                    else
                    {
                        MessageBox.Show("The <Begin> tag was not found.\r\nOr there were too many blank lines at the beginning.\r\n\r\nPlease add <Begin> tag or Remove redundant lines in SettingGroups.txt file",
                            "Invalid SettingGroups.txt file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    sr.Close();
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("SettingGroups.txt file not found", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void OpenProject()
        {
            FolderBrowserDialog imFolder = new FolderBrowserDialog();
            imFolder.Description = "Select the folder exported with this software";
            if (imFolder.ShowDialog() == DialogResult.OK)
            {
                CheckValidFolder(imFolder.SelectedPath.ToString());
            }
        }
        bool CheckValidFolder(string LinkParentFolder) // Check Valid Folder 
        {
            if (File.Exists(LinkParentFolder + "\\SettingDrawing.txt"))
            {
                string imLink = LinkParentFolder;
                ImportFunc(imLink);
                return true;
            }
            else
            {
                MessageBox.Show("That is not the folder exported with this software", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void openStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (imPrTxt == null) SettingChanged = true;
            else
            {
                BeforeExport();
                if (!exPrTxt.Equals(imPrTxt)) SettingChanged = true;
                else SettingChanged = false;
            }

            if (SthChanged || SettingChanged)
            {
                DialogResult diaRes = MessageBox.Show("Something has changed. Export to save changes?", "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (diaRes == DialogResult.Yes)
                {
                    ExportWhenExit();
                    if (exPorted) OpenProject();
                }
                //else if (diaRes == DialogResult.No) e.Cancel = false;
                else if (diaRes == DialogResult.No) OpenProject();
            }
            else OpenProject();
        }
        //
        // PROJECT - Recent project
        //
        // Load Recent Project
        //
        void LoadRePjtxt()
        {
            List<string> tmpListRePj = new List<string>();
            string LinkRecentPj = Application.StartupPath + "\\RecentProject.txt";
            if (File.Exists(LinkRecentPj))
            {
                FileStream fs = new FileStream(LinkRecentPj, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string str = sr.ReadLine();
                int l = 0;
                while (str != null && l < 20)
                {
                    tmpListRePj.Add(str);
                    str = sr.ReadLine();
                    l++;
                }
                sr.Close();
                sr.Dispose();
                fs.Close();
            }
            ListRePj = tmpListRePj;
        }
        void LoadRePj()
        {
            if (ProRecentProject.DropDownItems.Count > 0)
            {
                ProRecentProject.DropDownItems.Clear();
            }
            if (ListRePj.Count() > 0)
            {
                ProRecentProject.Enabled = true;
                ToolStripMenuItem[] items = new ToolStripMenuItem[ListRePj.Count()]; // You would obviously calculate this value at runtime
                for (int i = 0; i < ListRePj.Count(); i++)
                {
                    items[i] = new ToolStripMenuItem();
                    items[i].Name = ListRePj[i];
                    //items[i].Tag = "specialDataHere";
                    items[i].Text = (i+1).ToString() + " " + ListRePj[i];
                    items[i].Click += new EventHandler(MenuItemClickHandler);
                }
                ProRecentProject.DropDownItems.AddRange(items);

                ToolStripSeparator ProRePjSep = new ToolStripSeparator();
                ProRecentProject.DropDownItems.Add(ProRePjSep);

                ToolStripMenuItem ClearHistory = new ToolStripMenuItem();
                ClearHistory.Name = "ProRePjClearHistory";
                ClearHistory.Text = "Clear history";
                ClearHistory.Click += new EventHandler(ClearHistoryClickHandler);

                ProRecentProject.DropDownItems.Add(ClearHistory);
            }
            else
            {

                ProRecentProject.Enabled = false;
            }
        }
        //
        // Click a recent project
        //
        void NextRecentProject(ToolStripMenuItem clickedItem)
        {         
            int i = ProRecentProject.DropDownItems.IndexOf(clickedItem);
            ProRecentProject.DropDownItems.Remove(clickedItem);
            ListRePj.RemoveAt(i);
            CheckValidFolder(clickedItem.Name);
        }
        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (imPrTxt == null) SettingChanged = true;
            else
            {
                BeforeExport();
                if (!exPrTxt.Equals(imPrTxt)) SettingChanged = true;
                else SettingChanged = false;
            }

            if (SthChanged || SettingChanged)
            {
                DialogResult diaRes = MessageBox.Show("Something has changed. Export to save changes?", "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (diaRes == DialogResult.Yes)
                {
                    ExportWhenExit();
                    if (exPorted) NextRecentProject(clickedItem);
                }
                //else if (diaRes == DialogResult.No) e.Cancel = false;
                else if (diaRes == DialogResult.No) NextRecentProject(clickedItem);
            }
            else NextRecentProject(clickedItem);
        }
        //
        // Click clear history
        //
        private void ClearHistoryClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            ListRePj.Clear();
        }
        //
        // Save Recent Project
        //
        void SaveRePjtxt()
        {
            string LinkRecentPj = Application.StartupPath + "\\RecentProject.txt";
            if (File.Exists(LinkRecentPj)) File.WriteAllText(LinkRecentPj, string.Empty);
            if (ListRePj.Count() > 0)
            {
                FileStream fs = new FileStream(LinkRecentPj, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                for (int i = 0; i < ListRePj.Count(); i++)
                {
                    if (i != 0) sw.WriteLine();
                    sw.Write(ListRePj[i]);
                }
                sw.Close();
                sw.Dispose();
                fs.Close();
            }
        }
        void SaveRePj()
        {

        }
        //
        // PROJECT - Export
        //
        void BeforeExport()
        {
            GetBGSetting();
            GetLGSetting();
            GetSumSpsLSetting();

            exPrTxt =
                    "<Begin>" + "\n" +
                    "Drawing.Title" + "=" + Drawing.Title + "\n" +
                    "Place, Date" + "=" + Drawing.PlaceDate + "\n" +
                    "Name of league" + "=" + NameofLeague + "\n" +
                    "Greeting" + "=" + Greeting + "\n" +
                    "Background" + "=" + BGSetting + "\n" +
                    "Logo of league" + "=" + LGSetting + "\n" +
                    "Sponsor logos" + "=" + SumSpsLSetting + "\n" +
                    "<End>";
        }
        void GetBGSetting()
        {
            if (BGIPath != null)
            {
                if (BackgroundImage == null)
                {
                    BGSetting = Drawing.BGC.Name.ToString();
                }
                else
                {
                    BGSetting = "IMAGE";
                }
            }
            else BGSetting = Drawing.BGC.Name.ToString();
        }
        void GetLGSetting()
        {
            if (LogoPath != null)
            {
                if (pbxLogo.Visible == false) //if (Drawing.LGI == null)
                {
                    LGSetting = "HIDDEN";
                }
                else
                {
                    LGSetting = "SHOWED";
                }
            }
            else LGSetting = "NULL";
        }
        void GetSumSpsLSetting()
        {
            SumSpsLSetting = null;

            for (int i = 0; i < 5; i++)
            {
                if (SpsLPath[i] != null)
                {
                    switch (i)
                    {
                        case 0:
                            if (pbxSps1.Visible == true) SpsLSetting[i] = "SHOW";
                            else SpsLSetting[i] = "HIDE";
                            break;
                        case 1:
                            if (pbxSps2.Visible == true) SpsLSetting[i] = "SHOW";
                            else SpsLSetting[i] = "HIDE";
                            break;
                        case 2:
                            if (pbxSps3.Visible == true) SpsLSetting[i] = "SHOW";
                            else SpsLSetting[i] = "HIDE";
                            break;
                        case 3:
                            if (pbxSps4.Visible == true) SpsLSetting[i] = "SHOW";
                            else SpsLSetting[i] = "HIDE";
                            break;
                        case 4:
                            if (pbxSps5.Visible == true) SpsLSetting[i] = "SHOW";
                            else SpsLSetting[i] = "HIDE";
                            break;

                        default: break;
                    }
                }
                else
                {
                    SpsLSetting[i] = "NULL";
                }

                if (i < 4) SumSpsLSetting = SumSpsLSetting + SpsLSetting[i] + ",";
                else SumSpsLSetting = SumSpsLSetting + SpsLSetting[i];
            }
        }
        void Delete()
        {
            if (LogoIsDeleted)
            {
                if (File.Exists(imLogoPath))
                {
                    File.Delete(imLogoPath);
                }
            }
            if (BGIIsDeleted)
            {
                if (File.Exists(imBGIPath))
                {
                    File.Delete(imBGIPath);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (SpsLIsDeleted[i])
                {
                    if (File.Exists(imSpsLPath[i]))
                    {
                        File.Delete(imSpsLPath[i]);
                    }
                }
            }
        }
        void ExportFunc()
        {
            Delete();
            if (BGIPath != null)
            {
                string exBGIPath = exFolderLink + "\\Background Image";
                if (File.Exists(BGIPath) && BGIPath != exBGIPath)
                    File.Copy(BGIPath, exBGIPath, true);
            }

            if (LogoPath != null)
            {
                string exLogoPath = exFolderLink + "\\Logo of League";
                if (File.Exists(LogoPath) && LogoPath != exLogoPath)
                    File.Copy(LogoPath, exLogoPath, true);
            }

            if (SetSponsorLogo.Enabled == true)
            {
                string sponsorPath = exFolderLink + "\\Sponsor Logo";
                if (!Directory.Exists(sponsorPath))
                    Directory.CreateDirectory(sponsorPath);

                for (int i = 0; i < 5; i++)
                {
                    if (SpsLPath[i] != null)
                    {
                        string exSpsLPath = exFolderLink + "\\Sponsor Logo\\" + (i + 1).ToString();
                        if (File.Exists(SpsLPath[i]) && SpsLPath[i] != exSpsLPath)
                        {
                            File.Copy(SpsLPath[i], exSpsLPath, true);

                        }
                    }
                }
            }

            string infoPath = exFolderLink + "\\SettingDrawing.txt";

            if (File.Exists(infoPath))
                File.WriteAllText(infoPath, string.Empty);
            FileStream fs = new FileStream(infoPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(exPrTxt);

            sw.Close();
            fs.Close();

            ExportDrawing(exFolderLink);

            SthChanged = false;
            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //
        // EXPORT DRAWING MODE
        //
        void ExportDrawing(string exFolderLink)
        {
            if (Drawing.Mode == "Groups")
            {               
                string exGroupsLink = exFolderLink + "\\Groups";
                if (!Directory.Exists(exGroupsLink))
                    Directory.CreateDirectory(exGroupsLink);
                //
                // txt
                //
                string SettingTxtLink = exGroupsLink + "\\SettingGroups.txt";
                if (File.Exists(SettingTxtLink))
                    File.WriteAllText(SettingTxtLink, string.Empty);
                FileStream fs = new FileStream(SettingTxtLink, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                string Delay = Groups.IsDelay ? "TRUE" : "FALSE";
                string Findsameregion = Groups.FindSameReg ? "TRUE" : "FALSE";

                string GroupsSettingTxt = 
                    "<Begin>" + "\n" +
                    "Number of pots" + "=" + Groups.NumberOfPots + "\n" +
                    "Number of groups" + "=" + Groups.NumberOfGroups + "\n" +
                    "Number of teams" + "=" + Groups.NumberOfTeams + "\n" +
                    "Drawing.Title of pots" + "=" + Groups.TitlePot + "\n" +
                    "Drawing.Title of groups" + "=" + Groups.TitleGroup + "\n" +
                    "Order type of pots" + "=" + Groups.OTPot + "\n" +
                    "Order type of groups" + "=" + Groups.OTGroup + "\n" +
                    "Drop mode" + "=" + Groups.DropMode + "\n" +
                    "Delay" + "=" + Delay + "\n" +
                    "Delay time" + "=" + Groups.DelayTime + "\n" +
                    "Find same region" + "=" + Findsameregion + "\n" +
                    "<End>";

                sw.Write(GroupsSettingTxt);

                sw.Close();
                fs.Close();
                //
                // Pots
                //
                for (int i = 0; i < Groups.NumberOfPots; i++)
                {
                    string exPotLink = exGroupsLink + "\\Pot " + (i + 1).ToString();
                    if (!Directory.Exists(exPotLink))
                        Directory.CreateDirectory(exPotLink);
                    for (int k = 0; k < Groups.NumberOfGroups; k++)
                    {
                        string exTeamLink = exPotLink + "\\Team " + (k + 1).ToString();
                        if (!Directory.Exists(exTeamLink))
                            Directory.CreateDirectory(exTeamLink);
                        //
                        // Ex ATeam to Folder
                        //                 
                        if (Groups.ArrPot[i, k] != null)
                        {
                            TeamsInGroupsMode ATeam = Groups.ArrPot[i, k];

                            string LogoLink = Groups.ArrPot[i, k].LogoLink;

                            if (File.Exists(LogoLink) && LogoLink != exTeamLink + "\\Logo.png")
                            {
                                File.Copy(LogoLink, exTeamLink + "\\Logo.png", true);
                            }
                            // Ex Name
                            string NameTxtLink = exTeamLink + "\\Name.txt";

                            if (File.Exists(NameTxtLink))
                            {
                                File.WriteAllText(NameTxtLink, string.Empty);
                            }

                            FileStream fs2 = new FileStream(NameTxtLink, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter sw2 = new StreamWriter(fs2);

                            sw2.Write(ATeam.FullName + "\n" + ATeam.ShortName + "\n" + ATeam.Region);

                            sw2.Dispose();
                            sw2.Close();
                            fs2.Dispose();
                            fs2.Close();
                        }                      
                    }
                }
            }
        }
        void Export()
        {
            if (imFolderLink != null)
            {
                exFolderLink = imFolderLink;
                BeforeExport();
                ExportFunc();
            }
            else
            {
                ExportAs();
            }
        }
        void ExportAs()
        {
            fExport f = new fExport();
            f.exFolderName = Drawing.Title;
            f.ShowDialog();
            if (f.exported)
            {
                BeforeExport();
                exFolderLink = f.exPath;
                Directory.CreateDirectory(exFolderLink);
                ExportFunc();
                ImportFunc(exFolderLink);
            }
        }
        void ExportWhenExit()
        {
            if (imFolderLink != null)
            {
                exFolderLink = imFolderLink;
                ExportFunc();
                exPorted = true;
                if (ListRePj.Contains(exFolderLink)) ListRePj.Remove(exFolderLink);
                ListRePj.Insert(0, exFolderLink);
            }
            else
            {
                ExportAsWhenExit();
            } 
        }
        void ExportAsWhenExit()
        {
            fExport f = new fExport();
            f.exFolderName = Drawing.Title;
            f.ShowDialog();
            exPorted = f.exported;
            if (f.exported)
            {
                exFolderLink = f.exPath;
                Directory.CreateDirectory(exFolderLink);
                ExportFunc();
                if (ListRePj.Contains(exFolderLink)) ListRePj.Remove(exFolderLink);
                ListRePj.Insert(0, exFolderLink);
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export();
        }
        private void exportAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportAs();
        }
        //
        // PROJECT - Exit
        //
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        // INSERT ------------------------------------------------------------------------
        //
        // INSERT - List of Teams
        //
        //int idCur;
        //string OldFilePath, NewFilePath;
        //OpenFileDialog ofd;
        private void listOfTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //
        // INSERT - Background
        //
        private void importAndApplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bgiPath = new OpenFileDialog();
            bgiPath.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|All files|*.*";
            if (bgiPath.ShowDialog() == DialogResult.OK)
            {
                BGIPath = bgiPath.FileName;
                BackgroundImage = Drawing.BGI = new Bitmap(BGIPath);

                SetBGImage.Enabled = SetBGColor.Checked = false;
                SetBGImage.Checked = true;

                SthChanged = true;
            }
        }
        private void importOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bgiPath = new OpenFileDialog();
            bgiPath.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|All files|*.*";
            if (bgiPath.ShowDialog() == DialogResult.OK)
            {
                BGIPath = bgiPath.FileName;
                Drawing.BGI = new Bitmap(BGIPath);

                if (SetBGImage.Checked == true)
                {
                    BackgroundImage = null;
                    BackColor = Drawing.BGC;

                    SetBGImage.Checked = false;
                    SetBGImage.Enabled = SetBGColor.Checked = true;
                }

                SthChanged = true;
            }
        }
        //
        // INSERT - Logo of league
        //
        private void importAndShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoPath = new OpenFileDialog();
            logoPath.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|All files|*.*";
            if (logoPath.ShowDialog() == DialogResult.OK)
            {
                LogoPath = logoPath.FileName;
                using (FileStream stream = File.Open(LogoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Drawing.LGI = pbxLogo.Image = new Bitmap(stream);
                    stream.Dispose();
                    stream.Close();
                }

                LogoIsShowed();

                AlignTitle(Drawing.LGI == null);

                SthChanged = true;
            }
        }
        private void importOnlyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoPath = new OpenFileDialog();
            logoPath.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|All files|*.*";
            if (logoPath.ShowDialog() == DialogResult.OK)
            {
                Image oldLGI = Drawing.LGI;

                LogoPath = logoPath.FileName;
                Drawing.LGI = new Bitmap(LogoPath);
                if (pbxLogo.Image == oldLGI)
                {
                    pbxLogo.Image = null;
                }

                SetLOLHidden.Enabled = SetLOLShowed.Checked = true;
                SetLOLShowed.Enabled = SetLOLHidden.Checked = false;

                SthChanged = true;
            }
        }
        //
        // INSERT - Sponsor logos
        //
        private void choseImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog logoPath = new OpenFileDialog();
            logoPath.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|All files|*.*";
            if (logoPath.ShowDialog() == DialogResult.OK)
            {
                int idSps = cbbSponsors.SelectedIndex;
                SpsLPath[idSps] = logoPath.FileName;

                switch (idSps)
                {
                    case 0: pbxSps1.Image = new Bitmap(SpsLPath[0]); break;
                    case 1: pbxSps2.Image = new Bitmap(SpsLPath[1]); break;
                    case 2: pbxSps3.Image = new Bitmap(SpsLPath[2]); break;
                    case 3: pbxSps4.Image = new Bitmap(SpsLPath[3]); break;
                    case 4: pbxSps5.Image = new Bitmap(SpsLPath[4]); break;
                    default: break;
                }

                SthChanged = true;
            }
        }
        //
        // SETTING ------------------------------------------------------------------------
        //
        // SETTING - Drawing.Title
        //
        private void titleTextBox3_TextChanged(object sender, EventArgs e)
        {
            Drawing.Title = lbTitle.Text = txbTitle.Text;
            //SthChanged = true;
        }
        private void SetTitleSaveToACS_Click(object sender, EventArgs e)
        {
            UpdateListACSC(ListACSCTitle, txbTitle.Text);
        }
        private void SetTitleClearACS_Click(object sender, EventArgs e)
        {
            ListACSCTitle.Clear();
        }
        //
        // SETTING - Place, Date
        //
        private void txbPlaceDate_TextChanged(object sender, EventArgs e)
        {
            Drawing.PlaceDate = lbPlaceDate.Text = txbPlaceDate.Text;
            //SthChanged = true;
        }
        private void SetPlaceDateSaveToACS_Click(object sender, EventArgs e)
        {
            UpdateListACSC(ListACSCPlaceDate, txbPlaceDate.Text);
        }
        private void SetPlaceDateClearACS_Click(object sender, EventArgs e)
        {
            ListACSCPlaceDate.Clear();
        }
        //
        // SETTING - NameofLeague
        //
        private void txbResultTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NameofLeague = txbNameOfLeague.Text;
                if (Drawing.LGI != null) pbxLogo.Image = Drawing.LGI;
            }
        }
        private void showToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NameofLeague = lbTextBox.Text = txbNameOfLeague.Text;
            if (Drawing.LGI != null) pbxLogo.Image = Drawing.LGI;
        }
        private void txbNameofLeague_TextChanged(object sender, EventArgs e)
        {
            NameofLeague = txbNameOfLeague.Text;
            //SthChanged = true;
        }
        private void SetNOLSaveToACS_Click(object sender, EventArgs e)
        {
            UpdateListACSC(ListACSCNOL, txbNameOfLeague.Text);
        }
        private void SetNOLClearACS_Click(object sender, EventArgs e)
        {
            ListACSCNOL.Clear();
        }
        //
        // SETTING - Greeting
        //
        private void txbGreeting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Greeting = txbGreeting.Text;
                //if (Drawing.LGI != null) pbxLogo.Image = Drawing.LGI;
            }
        }
        private void showToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Greeting = lbTextBox.Text = txbGreeting.Text;
            //if (Drawing.LGI != null) pbxLogo.Image = Drawing.LGI;
        }
        private void txbGreeting_TextChanged(object sender, EventArgs e)
        {
            Greeting = txbGreeting.Text;
        }
        private void SetGrtSaveToACS_Click(object sender, EventArgs e)
        {
            UpdateListACSC(ListACSCGrt, txbGreeting.Text);
        }
        private void SetGrtClearACS_Click(object sender, EventArgs e)
        {
            ListACSCGrt.Clear();
        }
        //
        // SETTING - Background setting
        //
        // SETTING - Background setting - Image
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImage = Drawing.BGI;

            Drawing.BGIsImage = true;

            SetBGImage.Checked = SetBGColor.Enabled = true;
            SetBGImage.Enabled = SetBGColor.Checked = false;
        }
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult deBG = MessageBox.Show("Tips: You can choose Color to hide background image.\r\n\r\nContinue deleting?", "Delete background image",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deBG == DialogResult.Yes)
            {
                BackgroundImage = Drawing.BGI = null;
                BackColor = Drawing.BGC;
                Drawing.BGIsImage = false;

                if (imFolderLink != null) BGIIsDeleted = true;

                imBGIPath = BGIPath = null;
                MessageBox.Show("The background image has been removed.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetBGImage.Checked = false;
                SetBGColor.Checked = true;
            }
        }
        //
        // SETTING - Background setting - Color
        //
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImage = null;
            BackColor = Drawing.BGC;

            SetBGImage.Checked = false;
            SetBGImage.Enabled = SetBGColor.Checked = true;

            Drawing.BGIsImage = false;
        }
        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CDl = new ColorDialog();
            if (CDl.ShowDialog() == DialogResult.OK)
            {
                BackgroundImage = null;
                BackColor = Drawing.BGC = CDl.Color;

                Drawing.BGIsImage = false;

                SetBGImage.Checked = false;
                SetBGImage.Enabled = SetBGColor.Checked = true;

                //SthChanged = true;
            }
        }
        private void defaultColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImage = null;
            BackColor = Drawing.BGC = Drawing.DefaultColor;

            Drawing.BGIsImage = false;

            SetBGImage.Checked = false;
            SetBGImage.Enabled = SetBGColor.Checked = true;
        }
        //
        // SETTING - Logo of League
        //
        void LogoIsShowed() //Logo is Showed
        {
            pbxLogo.Visible = true;

            SetLOLHidden.Enabled = SetLOLShowed.Checked = true;
            SetLOLShowed.Enabled = SetLOLHidden.Checked = false;

            Drawing.LogoIsHide = false;
            //}
        }
        void LogoIsHidden() //Logo is Hidden
        {
            pbxLogo.Visible = false;

            SetLOLHidden.Enabled = SetLOLShowed.Checked = false;
            SetLOLShowed.Enabled = SetLOLHidden.Checked = true;

            Drawing.LogoIsHide = true;
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogoIsShowed();
        }
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoIsHidden();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult deLG = MessageBox.Show(
                    "Tips: You can hide it instead of deleting it.\r\n\r\nContinue deleting?", "Delete logo of league",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deLG == DialogResult.Yes)
            {
                if (pbxLogo.Image == Drawing.LGI) pbxLogo.Image = null;
                Drawing.LGI = null;

                AlignTitle(Drawing.LGI == null);
                if (imFolderLink != null) LogoIsDeleted = true;
                
                MessageBox.Show("The logo of league has been removed.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                imLogoPath = LogoPath = null;
                SetLOLShowed.Checked = SetLOLHidden.Checked = false;
            }           
        }
        //
        // SETTING - Sponsor Logo
        //
        void ShowingSpsL()
        {
            SetSpsLShow.Enabled = SetSpsLHide.Checked = false;
            SetSpsLShow.Checked = SetSpsLHide.Enabled = true;

            SetSpsLDelete.Enabled = true;
        }
        void HidingSpsL()
        {
            SetSpsLShow.Enabled = SetSpsLHide.Checked = true;
            SetSpsLShow.Checked = SetSpsLHide.Enabled = false;

            SetSpsLDelete.Enabled = true;
        }
        void DeletingSpsL()
        {
            SetSpsLShow.Enabled = SetSpsLHide.Checked = false;
            SetSpsLShow.Checked = SetSpsLHide.Enabled = false;
            SetSpsLDelete.Enabled = false;
        }
        void EnableAll()
        {
            SetSpsLShowAll.Enabled = true;
            SetSpsLHideAll.Enabled = true;
            SetSpsLDeleteAll.Enabled = true;
        }
        //
        // SETTING - Sponsor Logo - CBB SelectedIndexChanged
        //
        private void cbbOnSpsLSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSps = cbbOnSpsLSetting.SelectedIndex;
            if (SpsLPath[idSps] != null)
            {
                switch (idSps)
                {
                    case 0:
                        if (pbxSps1.Visible == true) ShowingSpsL();
                        else HidingSpsL();
                        break;
                    case 1:
                        if (pbxSps2.Visible == true) ShowingSpsL();
                        else HidingSpsL();
                        break;
                    case 2:
                        if (pbxSps3.Visible == true) ShowingSpsL();
                        else HidingSpsL();
                        break;
                    case 3:
                        if (pbxSps4.Visible == true) ShowingSpsL();
                        else HidingSpsL();
                        break;
                    case 4:
                        if (pbxSps5.Visible == true) ShowingSpsL();
                        else HidingSpsL();
                        break;

                    default: break;
                }
            }
            else
            {
                DeletingSpsL();
            }
        }
        //
        private void showOnSLSetting_Click(object sender, EventArgs e)
        {
            int idSps = cbbOnSpsLSetting.SelectedIndex;
            switch (idSps)
            {
                case 0: pbxSps1.Visible = true; break;
                case 1: pbxSps2.Visible = true; break;
                case 2: pbxSps3.Visible = true; break;
                case 3: pbxSps4.Visible = true; break;
                case 4: pbxSps5.Visible = true; break;

                default: break;
            }
            ShowingSpsL();
        }
        private void hideOnSLSetting_Click(object sender, EventArgs e)
        {
            int idSps = cbbOnSpsLSetting.SelectedIndex;
            switch (idSps)
            {
                case 0: pbxSps1.Visible = false; break;
                case 1: pbxSps2.Visible = false; break;
                case 2: pbxSps3.Visible = false; break;
                case 3: pbxSps4.Visible = false; break;
                case 4: pbxSps5.Visible = false; break;

                default: break;
            }
            HidingSpsL();
        }
        private void deleteOnSLSetting_Click(object sender, EventArgs e)
        {
            DialogResult deSpsL = MessageBox.Show(
                    "Tips: You can hide it instead of deleting it.\r\n\r\nContinue deleting?", "Delete sponsor logo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deSpsL == DialogResult.Yes)
            {
                int idSps = cbbOnSpsLSetting.SelectedIndex;
                switch (idSps)
                {
                    case 0: pbxSps1.Image = null; SpsLPath[0] = null; if (imFolderLink != null) SpsLIsDeleted[0] = true; break;
                    case 1: pbxSps2.Image = null; SpsLPath[1] = null; if (imFolderLink != null) SpsLIsDeleted[1] = true; break;
                    case 2: pbxSps3.Image = null; SpsLPath[2] = null; if (imFolderLink != null) SpsLIsDeleted[2] = true; break;
                    case 3: pbxSps4.Image = null; SpsLPath[3] = null; if (imFolderLink != null) SpsLIsDeleted[3] = true; break;
                    case 4: pbxSps5.Image = null; SpsLPath[4] = null; if (imFolderLink != null) SpsLIsDeleted[4] = true; break;
                    default: break;
                }
            }
        }
        private void showAllOnSLSetting_Click(object sender, EventArgs e)
        {
            pbxSps1.Visible = pbxSps2.Visible = pbxSps3.Visible = pbxSps4.Visible = pbxSps5.Visible = true;
            ShowingSpsL();
        }
        private void hideAllOnSLSetting_Click(object sender, EventArgs e)
        {
            pbxSps1.Visible = pbxSps2.Visible = pbxSps3.Visible = pbxSps4.Visible = pbxSps5.Visible = false;
            HidingSpsL();
        }
        private void deleteAllOnSLSetting_Click(object sender, EventArgs e)
        {
            //showOnSLSetting.Enabled = hideOnSLSetting.Checked = false;
            //showOnSLSetting.Checked = hideOnSLSetting.Enabled = false;
            //deleteOnSLSetting.Enabled = false;
            pbxSps1.Image = pbxSps2.Image = pbxSps3.Image = pbxSps4.Image = pbxSps5.Image = null;
            SpsLPath[0] = SpsLPath[1] = SpsLPath[2] = SpsLPath[3] = SpsLPath[4] = null;
            SpsLIsDeleted[0] = SpsLIsDeleted[1] = SpsLIsDeleted[2] = SpsLIsDeleted[3] = SpsLIsDeleted[4] = true;

            DeletingSpsL();
            SetSpsLShowAll.Enabled = SetSpsLHideAll.Enabled = SetSpsLDeleteAll.Enabled = false;
        }
        //
        // TOOL ------------------------------------------------------------------------
        //
        // TOOL - Groups Mode
        //
        private void ToolResetGroupsMode_Click(object sender, EventArgs e)
        {
            CreateNewInGroupsMode();
            ShowTeamsInPot(cbbPot.SelectedIndex);
        }
        private void uncheckAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ucAGroup ucAG in arrUcGroup)
            {
                ucAG.UncheckBox();
            }
        }
        private void ToolGroupsCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ucAGroup ucAG in arrUcGroup)
            {
                ucAG.CheckBox();
            }
        }
        //
        // TOOL - Show
        //
        private void nameOfLeagueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lbTextBox.Text = NameofLeague;
        }
        private void greetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTextBox.Text = Greeting;
        }
        private void logoOfLeagueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pbxLogo.Image = Drawing.LGI;
        }
        private void nameLogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lbTextBox.Text = NameofLeague;
            pbxLogo.Image = Drawing.LGI;
        }
        private void greetingLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTextBox.Text = Greeting;
            pbxLogo.Image = Drawing.LGI;
        }
        //
        // DRAWING MODE ------------------------------------------------------------------------------------
        //
        private void dRAWINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Drawing.Mode == null)
            {
                fMode f = new fMode();
                f.ShowDialog();
            }
            else if (Drawing.Mode == "Groups")
            {
                OldIdCbbPot = cbbPot.SelectedIndex;
                fGroups f = new fGroups();
                f.ShowDialog();
            }
            if (Drawing.Mode == "Groups")
            {
                if (Groups.CreateNew == true)
                {
                    SthChanged = true;
                    CreateNewInGroupsMode();
                    Groups.CreateNew = false;
                }
                if (Groups.Save == true)
                {
                    SthChanged = true;
                    LoadCbbPot();
                    cbbPot.SelectedIndex = OldIdCbbPot;
                    SetTitleGroups();
                    ShowTeamsInPot(cbbPot.SelectedIndex);
                    Groups.Save = false;
                }
                if (Groups.Save2 == true)
                {
                    SthChanged = true;
                    if (Groups.DropMode == "RightToLeft")
                    {
                        GroupsDropRighttoLeft();
                    }
                    else if (Groups.DropMode == "LeftToRight")
                    {
                        GroupsDropLefttoRight();
                    }
                    else
                    {
                        GroupsDropRandom();
                    }
                    if (Groups.IsDelay)
                    {
                        DelayIsTrue();
                    }
                    else
                    {
                        DelayIsFalse();
                    }
                    LoadCbbPot();
                    if (Groups.GroupsIsShown) SetTitleGroups();
                    Groups.Save2 = false;
                }

            }
        }
        void CreateNewInGroupsMode()
        {
            flpGroups1.Visible = false;
            flpGroups2.Visible = false;

            fResult obj = (fResult)Application.OpenForms["fResult"];
            if (obj != null) obj.Close();

            foreach (TeamsInGroupsMode ATeam in Groups.ArrPot)
            {
                if (ATeam != null)
                {
                    ATeam.IsDrawn = false;
                }
            }
            CreateGroups();
            SetTitleGroups();
            LoadCbbPot();


            flpGroups1.Visible = true;
            flpGroups2.Visible = true;

        }
        void AlignFlp1(int NoG1)
        {
            int x = 338 + (6 - NoG1) * 125;
            int y = 400 - SizeYUcAGroup / 2 + 34;
            flpGroups1.Location = new Point(x, y);
        }
        void AlignFlp2(int NoG2)
        {
            int x = 338 + (6 - NoG2) * 125;
            int y = 740 - SizeYUcAGroup / 2 + 34;
            flpGroups2.Location = new Point(x, y);
        }
        void AddToFlp1(int NoG1)
        {
            for (int g = 0; g < NoG1; g++)
            {
                ucAGroup ucAG = new ucAGroup();
                ucAG.Size = new Size(225, 42 + 34 * Groups.NumberOfPots + 2);
                ucAG.Add(Groups.NumberOfPots, g);
                flpGroups1.Controls.Add(ucAG);

                arrUcGroup[g] = ucAG;
            }
        }
        void AddToFlp2(int NoG2, int NoG1)
        {
            for (int g = NoG1; g < Groups.NumberOfGroups; g++)
            {
                ucAGroup ucAG = new ucAGroup();
                ucAG.Size = new Size(225, 42 + 34 * Groups.NumberOfPots + 2);
                ucAG.Add(Groups.NumberOfPots, g);
                flpGroups2.Controls.Add(ucAG);

                arrUcGroup[g] = ucAG;
            }
        }
        
        void CreateGroups()
        {

            flpGroups1.Controls.Clear();
            flpGroups2.Controls.Clear();

            Groups.ArrGroup = new TeamsInGroupsMode[Groups.NumberOfGroups, Groups.NumberOfPots];

            SizeYUcAGroup = 42 + 34 * Groups.NumberOfPots + 2 + 24;
            if (Groups.NumberOfGroups < 7)
            {
                int x = 338 + (6 - Groups.NumberOfGroups) * 125;
                int y = 570 - SizeYUcAGroup / 2 + 34;
                flpGroups1.Location = new Point(x, y);
            }
            else
            {
                if (Groups.NumberOfGroups % 2 == 0)
                {
                    AlignFlp1(Groups.NumberOfGroups / 2);
                    AlignFlp2(Groups.NumberOfGroups / 2);
                }
                else
                {
                    AlignFlp1((Groups.NumberOfGroups + 1) / 2);
                    AlignFlp2((Groups.NumberOfGroups - 1) / 2);
                }
            }

            arrUcTeamInGroups = new ucATeamInAGroup[Groups.NumberOfGroups, Groups.NumberOfPots];
            arrUcGroup = new ucAGroup[Groups.NumberOfGroups];

            if (Groups.NumberOfGroups < 7)
            {
                AddToFlp1(Groups.NumberOfGroups);
            }
            else
            {
                if (Groups.NumberOfGroups % 2 == 0)
                {
                    AddToFlp1(Groups.NumberOfGroups / 2);
                    AddToFlp2(Groups.NumberOfGroups / 2, Groups.NumberOfGroups / 2);
                }
                else
                {
                    AddToFlp1((Groups.NumberOfGroups + 1) / 2);
                    AddToFlp2((Groups.NumberOfGroups - 1) / 2, (Groups.NumberOfGroups + 1) / 2);
                }
            }

            Groups.GroupsIsShown = true;
            cmsitemShowResult.Enabled = true;

        }
        void SetTitleGroups()
        {
            for (int g = 0; g < Groups.NumberOfGroups; g++)
            {
                arrUcGroup[g].SetTittleGroup(Groups.ListTitleGroup[g]);
            }
        }
        private void cbbPot_SelectedIndexChanged(object sender, EventArgs e)
        {
            fResult obj = (fResult)Application.OpenForms["fResult"];
            if (obj != null) obj.Close();

            ShowTeamsInPot(cbbPot.SelectedIndex);

            if (Groups.ATeamsInAPotIsNull(cbbPot.SelectedIndex, Groups.NumberOfGroups))
            {
                btnDraw.Enabled = false;
            }
            else btnDraw.Enabled = true;

            lbTextBox.Text = cbbPot.SelectedValue.ToString();
        }
        //
        // ShowTeamsInPot
        //
        void LoadCbbPot()
        {
            if (Drawing.Mode == "Groups")
            {
                cbbPot.DataSource = Groups.ListTitlePot;
                cbbPot.SelectedIndex = Groups.NumberOfPots - 1;
                pnlListOfTeams.Visible = true;
            }
        }
        void ShowTeamsInPot(int i)
        {
            flpListOfTeams.Visible = false;
            arrUcATeamInDrawing = new ucATeamInDrawing[Groups.NumberOfGroups];
            flpListOfTeams.Controls.Clear();
            for (int k = 0; k < Groups.NumberOfGroups; k++)
            {
                ucATeamInDrawing ATeam = new ucATeamInDrawing(Groups.ArrPot[i, k]);
                flpListOfTeams.Controls.Add(ATeam);
                arrUcATeamInDrawing[k] = ATeam;
            }
            flpListOfTeams.Visible = true;
        }
        //
        // DRAW TOOL
        //
        private void ZoomIco_Click(object sender, EventArgs e)
        {
            fResult obj = (fResult)Application.OpenForms["fResult"];
            if (obj != null)
            {
                if (obj.WindowState == FormWindowState.Normal)
                    obj.WindowState = FormWindowState.Minimized;
                else obj.WindowState = FormWindowState.Normal;
            }
        }

        private void ZoomIco_MouseHover(object sender, EventArgs e)
        {
            pnlDropTool.BackColor = Color.Orange;
        }

        private void ZoomIco_MouseLeave(object sender, EventArgs e)
        {
            pnlDropTool.BackColor = Color.Transparent;
        }

        private void DropIco_Click(object sender, EventArgs e)
        {
            fResult obj = (fResult)Application.OpenForms["fResult"];
            if (obj != null)
            {
                DropIntoGroup();
            }
            else
            {
                btnDraw.Focus();
            }
        }

        private void DropIco_MouseHover(object sender, EventArgs e)
        {
            DropIco.BackColor = Color.Red;
        }

        private void DropIco_MouseLeave(object sender, EventArgs e)
        {
            DropIco.BackColor = Color.Transparent;
        }

        void GroupsDropRandom()
        {
            Groups.DropMode = "Random";
            RandomIco.BackColor = Color.Orange;
            RandomIco.BorderStyle = BorderStyle.FixedSingle;
            LeftRightIco.BackColor = RightLeftIco.BackColor = Color.Transparent;
            LeftRightIco.BorderStyle = RightLeftIco.BorderStyle = BorderStyle.None;
        }
        void GroupsDropLefttoRight()
        {
            Groups.DropMode = "LeftToRight";
            LeftRightIco.BackColor = Color.Orange;
            LeftRightIco.BorderStyle = BorderStyle.FixedSingle;
            RandomIco.BackColor = RightLeftIco.BackColor = Color.Transparent;
            RandomIco.BorderStyle = RightLeftIco.BorderStyle = BorderStyle.None;
        }

        private void DelayIco_Click(object sender, EventArgs e)
        {
            if (Groups.IsDelay)
            {
                DelayIsFalse();
                Groups.IsDelay = false;
            }
            else
            {
                DelayIsTrue();
                Groups.IsDelay = true;
            }
        }
        void DelayIsTrue()
        {
            DelayIco.BorderStyle = BorderStyle.FixedSingle;
            DelayIco.BackColor = Color.Orange;
        }
        void DelayIsFalse()
        {
            DelayIco.BorderStyle = BorderStyle.None;
            DelayIco.BackColor = Color.Transparent;
        }

        void GroupsDropRighttoLeft()
        {
            Groups.DropMode = "RightToLeft";
            RightLeftIco.BackColor = Color.Orange;
            RightLeftIco.BorderStyle = BorderStyle.FixedSingle;
            RandomIco.BackColor = LeftRightIco.BackColor = Color.Transparent;
            RandomIco.BorderStyle = LeftRightIco.BorderStyle = BorderStyle.None;
        }
        private void RandomIco_Click(object sender, EventArgs e)
        {
            GroupsDropRandom();
        }
        
        private void LeftRightIco_Click(object sender, EventArgs e)
        {
            GroupsDropLefttoRight();
        }     
        private void RightLeftIco_Click(object sender, EventArgs e)
        {
            GroupsDropRighttoLeft();
        }
        //
        // Click button DRAW ------------------------------------------------------------------------
        //

        List<int> ListIndexValidPot(int indexPot)
        {
            bool Null = true;
            List<int> ListId = new List<int>();

            for (int t = 0; t < Groups.NumberOfGroups; t++)
            {
                if (!Groups.ArrPot[indexPot, t].IsDrawn && arrUcATeamInDrawing[t].IsChecked)
                {
                    ListId.Add(t);
                    Null = false;
                }
            }

            if (Null) return null;
            else return ListId;
        }
        TeamsInGroupsMode GetATeamInDrawing(int indexPot, List<int> ListIdValidPot)
        {
            Random rdATeam = new Random();
            int indexTeam = ListIdValidPot[rdATeam.Next(ListIdValidPot.Count())];
            TeamsInGroupsMode ATeam = Groups.ArrPot[indexPot, indexTeam];

            TeamHasDrawn = ATeam;
            IndexPotHasDrawn = indexPot;
            IndexTeamHasDrawn = indexTeam;

            return ATeam;
        }
        void DrawingInGroupsMode()
        {        
            if (ListIndexValidPot(cbbPot.SelectedIndex) != null)
            {
                GetATeamInDrawing(cbbPot.SelectedIndex, ListIndexValidPot(cbbPot.SelectedIndex));
                fResult f = new fResult(TeamHasDrawn);

                //if (BackgroundImage != null && Drawing.BGI != null) f.Drawing.BGI = Drawing.BGI;
                //else f.Drawing.BGC = Drawing.BGC;
                f.NameOfLeague = NameofLeague;
                f.MyEventHandler += fResult_MyEventHandler; ;

                f.Show();

                if (Groups.FindSameReg)
                {
                    FindSameRegion();
                }
            }
            else
            {              
                if (cbbPot.SelectedIndex - 1 >= 0)
                {
                    cbbPot.SelectedIndex --;
                }
                //else
                //{
                //    MessageBox.Show("All teams in the pot are either unchecked or drawn", "No more teams in the pot",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                foreach (ucAGroup ucAG in arrUcGroup)
                {
                    ucAG.CheckBox();
                }
            }
        }
        private void fResult_MyEventHandler()
        {
            DropIntoGroup();
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {

            fResult obj = (fResult)Application.OpenForms["fResult"];
            if (obj == null )
            {
                DrawingInGroupsMode();
            }
            else
            {
                //if (obj.WindowState != FormWindowState.Normal)
                    obj.WindowState = FormWindowState.Normal;
                DropIco.Focus();
            }

        }
        //
        // FIND SAME REGION
        //
        async void FindSameRegion()
        {
            List<int> id = new List<int>();

            if (Groups.IsDelay) await Task.Delay(Groups.DelayTime);

            for (int g = 0; g < Groups.NumberOfGroups; g++)
                for (int t = 0; t < Groups.NumberOfPots; t++)
                {
                    if (Groups.ArrGroup[g,t] != null && arrUcGroup[g].IsChecked && Groups.ArrGroup[g, t].Region == TeamHasDrawn.Region)
                    {
                        arrUcGroup[g].MaroonPanel();
                        id.Add(g);
                        break;
                    }
                }

            if (Groups.IsDelay) await Task.Delay(Groups.DelayTime);
            if (id != null)
            {
                foreach (int i in id)
                {
                    arrUcGroup[i].UncheckBox();
                }
            }
        }
        //
        // DROP INTO GROUP
        //
        List<int> ListIndexValidGroup(int indexPot) // Group is Checked and Space left
        {
            bool Null = true;
            List<int> ListId = new List<int>();
            if (arrUcGroup == null) return null;
            else
            {
                for (int g = 0; g < Groups.NumberOfGroups; g++)
                {
                    if (arrUcGroup[g].IsChecked && arrUcTeamInGroups[g, indexPot].IsNull())
                    {
                        ListId.Add(g);
                        Null = false;
                    }
                }
            }

            if (Null) return null;
            else return ListId;
        }
        public void DropIntoGroup()
        {
            int row = IndexPotHasDrawn;
            int col;
            List<int> ListId = ListIndexValidGroup(row);

            if (ListId != null)
            {
                if (Groups.DropMode == "LeftToRight") col = ListId[0];
                else if (Groups.DropMode == "RightToLeft") col = ListId[ListId.Count() - 1];
                else
                {
                    Random rdAGroup = new Random();
                    col = ListId[rdAGroup.Next(ListId.Count())];
                }

                fResult obj = (fResult)Application.OpenForms["fResult"];
                if (obj != null) obj.Close();

                if (cbbPot.SelectedIndex == IndexPotHasDrawn)
                {
                    arrUcATeamInDrawing[IndexTeamHasDrawn].Enabled = false;
                }

                Groups.ArrPot[IndexPotHasDrawn, IndexTeamHasDrawn].IsDrawn = true;
                Groups.ArrGroup[col, row] = TeamHasDrawn;

                if (Groups.DropMode == "Random") Groups.Delay(Groups.DelayTime);
                else Groups.Delay(500);

                arrUcTeamInGroups[col, row].ShowInfo(TeamHasDrawn);

                arrUcGroup[col].RedPanel();

                CheckGroupsNotNull(col, row);

                //fResult obj = (fResult)Application.OpenForms["fResult"];
                //if (obj != null) obj.Close();
            }
            else
            {
                MessageBox.Show("There are no more groups to drop into. Please uncheck a group!", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        async void CheckGroupsNotNull(int col, int row)
        {
            if (Groups.IsDelay)
            {
                await Task.Delay(Groups.DelayTime);
                arrUcGroup[col].UncheckBox();
                for (int g = 0; g < Groups.NumberOfGroups; g++)
                {
                    if (g != col && arrUcTeamInGroups[g, row].IsNull()) arrUcGroup[g].CheckBox();
                }
            }
            else
            {
                for (int g = 0; g < Groups.NumberOfGroups; g++)
                {
                    if (g != col && arrUcTeamInGroups[g, row].IsNull()) arrUcGroup[g].CheckBox();
                }
                await Task.Delay(500);
                arrUcGroup[col].UncheckBox();
            }          
        }
        //
        // STAGE 3
        //
        
        //
        // Form Closing ------------------------------------------------------------------------
        //
        void ClosingProject(FormClosingEventArgs e)
        {
            if (imPrTxt == null) SettingChanged = true;
            else
            {
                BeforeExport();
                if (!exPrTxt.Equals(imPrTxt)) SettingChanged = true;
                else SettingChanged = false;
            }

            if (SthChanged || SettingChanged)
            {
                DialogResult diaRes = MessageBox.Show("Export to save changes?", "Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (diaRes == DialogResult.Yes)
                {
                    ExportWhenExit();
                    if (!exPorted)
                        e.Cancel = true;
                    else
                    {
                        e.Cancel = false;
                    }
                }
                //else if (diaRes == DialogResult.No) e.Cancel = false;
                else if (diaRes == DialogResult.Cancel) e.Cancel = true;
            }
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosingProject(e);
            SaveRePjtxt();
            SaveAllACSC();
        }
    }
}

        
