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
    public partial class frmAddNewUser : Form
    {
        enum enMode { AddNew,Update}
        private enMode _Mode;
        private int _PersonID = -1;
        private int _UserID;

        private bool IsUpdateMood = false;
        clsUserDataBusinessLayar User = new clsUserDataBusinessLayar();

        public frmAddNewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New User";

        }

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = enMode.Update;
            lblTitle.Text = "Update User";

        }


        private void _DefaultData()
        {
            chkIsActive.Checked = true;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                MessageBox.Show("Please Select a Person!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
                return;
            }
            _DefaultData();

            if (!clsUserDataBusinessLayar.IsExistsByUserPersonID(_PersonID))
            {
                tabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
                btnNextPage.Enabled = false;
            }
            else if(_Mode==enMode.Update)
            {

                tabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
                btnNextPage.Enabled = false;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Selected Person alredy has a user, select another one", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required");
                txtUserName.Focus();
            }
            else
                e.Cancel = false;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field is required");
                txtUserName.Focus();
            }
            else
                e.Cancel = false;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text)) 
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required");

            }
            else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Must match the previous field");

            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Here Method for load data to database
            _LoadDataToDataBase();
            lblUserID.Text = User.UserID.ToString();

        }

        private void _LoatDataToObject()
        {
            User.UserName=txtUserName.Text;
            User.Password=txtPassword.Text;
            User.IsActive = chkIsActive.Checked;
            User.PersonID = _PersonID;
        }

        private void _LoadDataToDataBase()
        {
            _LoatDataToObject();
            if (User.Save())
            {
                MessageBox.Show("User Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Wrong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {

            lblTitle.ForeColor = ColorTranslator.FromHtml("#FFDFD991");
            
            if (_Mode==enMode.Update)
            {
                User = clsUserDataBusinessLayar.Find(_UserID);

                btnSave.Enabled = true;
                ctrlSelectPerson1._ForUpdate(User.PersonID);

                txtUserName.Text = User.UserName;
                txtPassword.Text = User.Password;
                txtConfirmPassword.Text = User.Password;
                chkIsActive.Checked = User.IsActive;
                _PersonID= User.PersonID;
            }
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                btnNextPage.PerformClick();
        }

        private void ctrlSelectPerson1_OnPersonSelect(int obj)
        {
            _PersonID = obj;
        }
    }
}
