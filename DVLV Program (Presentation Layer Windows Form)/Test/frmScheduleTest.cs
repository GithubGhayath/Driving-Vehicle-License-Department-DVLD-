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
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest()
        {
            InitializeComponent();
        }

        public frmScheduleTest(int LDLAppID, string Title, string ImagePath, int TestTypeID, int AppointmentID = -1,bool IsAppointmentEmpty=false)
        {
            InitializeComponent();
            ctrlTestAppointment1.LDLAppID = LDLAppID;
            ctrlTestAppointment1.Title = Title;
            ctrlTestAppointment1.ImagePath = ImagePath;
            ctrlTestAppointment1.TestTypeID = TestTypeID;
            ctrlTestAppointment1.AppointmentID = AppointmentID;
            ctrlTestAppointment1.IsAppointmentEmpty = IsAppointmentEmpty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
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
