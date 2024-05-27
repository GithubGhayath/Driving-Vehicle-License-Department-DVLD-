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
using DVLDBusinessLayar;

namespace DVLV_Program
{
    public partial class frmManageUsers : Form
    {
        private int _RowIndex;
        private int _ColumnIndex;

        private void _FillDataGredWithUsersInformation()
        {

            
            dgvUsersInfo.DataSource = clsUserDataBusinessLayar.GetAllUses();
            dgvUsersInfo.Columns["FullName"].Width = 250;
            dgvUsersInfo.Columns["UserID"].Width = 70;
            dgvUsersInfo.Columns["PersonID"].Width = 90;
            dgvUsersInfo.Columns["IsActive"].Width = 80;

            lblCount.Text = dgvUsersInfo.Rows.Count.ToString();
        }

        private void _LoadCompoBoxFilterBy()
        {
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("UserID");
            cbFilterBy.Items.Add("PersonID");
            cbFilterBy.Items.Add("UserName");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Is Active");
            cbFilterBy.SelectedItem = "None";
        }


        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _FillDataGredWithUsersInformation();
            _LoadCompoBoxFilterBy();
            cbIsActive.SelectedIndex = 0;


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frmAddUser = new frmAddNewUser();
            frmAddUser.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersInfo.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmShowUserDetails = new frmUserDetails(UserID);
            frmShowUserDetails.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersInfo.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmUpdateUser = new frmAddNewUser(UserID);
            frmUpdateUser.ShowDialog();
            _FillDataGredWithUsersInformation();

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int UserID = Convert.ToInt32(dgvUsersInfo.Rows[_RowIndex].Cells[_ColumnIndex].Value);

                if (clsUserDataBusinessLayar.Delete(UserID))
                    MessageBox.Show("User Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Something Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersInfo.Rows[_RowIndex].Cells[_ColumnIndex].Value);
            Form frmChangePassword = new frmChangePassword(UserID);
            frmChangePassword.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it Will Avilable Soon..");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it Will Avilable Soon..");

        }

        private void dgvUsersInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _RowIndex = e.RowIndex;
            _ColumnIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "UserID" || cbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbFilterBy.SelectedItem.ToString() == "Full Name")
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbFilterBy.SelectedItem == "None")
            {
                textBox1.Visible = false;
                cbIsActive.Visible = false;
                lblEnter.Visible = false;
            }
            else if ((string)cbFilterBy.SelectedItem == "Is Active")
            {
                textBox1.Visible = false;
                cbIsActive.Visible = true;
                lblEnter.Text = "Choose:";
                lblEnter.Visible = true;
            }
            else
            {
                lblEnter.Text = "Enter:";
                lblEnter.Visible = true;
                textBox1.Visible = true;
                cbIsActive.Visible = false;
                textBox1.Focus();
            }
        }

        private void _FilterDataGredVeiw(string textchange, string ColumnName)
        {
            string filterExpression = string.Empty;

            BindingSource BS = new BindingSource();

            BS.DataSource = dgvUsersInfo.DataSource;

            if(ColumnName== "IsActive")
            {
                filterExpression = string.Format("{0} = {1}", ColumnName, textchange);
                BS.Filter = filterExpression;

                lblCount.Text = dgvUsersInfo.Rows.Count.ToString();
                return;
            }

             filterExpression = $"Convert({ColumnName}, 'System.String') LIKE '{Convert.ToString(textchange)}%'";
            BS.Filter = filterExpression;

            lblCount.Text = dgvUsersInfo.Rows.Count.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "PersonID":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "PersonID");
                        break;
                    }
                case "UserName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "UserName");
                        break;
                    }
                case "Full Name":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "FullName");
                        break;
                    }
                case "UserID":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "UserID");
                        break;
                    }
                    
            }
        }


        private void _FilterIsActive()
        {

            bool Answer = ((string)cbIsActive.SelectedItem == "Yes") ? true : false;

            _FilterDataGredVeiw(Answer.ToString(), "IsActive");
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
            _FillDataGredWithUsersInformation();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActive.SelectedIndex == 0)
            {
                _FillDataGredWithUsersInformation();
                return;
            }
            _FilterIsActive();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
