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
    public partial class frmDriversListScreen : Form
    {
        public frmDriversListScreen()
        {
            InitializeComponent();
        }


        private void _LoadDriversDataFromDataBase()
        {
            dgvDriversInformations.DataSource = clsDriversBusinessLayar.GetAllDrivers();
            dgvDriversInformations.Columns[0].Width = 60;
            dgvDriversInformations.Columns[1].Width = 60;
            dgvDriversInformations.Columns[2].Width = 70;
            dgvDriversInformations.Columns[3].Width = 250;
            dgvDriversInformations.Columns[4].Width = 150;
            dgvDriversInformations.Columns[5].Width = 70;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void _FillFilterByCompoBox()
        {
            foreach(DataGridViewColumn columnName in dgvDriversInformations.Columns)
            {
                cbFilterBy.Items.Add(columnName.Name.ToString());
            }
        }
        private void _DefaultScreenInformations()
        {
            _FillFilterByCompoBox();
            lblRowCount.Text = dgvDriversInformations.Rows.Count.ToString();
            cbFilterBy.SelectedItem = "None";
            txtFilterBy.Visible = false;
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

        private void frmDriversListScreen_Load(object sender, EventArgs e)
        {
            _LoadDriversDataFromDataBase();
            _DefaultScreenInformations();


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

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            /*
						 --DriverID
						 --PersonID
						 --NationalNo
						 --Full Name
						 --Date
						 --Active Licenses */





            BindingSource bs = new BindingSource(dgvDriversInformations.DataSource, null);
            string ColumnName = string.Empty;

            if(cbFilterBy.SelectedItem.ToString()== "DriverID")
            {
                ColumnName = "DriverID";
            }
            else if (cbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                ColumnName = "PersonID";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "NationalNo")
            {
                ColumnName = "NationalNo";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "FullName")
            {
                ColumnName = "FullName";

            }
            else if (cbFilterBy.SelectedItem.ToString() == "Date")
            {
                ColumnName = "Date";

            }
            else
            {
                ColumnName = "ActiveLicenses";

            }

                bs.Filter = $"Convert({ColumnName},'System.String') LIKE '{Convert.ToString(txtFilterBy.Text)}%'"; // Combine both conditions


            lblRowCount.Text = dgvDriversInformations.Rows.Count.ToString();
            dgvDriversInformations.DataSource = bs;
        }
    }
}
