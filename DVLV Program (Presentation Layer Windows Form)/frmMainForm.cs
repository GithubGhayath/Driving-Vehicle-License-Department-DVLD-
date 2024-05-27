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
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

     
      
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPeopleForm = new frmPeopleForm();
            frmPeopleForm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenNewFormOnClose = true;
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUserManagment = new frmManageUsers();
            frmUserManagment.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form CurrentUser = new frmShowPersonDetails(clsGlobleUser.CurrentUser.PersonID);

            CurrentUser.ShowDialog();
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowApplicationList = new frmShowApplicationList();

            frmShowApplicationList.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmTestTypes = new frmTestTypes();

            frmTestTypes.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmChangePassword = new frmChangePassword(clsGlobleUser.CurrentUser.UserID);
            frmChangePassword.ShowDialog();
        }

        private void localLinceseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddNewLocalLicense = new frmNewLocalDrivingLicenseApplication();
            frmAddNewLocalLicense.ShowDialog();
        }

        private void localDrivingLicenseApplicatioinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLocalLicenseManage=new frmLocalDrivingLicenseApplicationsScreen();
            frmLocalLicenseManage.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDriversScreen = new frmDriversListScreen();
            frmDriversScreen.ShowDialog();
        }

        private void internationalLinceseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmNewInternationalLicense = new frmEarnInternationalLIcense();
            frmNewInternationalLicense.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowManageInternationalLicenseScreen = new frmManageInternationalLicenses();
            frmShowManageInternationalLicenseScreen.ShowDialog();
        }

        private void renewDrivingLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmRenewLicense = new frmRenewDrivingLicense();
            frmRenewLicense.ShowDialog();
        }

        private void replacementForLostOfDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmReplacementScreen = new frmReplacementLicenseForDamageOrLost();
            frmReplacementScreen.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDetainScreen = new frmDetainLicense();
            frmDetainScreen.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmReleaseLicenseScreen = new frmReleasedDetainedLicenses();
            frmReleaseLicenseScreen.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowDetainManagment = new frmShowDetainedManagment();
            frmShowDetainManagment.Show();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowReleasDetainedLicenseScreen = new frmReleasedDetainedLicenses();
            frmShowReleasDetainedLicenseScreen.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowManageLocalDrivingLicenseApplications = new frmLocalDrivingLicenseApplicationsScreen();
            frmShowManageLocalDrivingLicenseApplications.ShowDialog();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            string HexCode = "#e2e7ea";
            Color MyColoer = System.Drawing.ColorTranslator.FromHtml(HexCode);
            menuStrip1.BackColor = MyColoer;

            //For Show This form Smothly
            double opacity = 0.00;
            while (opacity < 1)
            {
                this.Opacity = opacity;
                opacity += 0.10; // Adjust the increment as needed
                Application.DoEvents(); // Allow UI updates
                Thread.Sleep(2); // Optional delay for smoother effect
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
