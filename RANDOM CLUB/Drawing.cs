using System.Drawing;

namespace RANDOM_CLUB
{
    public class Drawing
    {
        public static string ImFolderLink { get; set; }

        public static string Mode { get; set; }
        public static string Title { get; set; }
        public static string PlaceDate { get; set; }
        public static Image BGI { get; set; }
        public static bool BGIsImage { get; set; }

        public static Image LGI { get; set; }
        public static bool LogoIsHide { get; set; }

        public static Color BGC { get; set; }
        public static Color DefaultColor { get; set; } = Color.MidnightBlue;
    }
}
