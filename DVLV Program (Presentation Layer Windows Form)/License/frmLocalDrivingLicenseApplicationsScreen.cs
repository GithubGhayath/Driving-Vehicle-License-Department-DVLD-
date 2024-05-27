using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmLocalDrivingLicenseApplicationsScreen : Form
    {
        private int _RowIndex;
        private int _ColumnIndex;
        private int _VisionTest = 1;
        private int _WriteTest = 2;
        private int _StreetTest = 3;


        private string _VisionTestImage = @"C:\Users\ghaya\OneDrive\Desktop\DVDL Project\Images\visionTestMain.jpg";
        private string _WriteTestImage  = @"C:\Users\ghaya\OneDrive\Desktop\DVDL Project\Images\WriteTestMain.png";
        private string _StreetTestImage = @"C:\Users\ghaya\OneDrive\Desktop\DVDL Project\Images\StreetTestMain.png";

        public frmLocalDrivingLicenseApplicationsScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLocalLicense_Click(object sender, EventArgs e)
        {

            Form frmAddNewLocalLicense = new frmNewLocalDrivingLicenseApplication();
            frmAddNewLocalLicense.ShowDialog();
        }
       
        private void _LoadStatusCompoBox()
        {
            DataTable Status = clsApplicationStatusBusinessLayar.GetAllStatus();

            foreach(DataRow Row in Status.Rows)
            {
                cbStatusType.Items.Add(Row["Status"]);
            }
        }

        private void _LoadDataToDataGredView()
        {
            dgvLocalApplications.DataSource = clsLocalDrivingLicenseApplicationsBusinessLayar.GetAllLocalDrivingLicenseApplications();
            _LoadStatusCompoBox();
            cbFilterBy.SelectedItem = "None";

            //LocalDrivingLicenseApplicationID	ClassName	NationalNo	full_name	ApplicationDate	Passed Tests	Status
            //"LDL AppID"
            //"Driving Class"
            //"National No"
            //"Full Name"
            //"Application Date"
            //"Passed Tests"
            //"Status"b




            //For Custom Size
            dgvLocalApplications.Columns["LocalDrivingLicenseApplicationID"].Width = 60;
            dgvLocalApplications.Columns["NationalNo"].Width = 70;
            dgvLocalApplications.Columns["ClassName"].Width = 140;
            dgvLocalApplications.Columns["full_name"].Width = 150;
            dgvLocalApplications.Columns["ApplicationDate"].Width = 100;
            dgvLocalApplications.Columns["PassedTests"].Width = 50;
            dgvLocalApplications.Columns["Status"].Width = 60;

            //For Custom Columns Name
            dgvLocalApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "LDLAppID";
            dgvLocalApplications.Columns["NationalNo"].HeaderText = "NationalNo";
            dgvLocalApplications.Columns["ClassName"].HeaderText = "DrivingClass";
            dgvLocalApplications.Columns["full_name"].HeaderText = "FullName";
            dgvLocalApplications.Columns["ApplicationDate"].HeaderText = "ApplicationDate";
            dgvLocalApplications.Columns["PassedTests"].HeaderText = "PassedTests";
            dgvLocalApplications.Columns["Status"].HeaderText = "Status";
        }

        private void _RefrshDataGridView()
        {
            _LoadDataToDataGredView();
        }

        private void frmLocalDrivingLicenseApplicationsScreen_Load(object sender, EventArgs e)
        {
            _LoadDataToDataGredView();
            _FillFilterCompoBox();
            lblCount.Text = dgvLocalApplications.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
            cbStatusType.SelectedIndex = 0;

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

        private void _FillFilterCompoBox()
        {
            foreach (DataGridViewColumn Column in dgvLocalApplications.Columns)
                cbFilterBy.Items.Add(Column.Name.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString()=="None")
            {
                lblEnter.Visible = false;
                txtInputFilter.Visible = false;
                cbStatusType.Visible = false;
            }
            else if(cbFilterBy.SelectedItem.ToString()== "Status")
            {
                lblEnter.Text = "Choose:";
                lblEnter.Visible = true;
                txtInputFilter.Visible = false;
                cbStatusType.Visible = true;
            }
            else
            {
                lblEnter.Text = "Enter:";
                lblEnter.Visible = true;
                txtInputFilter.Visible = true;
                cbStatusType.Visible = false;
            }
        }
        private void _ValidationMenueContext(int LDLApplicationID, int PassedTest,string ApplicationStatus)
        {
          

            if (ApplicationStatus.ToLower()== "canceled")
            {
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                //For (Edit - Delete - Cancel) Application
                if (clsLicensesBusinessLayar.FindByApplicationID(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLApplicationID).ApplicationID) != null)
                {
                    editApplicationToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                }
                else
                {
                    editApplicationToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                }

                //Sechdult Test Item
                if (PassedTest == 3)
                {
                    sechduleTestsToolStripMenuItem.Enabled = false;
               
                    clsApplicationsBusinessLayar.UpdateApplicationStatus(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLApplicationID).ApplicationID, "complete");
                }
                else
                {
                    sechduleTestsToolStripMenuItem.Enabled = true;
                }

                //For Enable Issue License
                if (PassedTest == 3 && clsLicensesBusinessLayar.FindByApplicationID(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDLApplicationID).ApplicationID) == null)
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                }
                else
                {
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                }

                //For Show License
                if (issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled == false && PassedTest == 3)
                {
                    showLicenseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    showLicenseToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void dgvLocalApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = 0;
            if (_RowIndex != -1 && _ColumnIndex == 0)
            {
                string ApplicationStats = Convert.ToString(dgvLocalApplications.Rows[_RowIndex].Cells[6].Value); //Status in Column index = 6
                int PassedTest = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[5].Value); //Passed Test in Column index = 5
                int LDLApp = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
                _ValidationMenueContext(LDLApp, PassedTest, ApplicationStats);
            }
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);

            clsApplicationsBusinessLayar.UpdateApplicationStatus(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDAppID).ApplicationID, "Canceled");
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            string ClassLicenseName = Convert.ToString(dgvLocalApplications.Rows[_RowIndex].Cells[1].Value);
            Form frmShowSechduleVisionForm = new frmSechduleTestMainForm(LDAppID, "Vision Test", _VisionTestImage, _VisionTest, ClassLicenseName);
            frmShowSechduleVisionForm.ShowDialog();
            _RefrshDataGridView();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            string ClassLicenseName = Convert.ToString(dgvLocalApplications.Rows[_RowIndex].Cells[1].Value);
            Form frmShowSechduleVisionForm = new frmSechduleTestMainForm(LDAppID, "Write Test", _WriteTestImage, _WriteTest, ClassLicenseName);
            frmShowSechduleVisionForm.ShowDialog();
            _RefrshDataGridView();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            string ClassLicenseName = Convert.ToString(dgvLocalApplications.Rows[_RowIndex].Cells[1].Value);
            Form frmShowSechduleVisionForm = new frmSechduleTestMainForm(LDAppID, "Street Test", _StreetTestImage, _StreetTest, ClassLicenseName);
            frmShowSechduleVisionForm.ShowDialog();
            _RefrshDataGridView();
        }


        //For Enable The Test Based on any test that passed?
        private void sechduleTestsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);  //LocalDrivingLicenseID

            if (clsTestsBusinessLayar.IsPersonPassedTest(LDAppID, 1))
            {

                sechduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;

            }
            else
            {
                sechduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }

            if (clsTestsBusinessLayar.IsPersonPassedTest(LDAppID, 2))
            {
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsTestsBusinessLayar.IsPersonPassedTest(LDAppID, 3))
            {
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else
            {
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
                return;
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmNewLicense = new frmNewLicense(LDAppID);
            frmNewLicense.ShowDialog();
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            _RefrshDataGridView();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmLicense = new frmDriverLicenseInformation(LDAppID);
            frmLicense.ShowDialog();
            _RefrshDataGridView();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);

            Form frmShowApplicationInfo = new frmShowApplicationInfo(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDAppID).ApplicationID);
            frmShowApplicationInfo.ShowDialog();

            _RefrshDataGridView();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);

            if(MessageBox.Show("Are you sure you want to delete this Application?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                if(clsLocalDrivingLicenseApplicationsBusinessLayar.Delete(LDAppID))
                {
                    MessageBox.Show("Deleted Successfully!", "Done", MessageBoxButtons.OK);
                    _RefrshDataGridView();
                }
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon...", "Soon");
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDAppID = Convert.ToInt32(dgvLocalApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowLicenseHistory = new frmShowAllLicensesHistory(clsApplicationsBusinessLayar.Find(clsLocalDrivingLicenseApplicationsBusinessLayar.Find(LDAppID).ApplicationID).ApplicantPersonID);
            frmShowLicenseHistory.ShowDialog();
            _RefrshDataGridView();
        }
        
        private void _FillterDataGridView(string ColumnName)
        {
            //"LDL AppID"
            //"Driving Class"
            //"National No"
            //"Full Name"
            //"Application Date"
            //"Passed Tests"
            //"Status"b
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvLocalApplications.DataSource;
            string filterExpression = string.Empty;

            if (ColumnName == "Status")
            {
                if (cbStatusType.SelectedIndex == 0)
                {
                    _RefrshDataGridView();
                    return;
                }

                filterExpression = $"Convert({ColumnName}, 'System.String') LIKE '{Convert.ToString(cbStatusType.SelectedItem.ToString())}%'";

                bs.Filter = filterExpression;

                return;
            }

             filterExpression = $"Convert({ColumnName}, 'System.String') LIKE '{Convert.ToString(txtInputFilter.Text)}%'";

            bs.Filter = filterExpression;

        }
        private void txtInputFilter_TextChanged(object sender, EventArgs e)
        {
            //"LDL AppID"
            //"Driving Class"
            //"National No"
            //"Full Name"
            //"Application Date"
            //"Passed Tests"
            _FillterDataGridView(cbFilterBy.SelectedItem.ToString());
        }

        private void cbStatusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FillterDataGridView("Status");
        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
