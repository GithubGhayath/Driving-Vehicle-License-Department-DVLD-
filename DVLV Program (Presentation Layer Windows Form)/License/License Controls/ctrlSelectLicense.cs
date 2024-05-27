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
    public partial class ctrlSelectLicense : UserControl
    {
        clsLicensesBusinessLayar CurrentLicense = new clsLicensesBusinessLayar();




        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int licenseId)
        {
            Action<int> handler = OnLicenseSelected;

            if (handler != null)
                handler(licenseId);
        }

        public ctrlSelectLicense()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void ClickButton()
        {
            //btnSearch.PerformClick();
            btnSearch_Click(null, EventArgs.Empty);
        }

        public void FillTextBoxWithLicenseIDForSearch(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentLicense = clsLicensesBusinessLayar.Find(Convert.ToInt32(txtLicenseID.Text));

            if(CurrentLicense == null)
            {
                MessageBox.Show("License With ID : " + txtLicenseID.Text + " Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ctrlLicenseInformations1.LicenseID = Convert.ToInt32(txtLicenseID.Text);
                ctrlLicenseInformations1.ShowLicenseInformation();
            }

            if (OnLicenseSelected != null )
                OnLicenseSelected(Convert.ToInt32(txtLicenseID.Text));
        }

    }
}
