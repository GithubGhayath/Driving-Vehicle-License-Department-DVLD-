using DVLDBusinessLayar;
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
    public partial class frmNewLicense : Form
    {
        private int _LDLApplicationID;
        public frmNewLicense()
        {
            InitializeComponent();
        }

        public frmNewLicense(int lDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = lDLApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLicense_Load(object sender, EventArgs e)
        {
            ctrlApplicationsInformation1._LDAppID = _LDLApplicationID;
            ctrlApplicationsInformation1._LoadDataToScreen();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplicationsBusinessLayar License = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(_LDLApplicationID);
            clsApplicationsBusinessLayar Application = clsApplicationsBusinessLayar.Find(License.ApplicationID);

            //Creating New Driver
            clsDriversBusinessLayar NewDriver =new clsDriversBusinessLayar();
            NewDriver.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
            NewDriver.PersonID = Application.ApplicantPersonID;
            NewDriver.CreatedDate = DateTime.Now;

            if(NewDriver.Save())
            {
                clsLicensesBusinessLayar NewLicense = new clsLicensesBusinessLayar();
                NewLicense.ApplicationID = License.ApplicationID;
                NewLicense.DriverID = NewDriver.DriverID;
                NewLicense.LicenseClass = License.LicenseClassID;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpirationDate = NewLicense.IssueDate.AddYears(clsLicenseClassesBusinessLayar.Find(License.LicenseClassID).DefaultValidityLength);
                NewLicense.Notes = (string.IsNullOrEmpty(txtNotes.Text)) ? null : txtNotes.Text;
                NewLicense.PaidFees = clsApplicationTypeBusinessLayar.Find(Application.ApplicationTypeID).Fees;
                NewLicense.IsActive = true;
                NewLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
                NewLicense.IssueReason = 1;//Means the license is new

                if(NewLicense.Save())
                {
                    MessageBox.Show("License Issued Successfully With License ID : " + NewLicense.LicenseID, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.ApplicationStatus = 2;
                }
                else
                {
                    MessageBox.Show("Something Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            btnSave.Enabled = false;
            txtNotes.Enabled=false;
        }
    }
}
