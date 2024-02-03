using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fExport : Form
    {
        public string exFolderName { get; set; }
        public bool exported { get; set; }
        public string exPath { get; set; }

        string paExPath;

        public fExport()
        {
            InitializeComponent();      
        }
        //
        // Form Load
        //
        private void fExport_Load(object sender, EventArgs e)
        {
            txbName.Text = exFolderName;
            exported = false;
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
        // Browesr
        //
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select where to save the exported folder";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                paExPath = FBD.SelectedPath.ToString();
                txbPath.Text = exPath = paExPath + "\\" + exFolderName;
                btnExport.Enabled = true;
                txbPath.SelectionStart = txbPath.Text.Length;
            }        
        }
        //
        // TextChanged
        //
        private void lbClear_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
            txbName.Focus();
        }
        private void txbFolderName_TextChanged(object sender, EventArgs e)
        {
            exFolderName = txbName.Text;
            txbPath.Text  = exPath = paExPath + "\\" + exFolderName.Trim();
            txbPath.SelectionStart = txbPath.Text.Length;
            //if (string.IsNullOrWhiteSpace(exFolderName))
            //    btnExport.Enabled = false;
            //else btnExport.Enabled = true;
        }
        private void txbPath_TextChanged(object sender, EventArgs e)
        {
            exPath = txbPath.Text;
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
            exFolderName = exFolderName.Trim();

            if (string.IsNullOrWhiteSpace(exFolderName))
            {
                MessageBox.Show("Folder name cannot be null.",
                    "Error: folder name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!IsValidFilename(exFolderName))
                {
                    DialogResult diaRes = MessageBox.Show("Folder name cannot contain any of the following characters: \\ / : * ? \" < > |\r\n\r\nPlease rename.\r\nOr click Yes to remove them.",
                        "Invalid Characters", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (diaRes == DialogResult.Yes) RemoveInvalidChar();
                }
                else
                {
                    if (Directory.Exists(exPath))
                    {
                        DialogResult diaRes = MessageBox.Show("Folder already exists!\r\n\r\nPlease rename.\r\nOr click Yes to rename automatically.",
                        "Oops...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (diaRes == DialogResult.Yes)
                        {
                            while (Directory.Exists(exPath))
                            {
                                exPath = exPath + " - Copy";
                            }
                            MessageBox.Show("New Path is: " + exPath,
                                "Renamed successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            exported = true;
                            Close();
                        }
                    }
                    else
                    {
                        exported = true;
                        Close();
                    }
                }
            }
        }

    }
}
