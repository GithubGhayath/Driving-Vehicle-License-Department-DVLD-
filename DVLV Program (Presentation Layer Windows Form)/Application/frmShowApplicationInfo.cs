using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmShowApplicationInfo : Form
    {
        public frmShowApplicationInfo()
        {
            InitializeComponent();
        }
        private int _ApplicationID;
        public frmShowApplicationInfo(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }

        private void frmShowApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlApplicationInformation1.ApplicationID = _ApplicationID;
            ctrlApplicationInformation1.ShowApplicationDetails();

            //For Show This form Smothly
            double opacity = 0.00;
            while (opacity < 1)
            {
                this.Opacity = opacity;
                opacity += 0.1; // Adjust the increment as needed
                Application.DoEvents(); // Allow UI updates
                Thread.Sleep(1); // Optional delay for smoother effect
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
