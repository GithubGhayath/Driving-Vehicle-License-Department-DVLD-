using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }

        private int _LicenseID;
        clsApplicationsBusinessLayar _NewApplication =new clsApplicationsBusinessLayar();
        clsLicensesBusinessLayar OldLicense = new clsLicensesBusinessLayar();
        clsLicensesBusinessLayar NewLicense = new clsLicensesBusinessLayar();
        private void ctrlSelectLicense1_OnLicenseSelected(int obj)
        {
            if(!clsLicensesBusinessLayar.IsTheLicenseExpired(obj))
            {
                MessageBox.Show("Selected License is not expiared, it will expire on : " + clsLicensesBusinessLayar.Find(obj).ExpirationDate.ToShortDateString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
            }
            else
            {
                _LicenseID = obj;
                _InfoForScreenWhenDrivingLicenseSelected();
                btnRenew.Enabled = true;
                linkLabel1.Enabled = true;

            }
        }

        private void _LoadDefualtApplicationInformationToScreen()
        {
            //Two missing info:
            //    1- R.L.ApplicationID
            //    2- RenewedLicenseID 

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypeBusinessLayar.Find(2).Fees.ToString();
            lblCreatedByUserName.Text = clsGlobleUser.CurrentUser.UserName;          
        }

        private void _InfoForScreenWhenDrivingLicenseSelected()
        {
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(Convert.ToInt32(clsLicenseClassesBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).LicenseClass).DefaultValidityLength)).ToString();
            lblLicenseFees.Text = clsLicenseClassesBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).LicenseClass).ClassFees.ToString();
            lblTotalFees.Text = Convert.ToString(Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblLicenseFees.Text));
        }

        private void _LoadInformationToNewApplication()
        {
            //For Copy All Old Infomations to new license
             OldLicense = clsLicensesBusinessLayar.Find(_LicenseID);

            _NewApplication.ApplicantPersonID = clsDriversBusinessLayar.Find(OldLicense.DriverID).PersonID;
            _NewApplication.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            _NewApplication.ApplicationTypeID = 2; //Renew Applcation
            _NewApplication.ApplicationStatus = 1; //New Application
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _NewApplication.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;


        }

        private void _CreateNewLicense()
        {
            if (MessageBox.Show("Are you sure you want to renew the license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _LoadInformationToNewApplication();

                if (_NewApplication.Save())
                {


                    NewLicense.ApplicationID = _NewApplication.ApplicationID;
                    NewLicense.DriverID = OldLicense.DriverID;
                    NewLicense.LicenseClass = OldLicense.LicenseClass;
                    NewLicense.IssueDate = DateTime.Now;
                    NewLicense.ExpirationDate = Convert.ToDateTime(lblExpirationDate.Text);
                    NewLicense.Notes = txtNotes.Text;
                    NewLicense.PaidFees = Convert.ToDecimal(lblLicenseFees.Text);
                    NewLicense.IsActive = true;
                    NewLicense.IssueReason = 2; //Means The License is Renew Licinse
                    NewLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

                    if (NewLicense.Save())
                    {
                        clsLicensesBusinessLayar.UpdateLicenseActivation(_LicenseID, false);
                        _NewApplication.ApplicationStatus = 2;
                        _NewApplication.Save();

                        lblRenewApplicationID.Text = _NewApplication.ApplicationID.ToString();
                        lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                        MessageBox.Show("License Renewed Successfully with ID : " + NewLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Something is wrong in creating new license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    //Whene The new application desen't save
                    MessageBox.Show("Something is wrong in Creating Application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadDefualtApplicationInformationToScreen();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            _CreateNewLicense();
            btnRenew.Enabled = false;
            linkLabel2.Enabled = true;
            ctrlSelectLicense1.Enabled = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmLocalLicenceInfo = new frmDriverLicenseInformation(0,NewLicense.LicenseID);
            frmLocalLicenceInfo.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenseHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).DriverID).PersonID);
            frmShowLicenseHistory.ShowDialog();
        }
    }
}
