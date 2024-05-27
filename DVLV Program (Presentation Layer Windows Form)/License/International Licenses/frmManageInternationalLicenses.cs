using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmManageInternationalLicenses : Form
    {
        private int _RowIndex;
        private int _ColumnIndex;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private void _LoadDataFromDataBaseToDataGridView()
        {
            dgvInternationalLicenseApplications.DataSource = clsInternationalLicensesBusinessLayar.GetAllForInternationalLicenseApplication();
        }

        private void _RefreshTable()
        {
            _LoadDataFromDataBaseToDataGridView();
            lblCountRows.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void _FillCompFilterBy()
        {
            foreach(DataGridViewColumn ColumnName in dgvInternationalLicenseApplications.Columns)
            {
                cbFilterBy.Items.Add(Convert.ToString(ColumnName.Name));
            }
        }

        private void _DefaultSittings()
        {
            _RefreshTable();
            _FillCompFilterBy();
            cbFilterBy.SelectedItem = "None";
            cbIsActive.SelectedItem = "None";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "None") 
            {
                lblEnter.Visible = false;
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
            }
            else if (cbFilterBy.SelectedItem.ToString() == "IsActive")
            {
                lblEnter.Text = "Choose:";
                lblEnter.Visible = true;
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
            }
            else
            {
                lblEnter.Visible = true;
                lblEnter.Text = "Enter:";
                txtFilterBy.Visible = true;
                cbIsActive.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frmGetInternationaLicense = new frmEarnInternationalLIcense();
            frmGetInternationaLicense.ShowDialog();
            _RefreshTable();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _DefaultSittings();

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

        private void _FilterDataGridView(string ColumnName)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvInternationalLicenseApplications.DataSource;

            string filterExpression = $"Convert({ColumnName}, 'System.String') LIKE '{Convert.ToString(txtFilterBy.Text)}%'";

            bs.Filter = filterExpression;
        }
        private void _FilterDataGridViewForcbIsActive(string Yes_No)
        {

            string Result = (Yes_No == "Yes") ? "true" : "false";

            BindingSource bs = new BindingSource();
            bs.DataSource = dgvInternationalLicenseApplications.DataSource;

            string filterExpression = $"Convert([{dgvInternationalLicenseApplications.Columns["IsActive"].Name}], 'System.String') LIKE '{Result}'";

            bs.Filter = filterExpression;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            /*
           * InternationalLicenseID
           * ApplicationID
           * DriverID
           * LocalLicenseID
           * IssueDate
           * ExpirationDate
           * IsActive
           */
            string SelectedColumn = string.Empty;
            if (cbFilterBy.SelectedItem.ToString() == "InternationalLicenseID")
            {
                SelectedColumn = "InternationalLicenseID";
            }
            else if (cbFilterBy.SelectedItem.ToString() == "ApplicationID")
            {
                SelectedColumn = "ApplicationID";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "DriverID")
            {
                SelectedColumn = "DriverID";
            }

            else if (cbFilterBy.SelectedItem.ToString() == "LocalLicenseID")
            {
                SelectedColumn = "LocalLicenseID";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "IssueDate")
            {
                SelectedColumn = "IssueDate";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "ExpirationDate")
            {
                SelectedColumn = "ExpirationDate";

            }     

            _FilterDataGridView(SelectedColumn);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActive.SelectedItem.ToString()=="None")
            {
                _RefreshTable();
            }
            else if (cbIsActive.SelectedItem.ToString()=="Yes")
            {

                _FilterDataGridViewForcbIsActive("Yes");
            }
            else
            {
                _FilterDataGridViewForcbIsActive("No");

            }
        }

        private void dgvInternationalLicenseApplications_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = 0;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicenseApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowPersonDetails = new frmShowPersonDetails(clsDriversBusinessLayar.Find(clsInternationalLicensesBusinessLayar.FindByInternationalLicenseID(InternationalLicenseID).DriverID).PersonID);
            frmShowPersonDetails.ShowDialog();
            _RefreshTable();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicenseApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowInternationalLicense = new frmShowInternationalDrivingLicenseInformations(InternationalLicenseID);
            frmShowInternationalLicense.ShowDialog();
            _RefreshTable();
        }

        private void showPersonLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicenseApplications.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowLicenseHistory = new frmShowAllLicensesHistory(clsDriversBusinessLayar.Find(clsInternationalLicensesBusinessLayar.FindByInternationalLicenseID(InternationalLicenseID).DriverID).PersonID);
            frmShowLicenseHistory.ShowDialog();
            _RefreshTable();
        }
    }
}
