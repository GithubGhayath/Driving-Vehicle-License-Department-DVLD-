using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayar;



namespace DVLV_Program
{
    public partial class frmLoginScreen : Form
    {
        clsUserDataBusinessLayar User = new clsUserDataBusinessLayar();
        clsRemmembersBussinessLayar Record = new clsRemmembersBussinessLayar();


        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private string _GetMacAddressOfComputer()
        {

            var macAddr =
          (from nic in NetworkInterface.GetAllNetworkInterfaces()
           where nic.OperationalStatus == OperationalStatus.Up
           select nic.GetPhysicalAddress().ToString())
          .FirstOrDefault();

            return (string)macAddr;
        }

        private clsRemmembersBussinessLayar _CheckMacAddressIsExists()
        {

            Record = clsRemmembersBussinessLayar.Find(_GetMacAddressOfComputer());

            if (Record == null)
                return null;   //Not Found here the mission is done .............
            else
                return Record;

        }

        private bool _CheckRemmmberIsChecked(clsRemmembersBussinessLayar record)
        {
            return (record.RemmemberMe == true) ? true : false;
        }



        private void _InsertNewMac()
        {
            Record = new clsRemmembersBussinessLayar();

            if (chkRememberMe.Checked)
                Record.RemmemberMe = true;
            else
                Record.RemmemberMe = false;

            Record.MacAddress = _GetMacAddressOfComputer();
            Record.UserID = clsUserDataBusinessLayar.Find(txtUserName.Text).UserID;
            
           

            if(!Record.Save())
                MessageBox.Show("There is a problem when Save.", "Caption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void _UpdateRecored()
        {
            if ((chkRememberMe.Checked == Record.RemmemberMe)) 
            {
                return;
            }
            else
            {
                Record.RemmemberMe = chkRememberMe.Checked;
                if (!Record.Save())
                    MessageBox.Show("There is a problem when Save.", "Caption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _LoadRemmemberDataToDataBase() 
        {
            if (Record == null)
                _InsertNewMac();

            else
                _UpdateRecored();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.OpenNewFormOnClose = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User = clsUserDataBusinessLayar.Find(txtUserName.Text.Trim());

            if (User == null)
                MessageBox.Show("User Not Available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (User.Password != txtPassword.Text)
                MessageBox.Show("The Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (User.IsActive == false) 
                MessageBox.Show("Your Account Is not Active, Contact Admain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Form Main = new frmMainForm();
                clsGlobleUser.CurrentUser = User;

                _LoadRemmemberDataToDataBase();
                Main.ShowDialog();
                this.Close();
            }
                
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {

            Record = _CheckMacAddressIsExists();

            if(Record != null) //Found
            {
                if(_CheckRemmmberIsChecked(Record))
                {
                    User = clsUserDataBusinessLayar.Find(Record.UserID);

                    txtUserName.Text = User.UserName;
                    txtPassword.Text=User.Password;
                    chkRememberMe.Checked = true;
                }
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

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;

        }
    }
}
