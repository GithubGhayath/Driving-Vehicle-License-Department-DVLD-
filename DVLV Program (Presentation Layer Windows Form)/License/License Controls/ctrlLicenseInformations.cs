using DVLDBusinessLayar;
using DVLV_Program.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class ctrlLicenseInformations : UserControl
    {
        public int LDLApplicationID;

        public int LicenseID = -1;
        public ctrlLicenseInformations()
        {
            InitializeComponent();
        }

        private void _LoadDataToScreen()
        {
            clsLocalDrivingLicenseApplicationsBusinessLayar LocalLicenseApplication = new clsLocalDrivingLicenseApplicationsBusinessLayar();
            clsApplicationsBusinessLayar Application = new clsApplicationsBusinessLayar();
            clsPeopleBusinessLayar Person = new clsPeopleBusinessLayar();
            clsDriversBusinessLayar Driver = new clsDriversBusinessLayar();
            clsLicensesBusinessLayar License=new clsLicensesBusinessLayar();
            clsLicenseClassesBusinessLayar ClassInformation = new clsLicenseClassesBusinessLayar();


            if (LicenseID == -1)
            {
                 LocalLicenseApplication = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLApplicationID);
                 Application = clsApplicationsBusinessLayar.Find(LocalLicenseApplication.ApplicationID);
                 Person = clsPeopleBusinessLayar.Find(Application.ApplicantPersonID);
                 ClassInformation = clsLicenseClassesBusinessLayar.Find(LocalLicenseApplication.LicenseClassID);
                 License = clsLicensesBusinessLayar.FindByApplicationID(Application.ApplicationID);
                 Driver = clsDriversBusinessLayar.FindByPersonID(Application.ApplicantPersonID);

            }
            else
            {
                 License = clsLicensesBusinessLayar.Find(LicenseID);
                 Driver = clsDriversBusinessLayar.Find(License.DriverID);
                 ClassInformation = clsLicenseClassesBusinessLayar.Find(License.LicenseClass);
                 Application = clsApplicationsBusinessLayar.Find(License.ApplicationID);
                 Person = clsPeopleBusinessLayar.Find(Application.ApplicantPersonID);
            }

            lblClassName.Text = ClassInformation.ClassName;
            lblName.Text = Person.GetFillName();
            lblLicenseID.Text = License.LicenseID.ToString();
            lblNationalNo.Text = Person.NationalNo;
            lblGender.Text = Person.Gendor;
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
            lblIsActive.Text = (License.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = Driver.DriverID.ToString();
            lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();

            if (string.IsNullOrEmpty(License.Notes))
            {
                lblNotes.Text = "No Notes.";
            }
            else
                lblNotes.Text = License.Notes;

            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                if (Person.Gendor.Trim() == "Male")
                {
                    pbPersonPhoto.Image = Resources.Male1;
                }
                else
                {
                    pbPersonPhoto.Image = Resources.Female1;
                }
            }
            else
                pbPersonPhoto.Image = Image.FromFile(Person.ImagePath);

            lblIssueReason.Text = (License.IssueReason == 1) ? "First Time" : (License.IssueReason == 2) ? "Renew" : (License.IssueReason == 3) ? "Lost" : "Damaged";
            lblIsDetained.Text = (clsDetainedAndReleasedLiceneseBusinessLayer.IsLicenseDetained(LicenseID)) ? "Yes" : "No";

        }

        public void ShowLicenseInformation()
        {
            _LoadDataToScreen();
        }
    }
}
