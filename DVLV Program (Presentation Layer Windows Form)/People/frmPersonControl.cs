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
    public partial class frmPersonControl : Form
    {
        private enum _enMode { AddNew, Update }
        private _enMode _Mode;


        public delegate void SendPersonID(object sender, int personID);

        public event SendPersonID GetPersonID;

        private int _PersonID = -1;
        public frmPersonControl()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }
        public frmPersonControl(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

            _Mode = _enMode.Update;
        }

        private void frmPersonControl_Load(object sender, EventArgs e)
        {
            if (this._Mode == _enMode.Update)
                ctrlAboutPerson1.LoadDateFromDataBaseToControl(_PersonID);
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
            _PersonID = ctrlAboutPerson1._PersonID;
            GetPersonID?.Invoke(this, _PersonID);
            this.Close();
        }

       
    }
}
