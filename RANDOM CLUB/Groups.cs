using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace RANDOM_CLUB
{
    public class Groups
    {
        //TeamsInGroupsMode TIGM = new TeamsInGroupsMode();
        public static int NumberOfTeams { get; set; } = 1;
        public static int NumberOfPots { get; set; } = 1;
        public static string TitlePot { get; set; } = "POT ";
        public static int OTPot { get; set; } = 0;


        public static int NumberOfGroups { get; set; } = 1;
        public static string TitleGroup { get; set; } = "GROUP ";
        public static int OTGroup { get; set; } = 1;

        public static bool CreateNew { get; set; } = false;
        public static bool GroupsIsShown { get; set; } = false;

        public static bool Save { get; set; } = false;
        public static bool Save2 { get; set; } = false;

        public static string DropMode { get; set; } = "Random"; //Random / LeftToRight / RightToLeft

        public static bool IsDelay { get; set; } = true;
        public static int DelayTime { get; set; } = 1000;

        public static void Delay(int Time)
        {
            if (IsDelay)
            {
                Thread.Sleep(Time);
            }
        }

        public static List<string> ListTitlePot { get; set; }
        public static List<string> ListTitleGroup { get; set; }

        public static bool FindSameReg { get; set; } = false;


        //public static List<TeamsInGroupsMode> ListTeamInPot { get; set; }
        //public static List<Groups.ListTeamInPot> ListPot { get; set; }

        public static TeamsInGroupsMode[,] ArrPot { get; set; }

        public static TeamsInGroupsMode[,] ArrGroup { get; set; }

        public static List<string> ListTitleVsOT(string Title, string[] ArrOT, int NumberOfSth)
        {
            List<string> TitleVsOT = new List<string>();
            for (int k = 0; k < NumberOfSth; k++)
            {
                TitleVsOT.Add(Title + ArrOT[k]);
            }
            return TitleVsOT;
        }

        public static string[] GetNameArrOT(int OT)
        {
            string[] ArrOT = new string[12];
            if (OT == 0) ArrOT = OrderType.Num;
            if (OT == 1) ArrOT = OrderType.Alphabet;
            if (OT == 2) ArrOT = OrderType.RomanNum;
            return ArrOT;
        }

        public static bool ATeamsInAPotIsNull(int indexPot, int LengthPot)
        {
            for (int k=0; k < LengthPot; k++)
            {
                if (ArrPot[indexPot, k] == null)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static TeamsInGroupsMode GetTeamFromFolder(string imTeamLink)
        {
            TeamsInGroupsMode ATeam = new TeamsInGroupsMode();

            string LogoLink = imTeamLink + "\\Logo.png";
            if (File.Exists(LogoLink))
            {
                ATeam.LogoLink = LogoLink;
                ATeam.Logo = new Bitmap(LogoLink);
            }
            else
            {
                ATeam.LogoLink = null;
                ATeam.Logo = null;
            }

            string NameTxtLink = imTeamLink + "\\Name.txt";
            if (File.Exists(NameTxtLink))
            {
                FileStream fs = new FileStream(NameTxtLink, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                ATeam.FullName = sr.ReadLine();
                ATeam.ShortName = sr.ReadLine();
                ATeam.Region = sr.ReadLine();

                sr.Dispose();
                sr.Close();
                fs.Dispose();
                fs.Close();
            }
            else
            {
                ATeam.FullName = null;
                ATeam.ShortName = null;
                ATeam.Region = null;
            }

            ATeam.IsDrawn = false;

            return ATeam;
        }
    }
}
