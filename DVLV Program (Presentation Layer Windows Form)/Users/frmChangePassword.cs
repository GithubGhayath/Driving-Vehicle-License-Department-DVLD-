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
    public partial class frmChangePassword : Form
    {
        clsUserDataBusinessLayar User = new clsUserDataBusinessLayar();
        private int _UserID;
        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            User = clsUserDataBusinessLayar.Find(_UserID);
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();
            lblIsActive.Text = (User.IsActive == true) ? "Yes" : "No";
            ctrlShowPersonDetale1.PersonID=User.PersonID;
            ctrlShowPersonDetale1.LoadPersonInformation();

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
        private void _LoadDataToDataBase()
        {
            User.Password = txtNewPassword.Text;
            if(User.Save())
            {
                MessageBox.Show("Password Changed Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Something Wrong", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                MessageBox.Show("Fill The fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToDataBase();
            btnSave.Enabled = false;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text != User.Password) 
            {
                errorProvider1.SetError(txtCurrentPassword, "Uncurrect Password");
                e.Cancel = true;
                txtCurrentPassword.Focus();
                return;
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Write a new Password");
                e.Cancel = true;
                txtNewPassword.Focus();
                return;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text) 
            {
                errorProvider1.SetError(txtConfirmPassword, "Doesn't Match");
                e.Cancel = true;
                txtConfirmPassword.Focus();
                btnSave.Enabled = false;
                return;
            }
            else
                btnSave.Enabled = true;
        }
    }
}
