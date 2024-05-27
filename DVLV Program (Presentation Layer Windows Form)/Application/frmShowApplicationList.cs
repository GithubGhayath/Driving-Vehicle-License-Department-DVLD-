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
    public partial class frmShowApplicationList : Form
    {
        private int _RowIndex;
        private int _Columnndex;


        private void _LoadApplicationTypeFromDataBaseToDataGredView()
        {

            dgvApplication.DataSource = clsApplicationTypeBusinessLayar.GetAllApplicationType();
            dgvApplication.Columns["ApplicationTypeID"].Width = 70;
            dgvApplication.Columns["ApplicationTypeID"].HeaderText = "App ID";
            dgvApplication.Columns["ApplicationFees"].Width = 70;
            dgvApplication.Columns["ApplicationFees"].HeaderText = "Fees";
            dgvApplication.Columns["ApplicationTypeTitle"].Width = 250;
            dgvApplication.Columns["ApplicationTypeTitle"].HeaderText = "Title";
       
            lblCount.Text = dgvApplication.RowCount.ToString();
        }

        public frmShowApplicationList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowApplicationList_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeFromDataBaseToDataGredView();

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

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = Convert.ToInt32(dgvApplication.Rows[_RowIndex].Cells[_Columnndex].Value);

            Form frmShowEditForm = new frmEditApplicationType(ApplicationID); 
            frmShowEditForm.ShowDialog();
            _LoadApplicationTypeFromDataBaseToDataGredView();
        }

        private void dgvApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _Columnndex = 0;
        }
    }
}
