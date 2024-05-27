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
    public partial class frmSechduleTestMainForm : Form
    {


        public frmSechduleTestMainForm()
        {
            InitializeComponent();
        }


        private int _LDAppId;
        private string _Title;  //Fixed the value in code
        private string _ImagePath; //Fixed the value in code
        private int _TestTypeID; //Fixed the value in code

        //For Appointment
        private int _RowIndex;
        private int _ColumnIndex;



        //For New Application
        private string _LicenseClassName=string.Empty;

        public frmSechduleTestMainForm(int appID,string Title,string ImagePath,int TestTypeID,string LicenseClassName="")
        {
            InitializeComponent();

            _LDAppId = appID;
            _Title = Title;
            _ImagePath = ImagePath;
            _TestTypeID = TestTypeID;
            _LicenseClassName = LicenseClassName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Load Appoitment Based On LocalDrivingLicense ID
        private void _LoadAppointmnets()
        {
            dgvAppointments.DataSource = clsTestAppointmentsBusinessLayar.GetAllAppointments(_LDAppId, _TestTypeID);
        }

        //Load Data To Screen
        private void frmSechduleVisionTest_Load(object sender, EventArgs e)
        {
            _LoadAppointmnets();
            ctrlApplicationsInformation1._LDAppID = _LDAppId;
            ctrlApplicationsInformation1._LoadDataToScreen();
            lblRecordCount.Text=dgvAppointments.RowCount.ToString();

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

        private void _RefrshDataGredView()
        {
            _LoadAppointmnets();
        }

        //For check If Active Appointment Befor Add New Appointment
        private bool IsThereAnAppointmentActive()
        {
            foreach(DataGridViewRow Row in dgvAppointments.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[3].Value) == false) 
                    return true;
            }
            return false;
        }

    
        private bool _IsPersonPassThisTest()
        {


            foreach (DataGridViewRow Row in dgvAppointments.Rows)
            {

                if (clsTestAppointmentsBusinessLayar.Find(Convert.ToInt32(Row.Cells[0].Value)).TestTypeID == _TestTypeID)
                {
                    if (clsTestsBusinessLayar.Find(Convert.ToInt32(Row.Cells[0].Value)).TestResult == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool _IsAppointmentEmpty()
        {
            return dgvAppointments.Rows.Count == 0;
            //true : Data Gread View Empty
            //false : There is an Appointment
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (IsThereAnAppointmentActive())
            {
                MessageBox.Show("Person Already have an active appointment for this test, you can't add new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_IsPersonPassThisTest())
            {
                MessageBox.Show("Person Already Passed This Test", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_IsAppointmentEmpty())
            {
                Form TestAppointment = new frmScheduleTest(_LDAppId, _Title, _ImagePath, _TestTypeID, IsAppointmentEmpty: true);
                TestAppointment.ShowDialog();
                _RefrshDataGredView();
                return;
            }

            if (_IsPersonPassThisTest()==false)
            {
                clsLocalDrivingLicenseApplicationsBusinessLayar TempRecord = clsLocalDrivingLicenseApplicationsBusinessLayar.Find(_LDAppId);
                clsApplicationsBusinessLayar RetakeTestApplication = new clsApplicationsBusinessLayar();
                RetakeTestApplication.ApplicantPersonID = clsApplicationsBusinessLayar.Find(TempRecord.ApplicationID).ApplicantPersonID;
                RetakeTestApplication.ApplicationDate = DateTime.Now;
                RetakeTestApplication.ApplicationTypeID = 8;
                RetakeTestApplication.ApplicationStatus = 1;
                RetakeTestApplication.LastStatusDate= DateTime.Now;
                RetakeTestApplication.PaidFees = clsApplicationTypeBusinessLayar.Find(_TestTypeID).Fees;
                RetakeTestApplication.CreatedByUserID = clsGlobleUser.CurrentUser.UserID;

                if(RetakeTestApplication.Save())
                {
                    //For Update The Record With New Application 
                    TempRecord.ApplicationID = RetakeTestApplication.ApplicationID;

                    if(TempRecord.Save())
                    {
                        Form TestAppointment = new frmScheduleTest(_LDAppId, _Title, _ImagePath, _TestTypeID);
                        TestAppointment.ShowDialog();
                        _RefrshDataGredView();
                        return;
                    }
                }

            }
           
        }


        //For Show The Result Of Looked Appointment
        private bool IsAppointmentLooked(int AppointmentID)
        {
            if (clsTestAppointmentsBusinessLayar.Find(AppointmentID).IsLocked)
            {
                Form ShowTestInformations = new frmScheduleTest(_LDAppId, _Title, _ImagePath, _TestTypeID, AppointmentID);
                ShowTestInformations.ShowDialog();
                return true;
            }
            else
                return false;
        }





        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(dgvAppointments.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmEditAppointmentInfo = new frmScheduleTest(_LDAppId, _Title, _ImagePath, _TestTypeID, AppointmentID);
            frmEditAppointmentInfo.ShowDialog();
            _RefrshDataGredView();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int AppointmentID = Convert.ToInt32(dgvAppointments.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            if (IsAppointmentLooked(AppointmentID) == false)
            {
                Form frmTaketest = new frmTakeTests(AppointmentID, _Title, _ImagePath);
                frmTaketest.ShowDialog();
                _RefrshDataGredView();
            }
        }
      




        //For Indecate The Index of Row
        private void dgvAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = 0;
        }

    }
}
