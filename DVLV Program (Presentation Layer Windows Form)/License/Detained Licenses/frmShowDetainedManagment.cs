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
    public partial class frmShowDetainedManagment : Form
    {
        public frmShowDetainedManagment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadDataToDataGridView()
        {
            dgvDetainInformation.DataSource = clsDetainedAndReleasedLiceneseBusinessLayer.GetAllDetained();
            lblRowCount.Text = dgvDetainInformation.Rows.Count.ToString();
            dgvDetainInformation.Columns[0].Width = 60;
            dgvDetainInformation.Columns[1].Width = 60;
            dgvDetainInformation.Columns[2].Width = 60;
            dgvDetainInformation.Columns[3].Width = 60;
            dgvDetainInformation.Columns[4].Width = 60;
            dgvDetainInformation.Columns[5].Width = 60;
            dgvDetainInformation.Columns[6].Width = 260;
        }

        private void _RefreshData()
        {
            _LoadDataToDataGridView();
        }

        private void _FillCompoFilterBy()
        {
            foreach (DataGridViewColumn column in dgvDetainInformation.Columns)
            {
                cbFilterBy.Items.Add(column.Name.ToString());
            }
            cbFilterBy.SelectedItem = "None";
        }

        private void frmShowDetainedManagment_Load(object sender, EventArgs e)
        {
            _LoadDataToDataGridView();
            _FillCompoFilterBy();

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

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "None")
            {
                lblEnter.Visible = false;
                txtFilterBy.Visible = false;
            }
            else
            { 
                lblEnter.Visible = true;
                txtFilterBy.Visible = true;
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            Form frmDetainLicenes = new frmDetainLicense();
            frmDetainLicenes.ShowDialog();
            _RefreshData();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            Form frmReleaseLicense = new frmReleasedDetainedLicenses();
            frmReleaseLicense.ShowDialog();
            _RefreshData();
        }

        private int _RowIndex;
        private int _ColumnIndex;
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ColumnIndex = 1; //Field Contain License ID

            int LicenseID = Convert.ToInt32(dgvDetainInformation.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowPersonDetails = new frmShowPersonDetails(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(LicenseID).DriverID).PersonID);
            frmShowPersonDetails.ShowDialog();
        }

        private void dgvDetainInformation_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = e.ColumnIndex;
        }

        private void showLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ColumnIndex = 1; //Field Contain License ID

            int LicenseID = Convert.ToInt32(dgvDetainInformation.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowLicenseDetails = new frmDriverLicenseInformation(0, LicenseID);
            frmShowLicenseDetails.ShowDialog();
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ColumnIndex = 1; //Field Contain License ID

            int LicenseID = Convert.ToInt32(dgvDetainInformation.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmshowLicensesHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsLicensesBusinessLayar.Find(LicenseID).DriverID).PersonID);
            frmshowLicensesHistory.ShowDialog();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ColumnIndex = 1; //Field Contain License ID

            int LicenseID = Convert.ToInt32(dgvDetainInformation.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            frmReleasedDetainedLicenses frmShowReleaseLicenseScreen = new frmReleasedDetainedLicenses(LicenseID);
            frmShowReleaseLicenseScreen.MakeSelectLicenseControlDisable();
            frmShowReleaseLicenseScreen.ShowDialog();
            _RefreshData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // The third field has the Release or not : 2
            _ColumnIndex = 2;
            bool IsReleased = Convert.ToBoolean(dgvDetainInformation.Rows[_RowIndex].Cells[_ColumnIndex].Value);

            if(IsReleased==false)
            {
                cToolStripMenuItem.Enabled = true;
            }
            else
            {
                cToolStripMenuItem.Enabled = false;
            }
        }
    }
}
