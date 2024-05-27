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
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        private DataTable _LicenseClass = clsLicenseClassesBusinessLayar.GetAllLicenseClasses();
        private int _ApplicationTypeID = 1;
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _LoadLicenseClasses()
        {
            foreach(DataRow dr in _LicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }
        }

        private void _DefaultInformations()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            _LoadLicenseClasses();
            lblApplicationFees.Text = clsApplicationTypeBusinessLayar.Find(_ApplicationTypeID).Fees.ToString();
            lblCreatedBy.Text = clsGlobleUser.CurrentUser.UserName;
            btnSave.Enabled = false;

        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _DefaultInformations();

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




        // This objects only for Load Data from Control To Data Base
        clsApplicationsBusinessLayar NewApplication = new clsApplicationsBusinessLayar();
        clsLocalDrivingLicenseApplicationsBusinessLayar NewLicense = new clsLocalDrivingLicenseApplicationsBusinessLayar();


        private bool _CheckIsThereSameApplicationWithSamePerson()
        {
            return false ;

        }

        private bool _LoadDataFromControlsToNewObjects()
        {
            if (clsApplicationsBusinessLayar.IsClientHasANewApplicationToAComplitApplication(ctrlSelectPerson1.PersonID, _ApplicationTypeID))
            {
                MessageBox.Show("Choose Another License Class, The Selected Person Already Have a active Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                NewApplication.ApplicantPersonID = ctrlSelectPerson1.PersonID;
                NewApplication.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
                NewApplication.ApplicationTypeID = _ApplicationTypeID;
                NewApplication.ApplicationStatus = 1;// Number 1 means that Application is (new)
                NewApplication.LastStatusDate = DateTime.Now;
                NewApplication.PaidFees = clsApplicationTypeBusinessLayar.Find(_ApplicationTypeID).Fees;
                NewApplication.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
                NewLicense.LicenseClassID = clsLicenseClassesBusinessLayar.Find(cbLicenseClass.SelectedItem.ToString()).LicenseClassID;

                return true;
            }
        }

        private bool _LoadObjectsToDataBase()
        {
            //Fill Objects with data from Controls
            if (_LoadDataFromControlsToNewObjects())
            {

                bool IsAppicationAdded = false;
                if (NewApplication.Save())
                {
                    IsAppicationAdded = true;
                }
                else
                    MessageBox.Show("Something wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (IsAppicationAdded)
                {
                    NewLicense.ApplicationID = NewApplication.ApplicationID;
                    if (NewLicense.Save())
                    {
                        MessageBox.Show("Application License Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("There is a problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_LoadObjectsToDataBase())
            {
                lblDLApplicationID.Text = NewLicense.LocalDrivingLicenseApplicationID.ToString();
                btnSave.Enabled = false;
            }
        
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0) { btnSave.Enabled = false; }
            else { btnSave.Enabled = true; }
        }
    }
}
