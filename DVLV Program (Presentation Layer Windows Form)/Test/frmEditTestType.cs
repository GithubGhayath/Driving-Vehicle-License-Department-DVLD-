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
    public partial class frmEditTestType : Form
    {
        private int _TestID;
        clsTestTypesBusinessLayar Test = new clsTestTypesBusinessLayar();
        public frmEditTestType()
        {
            InitializeComponent();
        }

        public frmEditTestType(int TestID)
        {
            InitializeComponent();
            _TestID = TestID;
        }

        private void _FillControlsWithDetail()
        {
            lblTestID.Text = _TestID.ToString();
            txtTitle.Text = Test.TestTitle;
            txtFees.Text = Test.TestFees.ToString();
            txtDescription.Text = Test.TestDescription;
        }

        private void _FillClsTest()
        {
            Test.TestID = _TestID;
            Test.TestFees = Convert.ToDecimal(txtFees.Text);
            Test.TestDescription = txtDescription.Text;
            Test.TestTitle=txtTitle.Text;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            Test = clsTestTypesBusinessLayar.Find(_TestID);
            _FillControlsWithDetail();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillClsTest();

            if (clsTestTypesBusinessLayar.UpdateTestInfo(Test.TestID, Test.TestTitle, Test.TestDescription, Test.TestFees))
                MessageBox.Show("Test Updated Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Something Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
