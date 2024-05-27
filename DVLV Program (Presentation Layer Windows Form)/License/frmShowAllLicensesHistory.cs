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
    public partial class frmShowAllLicensesHistory : Form
    {
        public frmShowAllLicensesHistory()
        {
            InitializeComponent();
        }

        private int _PersonID;

        public frmShowAllLicensesHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadPersonInformation()
        {
            ctrlSelectPerson1._ForUpdate(_PersonID);
        }

        private void _LoadLocalDrivingLicensesByPersonID()
        {
            dgvLocalLicenses.DataSource = clsLicensesBusinessLayar.GetAllLocalLicenses(_PersonID);
        }

        private void _LoadInternationalDrivingLicensesByPersonID()
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicensesBusinessLayar.GetInternationalLicenseByPersonID(_PersonID);
        }

        private void frmShowAllLicensesHistory_Load(object sender, EventArgs e)
        {

            _LoadPersonInformation();
            _LoadLocalDrivingLicensesByPersonID();
            _LoadInternationalDrivingLicensesByPersonID();
            _CountLocalRows();

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

        private void _CountLocalRows()
        {
            lblCountRows.Text = dgvLocalLicenses.Rows.Count.ToString();
        }
        private void _CountInternationalRows()
        {
            lblCountRows.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                _CountLocalRows();
            else
                _CountInternationalRows();
        }



        private int _RowIndex;
        private int _ColumnIndex;
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenesID = Convert.ToInt32(dgvLocalLicenses.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowLicenseInfo = new frmDriverLicenseInformation(0, LicenesID);
            frmShowLicenseInfo.ShowDialog();
        }

        private void dgvLocalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex= e.RowIndex;
            _ColumnIndex = 0;
        }

        private void dgvInternationalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = 0;
        }
    }
}
