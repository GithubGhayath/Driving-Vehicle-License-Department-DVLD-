using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        
        private void _LoadDataToScreen()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUserName.Text = clsGlobleUser.CurrentUser.UserName;
        }

        private void ctrlSelectLicense1_OnLicenseSelected(int obj)
        {
            if (clsDetainedAndReleasedLiceneseBusinessLayer.IsLicenseDetained(obj)) 
            {
                MessageBox.Show("Selected License already Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = obj;
            }
            else
            {
                _LicenseID = obj;
                btnDetain.Enabled = true;
                lblkShowLicenseHistory.Enabled = true;
                lblShowLicenseInfo.Enabled = true;
                lblLicenseID.Text = _LicenseID.ToString();
            }
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
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

        private void _DetainedLicense()
        {
            clsDetainedAndReleasedLiceneseBusinessLayer LicenseForDetain = new clsDetainedAndReleasedLiceneseBusinessLayer();
            LicenseForDetain.DetainDate = Convert.ToDateTime(lblDetainDate.Text);
            LicenseForDetain.LicenseID = _LicenseID;
            LicenseForDetain.FineFees = Convert.ToDecimal(txtFees.Text);
            LicenseForDetain.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
            LicenseForDetain.IsReleased = false;

            if(LicenseForDetain.Save())
            {
                lblDetainID.Text = LicenseForDetain.DetainID.ToString();
                MessageBox.Show("License Detained Successfully with ID : " + _LicenseID, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlSelectLicense1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Something wrong while detain! : ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to detain this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                _DetainedLicense();
                btnDetain.Enabled = false;
            }
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicenseInformation = new frmDriverLicenseInformation(0, _LicenseID);
            frmShowLicenseInformation.ShowDialog();
        }

        private void lblkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowLicensesHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(_LicenseID).DriverID).PersonID);
            frmShowLicensesHistory.ShowDialog();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
                    { e.Handled = true; return; }
        }
    }
}
