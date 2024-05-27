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
    public partial class frmEarnInternationalLIcense : Form
    {
        //Comes from Selected License Control
        private int _LicenseID;

        //Current License for some checks operations
        clsLicensesBusinessLayar License = new clsLicensesBusinessLayar();

        //For New Application
        clsApplicationsBusinessLayar InternationalLicense = new clsApplicationsBusinessLayar();
        clsInternationalLicensesBusinessLayar NewInternationalLicense = new clsInternationalLicensesBusinessLayar();
        //Result Of All Checks Operations
        private bool _TheEndResult = false;

        public frmEarnInternationalLIcense()
        {
            InitializeComponent();
        }

        private void ctrlSelectLicense1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            if (clsLicensesBusinessLayar.Find(_LicenseID) != null)
            {
                _TheEndResult = _SomeChecksWhenLicenseSelected();

                if(_TheEndResult==false)
                {
                    btnIssue.Enabled = false;
                    lblkShowInternationalLicenseInfo.Enabled = false;
                    lblkShowLicenseHistory.Enabled = false;
                }
                else
                {
                    btnIssue.Enabled = true;
                    lblkShowInternationalLicenseInfo.Enabled = false;
                    lblkShowLicenseHistory.Enabled = true;
                    _LoadNewApplicationDataToScreen();
                }
            }
            
        }

        private bool _IsLLiceneClassEqualThree()
        {
            //The First Method will Execute
             License = clsLicensesBusinessLayar.Find(_LicenseID);

            if (License.LicenseClass == 3)
            {
                return true;
            }
            else
            { MessageBox.Show("The selected driving certificate is not a third category.", "You can't confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }


        }

        private bool _IsLicenseActive()
        {
            //True : License Active
            //False : License Not Active
            if (License.IsActive == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The selected driving certificate is not active", "You can't confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool _IsLicenseNotExpired()
        {
            /*
             *  Less than zero: If date1 is earlier than date2.
                Zero: If date1 is the same as date2.
                Greater than zero: If date1 is later than date2.
             */

            DateTime CurrentDate = DateTime.Now;
            int result = (DateTime.Compare(CurrentDate, License.ExpirationDate));
            if (result <= 0)
                return true;
            else
            {
                MessageBox.Show("The selected driving certificate has expired", "You can't confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //True  : License Not Exrired
            //False : License Exrired
        }

        private bool _IsLicenseActiveAndNotExpired()
        {
            return (_IsLicenseActive() && _IsLicenseNotExpired());

            //True : License Active and Not Expired
            //Fales : Other...
        }

        private bool _SomeChecksWhenLicenseSelected()
        {
            return (_IsLLiceneClassEqualThree() && _IsLicenseActiveAndNotExpired());
            // True : ready for generate international license
            //False : There is a condition dose not exsist
        }

        private void _LoadNewApplicationDataToScreen()
        {
            lblInternationalLicenseID.Text = "???";
            lblInternationalApplicationID.Text = "???";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationTypeBusinessLayar.Find(6).Fees.ToString();
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblExpirtDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedByUserID.Text = clsGlobleUser.CurrentUser.UserName;
        }

        //For Butten Issue
        private void _CreateAnApplicationTypeInternationalLicense()
        {
          


            if (_TheEndResult)
            {
                InternationalLicense.ApplicantPersonID = clsDriversBusinessLayar.Find(License.DriverID).PersonID;
                InternationalLicense.ApplicationTypeID = 6;//New International License
                InternationalLicense.ApplicationStatus = 1;
                InternationalLicense.LastStatusDate = DateTime.Now;
                InternationalLicense.PaidFees = clsApplicationTypeBusinessLayar.Find(6).Fees;
                InternationalLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

                if(InternationalLicense.Save())
                {
                    NewInternationalLicense = new clsInternationalLicensesBusinessLayar();

                    NewInternationalLicense.ApplicationID = InternationalLicense.ApplicationID;
                    NewInternationalLicense.DriverID = clsLicensesBusinessLayar.Find(_LicenseID).DriverID;
                    NewInternationalLicense.IssuedUsingLocalLicenseID = _LicenseID;
                    NewInternationalLicense.IssueDate = DateTime.Now;
                    NewInternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                    NewInternationalLicense.IsActive = true;
                    NewInternationalLicense.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

                }
            }
        
            

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsInternationalLicensesBusinessLayar.FindByDriverID(clsDriversBusinessLayar.Find(License.DriverID).DriverID) != null)
            {
                MessageBox.Show("You cannot issue more than one international license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _CreateAnApplicationTypeInternationalLicense();

        

            if (NewInternationalLicense.Save())
            {
                MessageBox.Show("An international license has been issued With ID : " + NewInternationalLicense.InternationalLicenseID, "Done Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something is wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            lblInternationalLicenseID.Text = NewInternationalLicense.InternationalLicenseID.ToString();
            lblInternationalApplicationID.Text = NewInternationalLicense.ApplicationID.ToString();
            lblkShowInternationalLicenseInfo.Enabled = true;
            btnIssue.Enabled = false;
            ctrlSelectLicense1.Enabled = false;
        }

        private void lblkShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowInternationalLicens = new frmShowInternationalDrivingLicenseInformations(NewInternationalLicense.InternationalLicenseID);
            frmShowInternationalLicens.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenseHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).DriverID).PersonID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void frmEarnInternationalLIcense_Load(object sender, EventArgs e)
        {
            lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1e2974");
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
