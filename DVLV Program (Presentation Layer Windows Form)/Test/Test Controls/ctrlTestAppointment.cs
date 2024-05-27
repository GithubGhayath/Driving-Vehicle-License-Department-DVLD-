using DVLDBusinessLayar;
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
    public partial class ctrlTestAppointment : UserControl
    {
        public ctrlTestAppointment()
        {
            InitializeComponent();
        }

        clsTestAppointmentsBusinessLayar Appointment = new clsTestAppointmentsBusinessLayar();

        //For Load Data to Scressn
        public int LDLAppID { get; set; }
        //For Load Data To Screen and table Appointment
        public int TestTypeID { get; set; }

        // For Screen
        public string Title { get; set; }

        //For Screen
        public string ImagePath { get; set; }


        //For Edit Appointment
        public int AppointmentID = -1;


        public bool IsAppointmentEmpty = true;

        private void _LoadInformationToScreen()
        {
            
            lblRAppFees.Text = "???";
            lblRTestAppID.Text = "N/A";
            lblTotalFees.Text = "???";

            lblRetakeTestTitle.Enabled = false;
            lblRAppFees.Enabled = false;
            lblRTestAppID.Enabled = false;
            lblTotalFees.Enabled = false;

            lblDLAppID.Text = LDLAppID.ToString();
            lblDClass.Text = clsLicenseClassesBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).LicenseClassID).ClassName;
            lblName.Text = clsPeopleBusinessLayar.Find(clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).ApplicationID).ApplicantPersonID).GetFillName();
            lblTrial.Text = 0.ToString();
            dtpDate.Value = DateTime.Now;
            lblFees.Text = clsTestTypesBusinessLayar.Find(TestTypeID).TestFees.ToString();
            pbPhotoTitle.Image = Image.FromFile(ImagePath);
            lblTestTitle.Text = Title;

            //For Edit Appointment
            if (AppointmentID != -1)
            {
                //Check Appointment is Looked befor edit?
                if (clsTestAppointmentsBusinessLayar.Find(AppointmentID).IsLocked == true)
                {
                    btnSave.Enabled = false;
                    dtpDate.Enabled = false;
                    bool Reslts = clsTestsBusinessLayar.Find(AppointmentID).TestResult;

                    lblMessageForUser.Text = (Reslts == true) ? "Person already Pass for this test, Appointment loocked." : "Person already Fail for this test, Appointment loocked.";
                    lblMessageForUser.Visible = true;
                
                }
                if (!IsAppointmentEmpty)
                {
                    if (clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(clsTestAppointmentsBusinessLayar.Find(AppointmentID).LocalDrivingLicenseApplicationID).ApplicationID).ApplicationTypeID == 8)
                    {
                        lblRTestAppID.Text = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(clsTestAppointmentsBusinessLayar.Find(AppointmentID).LocalDrivingLicenseApplicationID).ApplicationID.ToString();

                    }
                }
            }

            if (!IsAppointmentEmpty)
            {
                if (clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).ApplicationID).ApplicationTypeID == 8)
                {
                    lblRTestAppID.Text = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).ApplicationID.ToString();
                    lblRAppFees.Text = clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).ApplicationID).PaidFees.ToString();
                    lblTotalFees.Text = (Convert.ToDecimal(clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLAppID).ApplicationID).PaidFees)
                                            + Convert.ToDecimal(clsTestTypesBusinessLayar.Find(TestTypeID).TestFees)).ToString();

                    lblRetakeTestTitle.Enabled = true;
                    lblRAppFees.Enabled = true;
                    lblRTestAppID.Enabled = true;
                    lblTotalFees.Enabled = true;
                }
            }
        }

     
        private void _LoadAppointmentToDataBase()
        {

            if (AppointmentID == -1)
            {
                Appointment.TestTypeID = TestTypeID;
                Appointment.LocalDrivingLicenseApplicationID = LDLAppID;
                Appointment.AppointmentDate = dtpDate.Value;
                Appointment.PaidFees = Convert.ToDecimal(lblFees.Text);
                Appointment.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;
                Appointment.IsLocked = false;

            }
            else
            {
                Appointment = clsTestAppointmentsBusinessLayar.Find(AppointmentID);
                Appointment.AppointmentDate = dtpDate.Value;
            }

         

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _LoadAppointmentToDataBase();

            if (Appointment.Save())
            {
                MessageBox.Show("Appointment Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Something Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ctrlTestAppointment_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) 
                _LoadInformationToScreen();
        }

      
    }
}
