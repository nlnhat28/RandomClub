using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fExportResult : Form
    {
        public string ExLink { get; set; }
        string FileName;
        string paExPath;

        public bool ExportPicture { get; set; } = false;

        public fExportResult()
        {
            InitializeComponent();
        }

        void LoadCbb()
        {
            string[] FileType = { "Picture (*.png)", "Text (*.txt)"};
            cbbType.DataSource = FileType;
            cbbType.SelectedIndex = 0;
        }

        string ConvertToExtension(int Type)
        {
            string Extension = null;

            switch (Type)
            {
                case 0: Extension = ".png"; break; //Picture
                case 1: Extension = ".txt"; break; //Text
            }

            return Extension;
        }

        private void fExportResult_Load(object sender, EventArgs e)
        {
            LoadCbb();
            if (Drawing.Title != null) txbName.Text = FileName = Drawing.Title;
            if (Drawing.ImFolderLink != null)
            {
                paExPath = Drawing.ImFolderLink;
                txbPath.Text = ExLink = paExPath + "\\" + FileName + ConvertToExtension(cbbType.SelectedIndex);
                txbPath.SelectionStart = txbPath.Text.Length;
                btnExport.Enabled = true;
            }
            else btnExport.Enabled = false;
        }
        //
        // IsValid
        //
        bool IsValidFilename(string FolderName)
        {
            Regex containsABadCharacter = new Regex("["
                  + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");
            if (containsABadCharacter.IsMatch(FolderName)) { return false; };

            // other checks for UNC, drive-path format, etc

            return true;
        }
        bool IsValidPath(string PathText)
        {
            Regex containsABadCharacter = new Regex("["
                  + Regex.Escape(new string(Path.GetInvalidPathChars())) + "]");
            if (containsABadCharacter.IsMatch(PathText)) { return false; };

            // other checks for UNC, drive-path format, etc

            return true;
        }
        //
        // Back
        //
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        //
        // Browser
        //
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select where to save the file";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                paExPath = FBD.SelectedPath.ToString();
                txbPath.Text = ExLink = paExPath + "\\" + FileName + ConvertToExtension(cbbType.SelectedIndex);
                txbPath.SelectionStart = txbPath.Text.Length;
                btnExport.Enabled = true;
            }
        }
        //
        // Clear
        //
        private void lbClear_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
            txbName.Focus();
        }
        //
        // Cbb Changed
        //
        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ExLink != null)
            {
                txbPath.Text = ExLink = paExPath + "\\" + FileName.Trim() + ConvertToExtension(cbbType.SelectedIndex);
                txbPath.SelectionStart = txbPath.Text.Length;
            }
        }
        //
        // TextChanged
        //
        private void txbFolderName_TextChanged(object sender, EventArgs e)
        {
            FileName = txbName.Text;
            txbPath.Text = ExLink = paExPath + "\\" + FileName.Trim() + ConvertToExtension(cbbType.SelectedIndex);
            txbPath.SelectionStart = txbPath.Text.Length;
        }
        private void txbPath_TextChanged(object sender, EventArgs e)
        {
            ExLink = txbPath.Text;
        }
        //
        // Export
        //
        void RemoveInvalidChar()
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            txbName.Text = r.Replace(txbName.Text, "");
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            FileName = FileName.Trim();
            int Type = cbbType.SelectedIndex;

            if (string.IsNullOrWhiteSpace(FileName))
            {
                MessageBox.Show("File name cannot be null.",
                    "Error: file name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!IsValidFilename(FileName))
                {
                    DialogResult diaRes = MessageBox.Show("File name cannot contain any of the following characters: \\ / : * ? \" < > |\r\n\r\nPlease rename.\r\nOr click Yes to remove them.",
                        "Invalid Characters", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (diaRes == DialogResult.Yes) RemoveInvalidChar();
                }
                else
                {
                    if (File.Exists(ExLink))
                    {
                        DialogResult diaRes = MessageBox.Show("File name already exists!\r\n\r\nPlease rename.\r\nOr click Yes to overwrite.",
                        "Oops...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (diaRes == DialogResult.Yes)
                        {
                            if (Type == 0) ExportPicture = true;
                        }
                    }
                }
            }

            switch (Type)
            {
                case 0: if (ExportPicture == true) Close(); break;
                case 1: ExportText(ExLink); Close();  break;

                default: break;
            }
            
        }      
        
        //
        // TEXT
        //
        void ExportText(string SaveLink)
        {
            string Content = Drawing.Title + "\n\n";
            for (int g = 0; g < Groups.NumberOfGroups; g++)
            {
                Content += Groups.ListTitleGroup[g].ToUpper() + "\n";
                for (int t = 0; t < Groups.NumberOfPots; t++)
                {
                    if (Groups.ArrGroup[g, t] != null)
                    {
                        Content += Groups.ArrGroup[g, t].FullName;
                    }
                    else Content += "NULL";
                    Content += "\n";
                }
                Content += "\n";
            }

            FileStream fs = new FileStream(SaveLink, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
         
            sw.Write(Content);

            sw.Close();
            fs.Close();

            MessageBox.Show("Text was saved at the link: " + SaveLink, "Screenshot successful!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
