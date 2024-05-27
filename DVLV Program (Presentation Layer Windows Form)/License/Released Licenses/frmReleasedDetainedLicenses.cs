using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmReleasedDetainedLicenses : Form
    {
        private int _LicenseID;

        clsApplicationsBusinessLayar _ReleaseApplication = new clsApplicationsBusinessLayar();
        public frmReleasedDetainedLicenses()
        {
            InitializeComponent();
        }

        public frmReleasedDetainedLicenses(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        public void MakeSelectLicenseControlDisable()
        {
            ctrlSelectLicense1.Enabled = false;
            ctrlSelectLicense1.FillTextBoxWithLicenseIDForSearch(_LicenseID);
            ctrlSelectLicense1.ClickButton();
        }

        private void _CreateReleasApplication()
        {
            // 5 : Release License
            _ReleaseApplication.ApplicantPersonID = clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).DriverID).PersonID;
            _ReleaseApplication.ApplicationDate = DateTime.Now;
            _ReleaseApplication.ApplicationTypeID = 5;
            _ReleaseApplication.ApplicationStatus = 1;   //means new application
            _ReleaseApplication.LastStatusDate = DateTime.Now;
            _ReleaseApplication.PaidFees = clsApplicationTypeBusinessLayar.Find(5).Fees;
            _ReleaseApplication.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

        }

        private void _ReleasLicense()
        {
            _CreateReleasApplication();

            if (_ReleaseApplication.Save())
            {
                clsDetainedAndReleasedLiceneseBusinessLayer ReleasLicense = clsDetainedAndReleasedLiceneseBusinessLayer.FindByLicenseID(_LicenseID);

                ReleasLicense.ReleaseDate = DateTime.Now;
                ReleasLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
                ReleasLicense.ReleaseApplicationID = _ReleaseApplication.ApplicationID;

                if (ReleasLicense.Save())
                {
                    MessageBox.Show("Detained License Release Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblApplicationID.Text = _ReleaseApplication.ApplicationID.ToString();
                }
                else
                    MessageBox.Show("Field Release License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Field Creation Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void ctrlSelectLicense1_OnLicenseSelected(int obj)
        {
            if(!clsDetainedAndReleasedLiceneseBusinessLayer.IsLicenseDetained(obj))
            {
                MessageBox.Show("Selected license is not Detain", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
            }
            else
            {
                _LicenseID = obj;
                btnRelease.Enabled = true;
                klblShowLicenseHistory.Enabled = true;
                klblShowLicenseInformation.Enabled = true;
                _LoadDataToScreen();
                _LoadDataToScreenAfterSelectLicense();
            }
        }

        private void _LoadDataToScreen()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypeBusinessLayar.Find(5).Fees.ToString();
            lblCreatedByUserName.Text = clsGlobleUser.CurrentUser.UserName;
        }
        
        private void _LoadDataToScreenAfterSelectLicense()
        {
            clsDetainedAndReleasedLiceneseBusinessLayer DetainedLicense = clsDetainedAndReleasedLiceneseBusinessLayer.FindByLicenseID(_LicenseID);
            //Dosen't show until select license
            lblFineFees.Text = DetainedLicense.FineFees.ToString();
            lblTotalFees.Text = Convert.ToString(Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text));
            lblLicenseID.Text = _LicenseID.ToString();

            lblDetainID.Text = DetainedLicense.DetainID.ToString();

        }
        private void klblShowLicenseInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenseInformation = new frmDriverLicenseInformation(0, _LicenseID);
            frmShowLicenseInformation.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you want to release this detained license","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                _ReleasLicense();
                btnRelease.Enabled = false;

            }
        }

        private void frmReleasedDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadDataToScreen();

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

        private void klblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenceHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).DriverID).PersonID);
            frmShowLicenceHistory.ShowDialog();
        }

        
    }
}
