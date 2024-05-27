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
    public partial class frmTakeTests : Form
    {
        public frmTakeTests()
        {
            InitializeComponent();
        }

        private int _AppoitmentID;
 
        public frmTakeTests(int AppointmentID,string Title,string Imagepath)
        {
            InitializeComponent();
            _AppoitmentID=AppointmentID;
            ctrlShowScheduleTestInfo1.AppointmentID = AppointmentID;
            ctrlShowScheduleTestInfo1.Title = Title;
            ctrlShowScheduleTestInfo1.ImagePath = Imagepath;
        }

        private void _DefualtInformatins()
        {
            rdbPass.Checked = true;
        }

       

        private void frmTakeTests_Load(object sender, EventArgs e)
        {
            _DefualtInformatins();


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

        private void _LoadTestToDataBase()
        {
            //For fill Tests Table
            bool PassedOrFail = (rdbFail.Checked == true) ? false : true;
            string Notes = (string.IsNullOrEmpty(txtNotes.Text) == true) ? null : txtNotes.Text;

            (bool, int) Result = clsTestsBusinessLayar.InsertNewTestRecord(_AppoitmentID, PassedOrFail, Notes, clsGlobleUser.CurrentUser.UserID);
            

        }

        private bool LookedAppointment(int AppointmentID)
        {
            clsTestAppointmentsBusinessLayar TemplutAppointment = clsTestAppointmentsBusinessLayar.Find(AppointmentID);

            TemplutAppointment.IsLocked = true;
            return TemplutAppointment.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save? you cannt change the pass fail results after you save","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                _LoadTestToDataBase();
                btnSave.Enabled = false;

                //for Update Appointment
                if (LookedAppointment(_AppoitmentID))
                {  //Here We will write the code for count the test that passed by client
                    MessageBox.Show("Data Saved Successfully!", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Something Wrong!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            
           
        }
    }
}
