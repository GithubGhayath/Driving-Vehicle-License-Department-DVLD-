using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayar;
using System.IO;
using System.Threading;

namespace DVLV_Program
{
    public partial class frmPeopleForm : Form
    {
        // (X,Y) of Clecked Cell on data Gred view
        private int _RowIndexOfCleckedCell;
        private int _ColumnIndexOfCleckedCell;


        private void _LoadDataToDataGredView()
        {
            dgvPeopleList.DataSource = clsPeopleBusinessLayar.GetAllPeople();
            lblCountOfPeople.Text = dgvPeopleList.Rows.Count.ToString();
            
        }

        private void _RefreshPeopleList()
        {
            _LoadDataToDataGredView();
        }

        private void _FillDataToFiterComboBox()
        {
            foreach (DataGridViewColumn ColumnName in dgvPeopleList.Columns)
            {
                cbAttributeOfTable.Items.Add(ColumnName.Name);
            }
            cbAttributeOfTable.SelectedIndex = 0;
            cbAttributeOfTable.Items.RemoveAt(cbAttributeOfTable.Items.Count - 1);
            cbAttributeOfTable.Items.RemoveAt(cbAttributeOfTable.FindString("Address"));
        }

        private void _DeletePhotoFromFile(string ImagePath)
        {
            if(File.Exists(ImagePath))
            {
                File.Delete(ImagePath);
            }
        }

        //This method will be used on ctrlAboutPerson
        private void _AddNewPerson()
        {
            Form frmPersonControl = new frmPersonControl();
            frmPersonControl.ShowDialog();
            _RefreshPeopleList();
        }

        public frmPeopleForm()
        {
            InitializeComponent();
        }
        private void frmPeopleForm_Load(object sender, EventArgs e)
        { 
            _LoadDataToDataGredView();
            _FillDataToFiterComboBox();
            cbGender.SelectedIndex = 0;
        

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
            _AddNewPerson();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void _FilterDataGredVeiw(string textchange, string ColumnName)
        {
            BindingSource BS = new BindingSource();

            BS.DataSource = dgvPeopleList.DataSource;

            if (textchange != "All")
            {   
                string filterExpression = $"Convert({ColumnName}, 'System.String') LIKE '{Convert.ToString(textchange)}%'";
                BS.Filter = filterExpression;
            }
            else
                _RefreshPeopleList();

        }
        
        //Context Menue Methods
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);
            int PersonID = Convert.ToInt32(dgvPeopleList.Rows[_RowIndexOfCleckedCell].Cells[_ColumnIndexOfCleckedCell].Value);

            Form frmPersonCard = new frmShowPersonDetails(PersonID);

            frmPersonCard.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);

            _AddNewPerson();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);
            int PersonID = Convert.ToInt32(dgvPeopleList.Rows[_RowIndexOfCleckedCell].Cells[_ColumnIndexOfCleckedCell].Value);

            Form frmEditPerson = new frmPersonControl(PersonID);
            frmEditPerson.ShowDialog();
            
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);


            int PersonID = Convert.ToInt32(dgvPeopleList.Rows[_RowIndexOfCleckedCell].Cells[_ColumnIndexOfCleckedCell].Value);
            if (MessageBox.Show($"Are you sure you want to delete person [{PersonID}]", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //This line for Get Image Path befor delete person from database to delete person's image after delete them
                string ImagePathForDelete = clsPeopleBusinessLayar.Find(PersonID).ImagePath;
                if (clsPeopleBusinessLayar.DeletePerson(PersonID) == true)
                {
                    _DeletePhotoFromFile(ImagePathForDelete);
                    MessageBox.Show("Person Deleted Successfully", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _RefreshPeopleList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will Comming soon...", "Info", MessageBoxButtons.OK);

        }

        private void dgvPeopleList_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
              //Zero-index
             _RowIndexOfCleckedCell    = e.RowIndex;
            _ColumnIndexOfCleckedCell = 0;
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbAttributeOfTable.SelectedItem.ToString() == "PersonID" ||
                cbAttributeOfTable.SelectedItem.ToString() == "DateOfBirth" ||
                cbAttributeOfTable.SelectedItem.ToString() == "Phone")
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbAttributeOfTable.SelectedIndex == 2) 
            {
                return;
            }
            else
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; 
                }
            }
        }

        private void cbAttributeOfTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAttributeOfTable.SelectedItem.ToString()=="None")
            {
                cbGender.Visible = false;
                textBox1.Visible = false;
                lblEnter.Visible = false;
                _RefreshPeopleList();
            }
            else if(cbAttributeOfTable.SelectedItem.ToString()== "Gendor")
            {
                textBox1.Visible = false;   
                cbGender.Visible = true;
                lblEnter.Visible = true;
                lblEnter.Text = "Choose:";
            }
            else
            {

                lblEnter.Text = "Enter:";
                lblEnter.Visible = true;
                textBox1.Visible = true;
                cbGender.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (cbAttributeOfTable.SelectedItem.ToString())
            {
                case "PersonID":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "PersonID");
                        break;
                    }
                case "NationalNo":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "NationalNo");
                        break;
                    }
                case "FirstName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "FirstName");
                        break;
                    }
                case "SecondName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "SecondName");
                        break;
                    }
                case "ThirdName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "ThirdName");
                        break;
                    }
                case "LastName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "LastName");
                        break;
                    }
                case "DateOfBirth":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "DateOfBirth");
                        break;
                    }
                case "Phone":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "Phone");
                        break;
                    }
                case "Email":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "Email");
                        break;
                    }
                case "CountryName":
                    {
                        _FilterDataGredVeiw(textBox1.Text, "CountryName");
                        break;
                    }
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                _FilterDataGredVeiw(cbGender.SelectedItem.ToString(), "Gendor");
        }

      
    }
}
