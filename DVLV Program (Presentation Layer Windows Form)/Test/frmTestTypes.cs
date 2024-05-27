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
    public partial class frmTestTypes : Form
    {
        private int _RowIndex;
        private int _ColumnIndex;

        private void _LoadTableFromDataBase()
        {
            DataTable TestTypes = clsTestTypesBusinessLayar.GetAllTestTypes();

            dgvTestTypes.DataSource = TestTypes;
            dgvTestTypes.Columns["TestTypeID"].Name="ID";
            dgvTestTypes.Columns["ID"].Width = 60;
            dgvTestTypes.Columns["TestTypeTitle"].Name="Title";
            dgvTestTypes.Columns["Title"].Width = 80;
            dgvTestTypes.Columns["TestTypeDescription"].Name= "Description";
            dgvTestTypes.Columns["Description"].Width = 190;
            dgvTestTypes.Columns["TestTypeFees"].Name="Fees";
            dgvTestTypes.Columns["Fees"].Width = 80;
            dgvTestTypes.DefaultCellStyle.Font = new Font("Franklin Gothic", 8);
        }
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {


            _LoadTableFromDataBase();
            lblCount.Text = dgvTestTypes.RowCount.ToString();


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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestID = Convert.ToInt32(dgvTestTypes.Rows[_RowIndex].Cells[_ColumnIndex].Value);

            Form frmEdit = new frmEditTestType(TestID);
            frmEdit.ShowDialog();
        }

        private void dgvTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex=e.RowIndex;
            _ColumnIndex = 0;
        }
    }
}
