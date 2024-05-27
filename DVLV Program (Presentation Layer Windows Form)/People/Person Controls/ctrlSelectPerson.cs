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
    public partial class ctrlSelectPerson : UserControl
    {
        public ctrlSelectPerson()
        {
            InitializeComponent();
        }


        public event Action<int> OnPersonSelect;

        protected virtual void SelectPerson(int personID)
        {
            Action<int> handler = OnPersonSelect;
            if (handler != null)
            {
                handler(personID);
            }
        }

        clsPeopleBusinessLayar Person = new clsPeopleBusinessLayar();

        public int PersonID;

        private void _GetPersonByID(int PersonID)
        {
             Person = clsPeopleBusinessLayar.Find(PersonID);

            if(Person==null)
            {
                MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
            else
            {
                this.PersonID = Person.PersonID;
                ctrlShowPersonDetale1.PersonID = Person.PersonID;
                ctrlShowPersonDetale1.LoadPersonInformation();
            }


        }
        private void _GetPersonByNationalNo(string NationalNo)
        {

             Person = clsPeopleBusinessLayar.Find(NationalNo);
            if (Person == null)
            {
                MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }
            else
            {
                this.PersonID = Person.PersonID;
                ctrlShowPersonDetale1.PersonID = Person.PersonID;
                ctrlShowPersonDetale1.LoadPersonInformation();
                
            }

        }

        private void _DefaultValues()
        {
            cbFilterBy.SelectedItem = "None";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString()=="Person ID")
            {
                if(char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;   
                }
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "Person ID")
            {
                _GetPersonByID(Convert.ToInt32(textBox1.Text));
            }
            else
            {
                _GetPersonByNationalNo(textBox1.Text); 
            }

            if (OnPersonSelect != null && Person != null) 
                SelectPerson(Person.PersonID);
        }

        private void _ControlsForUpdateMood()
        {
            cbFilterBy.Enabled = false;
            textBox1.Enabled= false;
            button1.Enabled= false;
            button2.Enabled = false;
        }

        public void _ForUpdate(int personid)
        {
            ctrlShowPersonDetale1.PersonID=personid;
            ctrlShowPersonDetale1.LoadPersonInformation();
            textBox1.Text=personid.ToString();
            _ControlsForUpdateMood();
            cbFilterBy.SelectedIndex = 1;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            frmPersonControl frmAddNewPerson = new frmPersonControl();

            frmAddNewPerson.GetPersonID += OnfrmAddNewPerson_DataBack;

            frmAddNewPerson.ShowDialog();
        }
        private void OnfrmAddNewPerson_DataBack(object sender, int personid)
        {
            PersonID = 0;
            PersonID = personid;
            _GetPersonByID(PersonID);

            if (OnPersonSelect != null)
                SelectPerson(PersonID);
        }

        private void ctrlSelectPerson_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }
    }
}
