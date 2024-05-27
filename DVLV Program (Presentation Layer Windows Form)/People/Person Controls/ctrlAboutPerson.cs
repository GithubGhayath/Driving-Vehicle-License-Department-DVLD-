using DVLV_Program.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayar;
using System.Web;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text.RegularExpressions;
using DVLV_Program.GlobleClasses;


namespace DVLV_Program
{
    public partial class ctrlAboutPerson : UserControl
    {
       
        
        //Path of Choiced image 
        private string _PathOfImage = string.Empty;

        //Image Path (Old)
        string _ImageForDelete = string.Empty;

        //Person id for Edit Screen

        public int _PersonID;

        //_enMode = AddNew
        clsPeopleBusinessLayar Person = new clsPeopleBusinessLayar();






        //Constructor Form
        public ctrlAboutPerson(int PersonID)
        {
            InitializeComponent();

            this._PersonID = PersonID;
        }
        public ctrlAboutPerson()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------------------------------


        //Default information when load form
        private void _FillComboWithCountries()
        {
            DataTable Countries = clsCountriesBusinessLayar.GetAllCountries();
            foreach (DataRow Row in Countries.Rows)
                cbCountry.Items.Add(Row["CountryName"]);

            cbCountry.SelectedIndex = cbCountry.FindString("Syria");
        }
        private void _SetDateOfDateTimeBicker()
        {
            dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
        }
        private void _DefaultPicture()
        {
            if (pbPersonalPhoto.Image == null)
                lblRemove.Visible = false;
            else
                lblRemove.Visible = true;
        }
        private void _DefaultInformations()
        {
            _FillComboWithCountries();
            _SetDateOfDateTimeBicker();
            _DefaultPicture();
        }

        //------------------------------------------------------------------------------------------------------------------
     


        //Validation Controls
        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox BoxToCheck = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(BoxToCheck.Text))
            {
                e.Cancel = true;
                BoxToCheck.Focus();
                errorProvider1.SetError(BoxToCheck, "This Field Is Required");
            }
            else if (_IsNationalNoExists(BoxToCheck.Text))
            {
                e.Cancel = true;
                BoxToCheck.Focus();
                errorProvider1.SetError(BoxToCheck, "Number Not Unique");
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void cbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cbCountry.SelectedIndex == 0)
            {
                e.Cancel = true;
                cbCountry.Focus();
                errorProvider1.SetError(cbCountry, "Choose your Country");
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void RemovePicture()
        {
            pbPersonalPhoto.Image = null;
            lblRemove.Visible = false;
            _PathOfImage = null;
            if (pbPersonalPhoto.Image == null)
            {
                if (rbMaleChoice.Checked)
                    pbPersonalPhoto.Image = Resources.Male1;

                else
                    pbPersonalPhoto.Image = Resources.Female1;
            }
        }
        private void _SetDefualtPersonPhoto(object sender, EventArgs e)
        {
            if (pbPersonalPhoto.Image == null)
            {
                if (rbMaleChoice.Checked) 
                    pbPersonalPhoto.Image = Resources.Male1;

                else
                    pbPersonalPhoto.Image = Resources.Female1;
            }
        }
        private string _MaleOrFemale()
        {

            if (rbMaleChoice.Checked)
                return "Male";
            else
                return "Female";
        }
        private bool _IsNationalNoExists(string NationalNumber)
        {
            DataTable PersonsDetals = clsPeopleBusinessLayar.GetAllPeople();

            foreach (DataRow Row in PersonsDetals.Rows)
            {
                if ((string)Row["NationalNo"] == (string)NationalNumber)
                    return true;
            }
            return false;
        }
        
        private void _SelectRadioBottomGender(string Gender)
        {
            if (Gender.Trim() == "Male")
                rbMaleChoice.Checked = true;
            else
                rbFemaleChoice.Checked = true;
        }

        private void TextBox_KeyPressOnlyText(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))//If return true will not type a digits
                e.Handled = true;
        }
        private void TextBox_KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = false;
            }
            else
            {

                string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                if (!Regex.IsMatch(txtEmail.Text, pattern))
                {
                    errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
                    txtEmail.Focus();
                    e.Cancel = true;
                }
            }

        }
        private void _LoadControlDataToObject(clsPeopleBusinessLayar Person)
        {
            //Set Image On New File
           
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.LastName = txtlastName.Text;
            Person.Phone = txtPhone.Text;
            Person.NationalNo = txtNationalNo.Text;
            Person.Gendor = _MaleOrFemale();
            Person.DateOfBirth = dtpBirthDate.Value;
            Person.Address = txtAddress.Text;

            if (string.IsNullOrEmpty(txtThirdName.Text))
                Person.ThirdName = null;
            else
            Person.ThirdName = txtThirdName.Text;

            //GetItemText can return name of item in combo
            Person.NationalityCountryID = clsCountriesBusinessLayar.Find((string)cbCountry.SelectedItem).CountryID;

            //Send null to data access layer for handel it and store on Email field value (null)
            if (string.IsNullOrEmpty(txtEmail.Text))
                Person.Email = null;
            else
                Person.Email = txtEmail.Text;

            //Image path = null
            if (string.IsNullOrEmpty(_PathOfImage))
            {
                if (clsUtil.IsImageExists(Person.ImagePath))
                {
                    clsUtil.DeleteImage(Person.ImagePath);
                }

                Person.ImagePath = null;
            }
            //Image path !=null
            else
            {
                //For if the image changes
                if (pbPersonalPhoto.ImageLocation != Person.ImagePath) 
                {
                    if (!string.IsNullOrEmpty(Person.ImagePath))
                        clsUtil.DeleteImage(Person.ImagePath);
                }
                else
                {
                    return;
                }


                //For add image
                if (clsUtil.CopyImageToProjectImagesFolder(ref _PathOfImage))
                    Person.ImagePath = _PathOfImage;
                else
                    MessageBox.Show("Error while copy image", "Error");
            }
            
           

          
        }


        //--------------------------------------------------------------------------------------------------------------

        private void _LoadDataFromControlToDataBase()
        {
          

            //It is work
            _LoadControlDataToObject(Person);


           

            if (Person.Save())
                MessageBox.Show("The Person has been added ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Adding Person Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            lblPersonID.Text = Person.PersonID.ToString();
            _PersonID = Person.PersonID;

        }

        public void LoadDateFromDataBaseToControl(int personID)
        {
            lblTitle.Text = "Update Person";


            //_enMode = UpdateMode
            Person = clsPeopleBusinessLayar.Find(personID);

            clsCountriesBusinessLayar PersonCountry = clsCountriesBusinessLayar.Find(Person.NationalityCountryID);


            lblPersonID.Text=Person.PersonID.ToString();
            txtFirstName.Text = Person.FirstName.ToString();
            txtSecondName.Text = Person.SecondName.ToString();

            if (string.IsNullOrEmpty(Person.ThirdName))
                txtThirdName.Text = string.Empty;
            else
                txtThirdName.Text = Person.ThirdName;

            txtlastName.Text = Person.LastName.ToString();
            txtNationalNo.Text = Person.NationalNo.ToString();

            _SelectRadioBottomGender(Person.Gendor);

            if (string.IsNullOrEmpty(Person.Email))
                txtEmail.Text = string.Empty;
            else
                txtEmail.Text = Person.Email;

            txtAddress.Text=Person.Address.ToString();
            dtpBirthDate.Value = Person.DateOfBirth;
            txtPhone.Text = Person.Phone.ToString();

            //Load Countries to ComboBox
            _FillComboWithCountries();
            cbCountry.SelectedItem = cbCountry.FindString(PersonCountry.CountryName);



            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                _PathOfImage = null;
                if (Person.Gendor.Trim() == "Male")
                    pbPersonalPhoto.Image = Resources.Male1;
                else
                    pbPersonalPhoto.Image = Resources.Female1;
            }
            else
            {
                lblRemove.Visible = true;
                _PathOfImage = Person.ImagePath;
                pbPersonalPhoto.ImageLocation = Person.ImagePath;
            }

   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadDataFromControlToDataBase();
            btnSave.Enabled = false;
        }

        private void ctrlAboutPerson_Load(object sender, EventArgs e)
        {
            //#132365

            lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#132365");
            if (!this.DesignMode)
                _DefaultInformations();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //To get only any extention of image
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp|All Files|*.*";
            openFileDialog1.Title = "Select an Image File";

            linkLabel1.VisitedLinkColor = Color.AliceBlue;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _PathOfImage = openFileDialog1.FileName;
            }

            if (!string.IsNullOrEmpty(_PathOfImage))
                pbPersonalPhoto.ImageLocation = _PathOfImage;

            if (pbPersonalPhoto.Image != null)
                lblRemove.Visible = true;
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemovePicture();
           
        }

        private void rbMaleChoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaleChoice.Checked)
                pbPersonalPhoto.Image = Resources.Male1;
            else
                pbPersonalPhoto.Image = Resources.Female1;

        }
    }   
}
