using System.Drawing;

namespace RANDOM_CLUB
{
    public class TeamsInGroupsMode
    {
        //public int ID { get; set; }
        public string LogoLink { get; set; } = null;
        public Image Logo { get; set; } = null;
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }

        //public bool IsChecked { get; set; } = true;
        public bool IsDrawn { get; set; } = false;
    }
}
