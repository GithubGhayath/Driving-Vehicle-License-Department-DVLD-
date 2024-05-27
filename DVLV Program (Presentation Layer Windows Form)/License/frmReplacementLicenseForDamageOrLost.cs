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
    public partial class frmReplacementLicenseForDamageOrLost : Form
    {
        public frmReplacementLicenseForDamageOrLost()
        {
            InitializeComponent();
        }

        private int _LicensID;

        clsApplicationsBusinessLayar _NewApplication = new clsApplicationsBusinessLayar();

        clsLicensesBusinessLayar _NewLicense = new clsLicensesBusinessLayar();

        clsLicensesBusinessLayar OldLicense = new clsLicensesBusinessLayar();
        private void ctrlSelectLicense1_OnLicenseSelected(int obj)
        {
            if(clsLicensesBusinessLayar.IsLicenseActive(obj)==false)
            {
                _DefualtInfromationToScreen();
                _LicensID = obj;
                MessageBox.Show("Selected Licens is not Active ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                lblkShowNewLicenseInfo.Enabled = false;
                rbDamaged.Enabled = false;
                rbLost.Enabled = false;
            }
            else
            {
                _LicensID = obj;
                btnIssueReplacement.Enabled = true;
                lblkShowLicenseHistory.Enabled = true;
                rbDamaged.Enabled = true;
                rbLost.Enabled = true;
                _LoadApplicationDataToScreen(); 
                lblLicenseFees.Text = clsLicenseClassesBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicensID).LicenseClass).ClassFees.ToString();
                _UpdatePrices();
            }
        }

        private void _DefualtInfromationToScreen()
        {
            lblApplicationDate.Text = "[???]";
            lblApplicationFees.Text = "[???]";
            lblApplicationID.Text = "[???]";
            lblCreatedByUserName.Text = "[???]";
            lblReplacedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";
            lblLicenseFees.Text = "[???]";
            lblCreatedByUserName.Text = "[???]";
            lblTotalPrice.Text = "[???]";
        }
        private void _LoadApplicationDataToScreen()
        {
            //L.R.Application ID , Replaced License ID not avalible 

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblOldLicenseID.Text = _LicensID.ToString();
            lblCreatedByUserName.Text = clsGlobleUser.CurrentUser.UserName;
            
            //it is last for when checked the event will fired
            rbDamaged.Checked = true;
        }

        private void _CreateAnApplication()
        {
            _NewApplication.ApplicantPersonID = clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicensID).DriverID).PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.ApplicationTypeID = ((rbDamaged.Checked == true) ? Convert.ToInt32(rbDamaged.Tag) : Convert.ToInt32(rbLost.Tag));
            _NewApplication.ApplicationStatus = 1; //New Application
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _NewApplication.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
        }

        private void _CreateNewLicense()
        {
            //For fill Application Details
            _CreateAnApplication();

            if (_NewApplication.Save())
            {
                OldLicense = clsLicensesBusinessLayar.Find(_LicensID);
                _NewLicense.ApplicationID = _NewApplication.ApplicationID;
                _NewLicense.DriverID = OldLicense.DriverID;
                _NewLicense.LicenseClass = OldLicense.LicenseClass;
                _NewLicense.IssueDate = DateTime.Now;
                _NewLicense.ExpirationDate = (_NewLicense.IssueDate.AddYears(clsLicenseClassesBusinessLayar.Find(_NewLicense.LicenseClass).DefaultValidityLength));
                _NewLicense.Notes = null;
                _NewLicense.PaidFees = Convert.ToDecimal(lblLicenseFees.Text);
                _NewLicense.IsActive = true;
                _NewLicense.IssueReason = Convert.ToByte((rbDamaged.Checked == true) ? Convert.ToInt32(rbDamaged.Tag) : Convert.ToInt32(rbLost.Tag));
                _NewLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

                if(_NewLicense.Save())
                {
                    clsApplicationsBusinessLayar.UpdateApplicationStatus(_NewApplication.ApplicationID, "complete");

                    if(clsLicensesBusinessLayar.UpdateLicenseActivation(_LicensID, false))
                    {
                        MessageBox.Show("The license has been replaced, The New License ID : " + _NewLicense.LicenseID, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while disabling the old license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {

                    MessageBox.Show("An error occurred while adding the New License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("An error occurred while adding the ِApplication", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReplacementLicenseForDamageOrLost_Load(object sender, EventArgs e)
        {
            _LoadApplicationDataToScreen();

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

        private void _AfterLicenseIssued()
        {
            lblApplicationID.Text = _NewApplication.ApplicationID.ToString();
            lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
            lblkShowNewLicenseInfo.Enabled = true;
            btnIssueReplacement.Enabled = false;
            rbDamaged.Enabled = false;
            rbLost.Enabled = false;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to complete the replacement process?","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                _CreateNewLicense();
                _AfterLicenseIssued();
            }
        }

        private void _UpdatePrices()
        {
            lblApplicationFees.Text = clsApplicationTypeBusinessLayar.Find((rbDamaged.Checked == true) ? Convert.ToInt32(rbDamaged.Tag) : Convert.ToInt32(rbLost.Tag)).Fees.ToString();
            if (lblLicenseFees.Text != "[???]")
                lblTotalPrice.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblLicenseFees.Text)).ToString();
            else
                lblTotalPrice.Text = "[???]";
        }


        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                _UpdatePrices();
            }
            else if (rbDamaged.Checked)
            {
                _UpdatePrices();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenseHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicensID).DriverID).PersonID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void lblkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowNewLicenseInfo = new frmDriverLicenseInformation(0, _NewLicense.LicenseID);
            frmShowNewLicenseInfo.ShowDialog();
        }
    }
}
