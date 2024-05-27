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
    public partial class frmShowPersonDetails : Form
    {
        private int _PersonID {  get; set; }
        public frmShowPersonDetails(int personID)
        {
            //This method will build this class and all class inside it
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlShowPersonDetale1.PersonID = _PersonID;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
