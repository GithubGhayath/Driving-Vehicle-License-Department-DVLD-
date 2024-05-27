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
    public partial class ctrlApplicationInformation : UserControl
    {
        public int ApplicationID;

        clsApplicationsBusinessLayar application=new clsApplicationsBusinessLayar();
        public ctrlApplicationInformation()
        {
            InitializeComponent();
        }

        private void _LoadDataToScreen()
        {
             application = clsApplicationsBusinessLayar.Find(ApplicationID);

            lblApplicationID.Text = application.ApplicationID.ToString();
            lblApplicationStatus.Text = clsApplicationStatusBusinessLayar.Find(application.ApplicationStatus).StatusName;
            lblApplicationFees.Text = application.PaidFees.ToString();
            lblApplicaitonType.Text = clsApplicationTypeBusinessLayar.Find(application.ApplicationTypeID).Title;
            lblCreatedBy.Text = clsUserDataBusinessLayar.Find(application.CreatedByUserID).UserName;
            lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text=application.LastStatusDate.ToShortDateString();
            lblApplicant.Text = clsPeopleBusinessLayar.Find(application.ApplicantPersonID).GetFillName();
        }

        public void ShowApplicationDetails()
        {
            _LoadDataToScreen();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmShowPersonDetails = new frmShowPersonDetails(application.ApplicantPersonID);

            frmShowPersonDetails.ShowDialog();

        }
    }

}