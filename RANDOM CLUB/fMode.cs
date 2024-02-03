using System;
using System.Windows.Forms;

namespace RANDOM_CLUB
{
    public partial class fMode : Form
    {
        public fMode()
        {
            InitializeComponent();
        }
        //
        // LOAD Form
        //
        private void fMode_Load(object sender, EventArgs e)
        {
        }
        //
        // click GROUPS MODE
        //
        private void btnGroups_Click(object sender, EventArgs e)
        {
            fGroups f = new fGroups();
            f.ShowDialog();
        }
        //
        // click KNOCK-OUT MODE
        //

        // Btn BACK
        //
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
