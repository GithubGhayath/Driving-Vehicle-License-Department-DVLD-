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
    public partial class frmUserDetails : Form
    {
        private int _UserID;
        public frmUserDetails()
        {
            InitializeComponent();
        }
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            clsUserDataBusinessLayar User= clsUserDataBusinessLayar.Find(_UserID);
            ctrlShowPersonDetale1.PersonID = User.PersonID;
            ctrlShowPersonDetale1.LoadPersonInformation();
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text=User.UserName.ToString();
            lblIsActive.Text = (User.IsActive == true) ? "Yes" : "No";

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
    }
}
