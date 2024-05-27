using DVLDBusinessLayar;
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

namespace DVLV_Program
{
    public partial class ctrlShowPersonDetale : UserControl
    {
        public int PersonID { get; set; }

        clsPeopleBusinessLayar Person = new clsPeopleBusinessLayar();
        public ctrlShowPersonDetale()
        {
            InitializeComponent();
        }

        public void LoadPersonInformation()
        {
            Person = clsPeopleBusinessLayar.Find(PersonID);
            clsCountriesBusinessLayar Country = clsCountriesBusinessLayar.Find(Person.NationalityCountryID);

            lblName.Text = Person.GetFillName();
            lblPersonID.Text = Person.PersonID.ToString();
            lblGender.Text = Person.Gendor;
            lblAddress.Text = Person.Address;   
            lblNationalNO.Text = Person.NationalNo;
            if (string.IsNullOrEmpty(Person.Email))
                lblEmail.Text = "unavailable";
            else
            lblEmail.Text = Person.Email;

            string DateOfBirth = Person.DateOfBirth.Day.ToString() + "-" + Person.DateOfBirth.Month.ToString() + "-" + Person.DateOfBirth.Year.ToString();
            lblDateOfBirth.Text = DateOfBirth;
            lblPhone.Text = Person.Phone;
            lblCountry.Text = Country.CountryName;


            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                if (Person.Gendor.Trim() == "Male")
                    pbPersonImage.Image = Resources.Male1;
                else
                    pbPersonImage.Image = Resources.Female1;
            }
            else
                pbPersonImage.ImageLocation = Person.ImagePath;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmEditPerson = new frmPersonControl(PersonID);
            frmEditPerson.ShowDialog();

            //Refresh data
            LoadPersonInformation();
        }

        private void ctrlShowPersonDetale_Load(object sender, EventArgs e)
        {

        }
    }
}
