using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayar;

namespace DVLV_Program
{
    public partial class ctrlApplicationsInformation : UserControl
    {
        
        public int _LDAppID;
        clsApplicationsBusinessLayar Application = new clsApplicationsBusinessLayar();
        clsLocalDrivingLicenseApplicationsBusinessLayar LicenseApplication = new clsLocalDrivingLicenseApplicationsBusinessLayar();
        clsLicenseClassesBusinessLayar Class=new clsLicenseClassesBusinessLayar();
        clsApplicationTypeBusinessLayar AppType=new clsApplicationTypeBusinessLayar();
        public ctrlApplicationsInformation()
        {
            InitializeComponent();
        }

        private void _FillClassesFromDataBase()
        {
            LicenseApplication = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(_LDAppID);
            Application = clsApplicationsBusinessLayar.Find(LicenseApplication.ApplicationID);
            Class = clsLicenseClassesBusinessLayar.Find(LicenseApplication.LicenseClassID);
            AppType = clsApplicationTypeBusinessLayar.Find(Application.ApplicationTypeID);
        }

        public void _LoadDataToScreen()
        {
            // To Fill Object from Data Base
            _FillClassesFromDataBase();

            lblDLAppID.Text = LicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = Class.ClassName;
            lblTestPassed.Text = clsLocalDrivingLicenseApplicationsBusinessLayar.CountTestsThatPersonPassed(Application.ApplicantPersonID).ToString() + "/3";

            lblApplicationID.Text = Application.ApplicationID.ToString();
            lblApplicationStatus.Text = clsApplicationStatusBusinessLayar.Find(Application.ApplicationStatus).StatusName;
            lblApplicationFees.Text = AppType.Fees.ToString();
            lblApplicaitonType.Text = AppType.Title;
            lblApplicant.Text = clsPeopleBusinessLayar.Find(Application.ApplicantPersonID).GetFillName();
            lblApplicationDate.Text=Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text=Application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsUserDataBusinessLayar.Find(Application.CreatedByUserID).UserName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowPersonDetails = new frmShowPersonDetails(Application.ApplicantPersonID);

            frmShowPersonDetails.ShowDialog();
        }
    }
}
