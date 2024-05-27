using DVLDBusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLV_Program
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationID;
        clsApplicationTypeBusinessLayar Application =new  clsApplicationTypeBusinessLayar();
        public frmEditApplicationType()
        {
            InitializeComponent();
        }
        public frmEditApplicationType(int ApplicationID)
        {
            //int ApplicationID=Convert.ToInt32()
            InitializeComponent();
            _ApplicationID=ApplicationID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            Application = clsApplicationTypeBusinessLayar.Find(_ApplicationID);
            txtApplicationTitle.Text = Application.Title;
            txtApplicationFee.Text = Application.Fees.ToString();
            lblApplicationID.Text = _ApplicationID.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (clsApplicationTypeBusinessLayar.UpdateAnApplication(Application.AppId, txtApplicationTitle.Text, Convert.ToDecimal(txtApplicationFee.Text)))
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is Not Saved Successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }
    }
}
