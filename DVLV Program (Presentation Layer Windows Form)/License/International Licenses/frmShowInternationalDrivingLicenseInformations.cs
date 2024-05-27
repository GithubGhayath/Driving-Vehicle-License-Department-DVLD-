using DVLDBusinessLayar;
using DVLV_Program.Properties;
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
    public partial class frmShowInternationalDrivingLicenseInformations : Form
    {

        private int _InternationalLicenseID;
        public frmShowInternationalDrivingLicenseInformations()
        {
            InitializeComponent();
        }

        public frmShowInternationalDrivingLicenseInformations(int internationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = internationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadDateToScreen()
        {
            clsInternationalLicensesBusinessLayar InternationalLicens = clsInternationalLicensesBusinessLayar.FindByInternationalLicenseID(_InternationalLicenseID);
            clsApplicationsBusinessLayar Application = clsApplicationsBusinessLayar.Find(InternationalLicens.ApplicationID);
            clsPeopleBusinessLayar Person = clsPeopleBusinessLayar.Find(Application.ApplicantPersonID);

            lblName.Text = Person.GetFillName();
            lblInternationalLicenseID.Text = InternationalLicens.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = InternationalLicens.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text=Person.NationalNo.ToString();
            lblGender.Text = Person.Gendor.ToString();
            lblIssueDate.Text = InternationalLicens.IssueDate.ToShortDateString();
            lblApplicationID.Text = Application.ApplicationID.ToString();
            lblIsActive.Text = InternationalLicens.IsActive.ToString();
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = InternationalLicens.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicens.ExpirationDate.ToShortDateString();

            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                if (Person.Gendor == "Male")
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

            
        }

        private void frmShowInternationalDrivingLicenseInformations_Load(object sender, EventArgs e)
        {
            _LoadDateToScreen();

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
