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
    public partial class ctrlShowScheduleTestInfo : UserControl
    {
        public int AppointmentID;

        public string Title;

        public string ImagePath;

        
        private void _LoadDataToScreen()
        {
            string ColorHexCode = string.Format("#1E2974");
            label8.ForeColor = System.Drawing.ColorTranslator.FromHtml(ColorHexCode);
            lblLDAppID.Text = AppointmentID.ToString();
            lblDClass.Text = clsLicenseClassesBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(clsTestAppointmentsBusinessLayar.Find(AppointmentID).LocalDrivingLicenseApplicationID).LicenseClassID).ClassName.ToString();
            lblPersonName.Text = clsPeopleBusinessLayar.Find(clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(clsTestAppointmentsBusinessLayar.Find(AppointmentID).LocalDrivingLicenseApplicationID).ApplicationID).ApplicantPersonID).GetFillName();
            lblTrial.Text = 0.ToString();
            lblDate.Text=clsTestAppointmentsBusinessLayar.Find(AppointmentID).AppointmentDate.ToString();
            lblFees.Text = clsTestAppointmentsBusinessLayar.Find(AppointmentID).PaidFees.ToString();
            lblTestID.Text = "Not Teken yet";
            pbImagePath.Image = Image.FromFile(ImagePath);
        }
        public ctrlShowScheduleTestInfo()
        {
            InitializeComponent();
        }

        private void ctrlShowScheduleTestInfo_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                _LoadDataToScreen();
        }
    }
}
