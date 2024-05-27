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
    public partial class frmDriverLicenseInformation : Form
    {

        private int _LDLAppliationID;

        private int _LicenseID = -1;
        public frmDriverLicenseInformation()
        {
            InitializeComponent();
        }


        public frmDriverLicenseInformation(int lDLAppliationID,int LicenseID=-1)
        {
            InitializeComponent();
            _LDLAppliationID = lDLAppliationID;
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicenseInformation_Load(object sender, EventArgs e)
        {
            if (_LicenseID == -1)
            {
                ctrlLicenseInformations1.LDLApplicationID = _LDLAppliationID;
                ctrlLicenseInformations1.ShowLicenseInformation();
            }
            else
            {
                ctrlLicenseInformations1.LicenseID = _LicenseID;
                ctrlLicenseInformations1.ShowLicenseInformation();
            }

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
    }
}
