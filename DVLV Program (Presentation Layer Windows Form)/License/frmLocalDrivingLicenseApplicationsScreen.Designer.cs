namespace DVLV_Program
{
    partial class frmLocalDrivingLicenseApplicationsScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvLocalApplications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicaionToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtInputFilter = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbStatusType = new System.Windows.Forms.ComboBox();
            this.lblEnter = new System.Windows.Forms.Label();
            this.btnAddNewLocalLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalApplications
            // 
            this.dgvLocalApplications.AllowUserToAddRows = false;
            this.dgvLocalApplications.AllowUserToDeleteRows = false;
            this.dgvLocalApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalApplications.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalApplications.Location = new System.Drawing.Point(34, 192);
            this.dgvLocalApplications.Name = "dgvLocalApplications";
            this.dgvLocalApplications.ReadOnly = true;
            this.dgvLocalApplications.RowHeadersVisible = false;
            this.dgvLocalApplications.Size = new System.Drawing.Size(717, 220);
            this.dgvLocalApplications.TabIndex = 0;
            this.dgvLocalApplications.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalApplications_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicaionToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sechduleTestsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 232);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicaionToolStripMenuItem
            // 
            this.editApplicaionToolStripMenuItem.Name = "editApplicaionToolStripMenuItem";
            this.editApplicaionToolStripMenuItem.Size = new System.Drawing.Size(242, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(242, 6);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            this.sechduleTestsToolStripMenuItem.Click += new System.EventHandler(this.sechduleTestsToolStripMenuItem_Click);
            this.sechduleTestsToolStripMenuItem.MouseHover += new System.EventHandler(this.sechduleTestsToolStripMenuItem_MouseHover);
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.sechduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.sechduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sechduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.sechduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(242, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(242, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "#Record:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(91, 419);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(25, 15);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "???";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None"});
            this.cbFilterBy.Location = new System.Drawing.Point(93, 129);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(168, 21);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtInputFilter
            // 
            this.txtInputFilter.Location = new System.Drawing.Point(94, 159);
            this.txtInputFilter.Name = "txtInputFilter";
            this.txtInputFilter.Size = new System.Drawing.Size(168, 20);
            this.txtInputFilter.TabIndex = 5;
            this.txtInputFilter.TextChanged += new System.EventHandler(this.txtInputFilter_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(676, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbStatusType
            // 
            this.cbStatusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusType.FormattingEnabled = true;
            this.cbStatusType.Items.AddRange(new object[] {
            "All"});
            this.cbStatusType.Location = new System.Drawing.Point(100, 159);
            this.cbStatusType.Name = "cbStatusType";
            this.cbStatusType.Size = new System.Drawing.Size(121, 21);
            this.cbStatusType.TabIndex = 9;
            this.cbStatusType.SelectedIndexChanged += new System.EventHandler(this.cbStatusType_SelectedIndexChanged);
            // 
            // lblEnter
            // 
            this.lblEnter.AutoSize = true;
            this.lblEnter.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnter.Location = new System.Drawing.Point(52, 162);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(36, 15);
            this.lblEnter.TabIndex = 11;
            this.lblEnter.Text = "Enter:";
            // 
            // btnAddNewLocalLicense
            // 
            this.btnAddNewLocalLicense.BackgroundImage = global::DVLV_Program.Properties.Resources.identification;
            this.btnAddNewLocalLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLocalLicense.Location = new System.Drawing.Point(716, 156);
            this.btnAddNewLocalLicense.Name = "btnAddNewLocalLicense";
            this.btnAddNewLocalLicense.Size = new System.Drawing.Size(32, 32);
            this.btnAddNewLocalLicense.TabIndex = 8;
            this.btnAddNewLocalLicense.UseVisualStyleBackColor = true;
            this.btnAddNewLocalLicense.Click += new System.EventHandler(this.btnAddNewLocalLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV_Program.Properties.Resources.Local_Licenses_Managment;
            this.pictureBox1.Location = new System.Drawing.Point(-8, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(829, 475);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplicationsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 469);
            this.Controls.Add(this.lblEnter);
            this.Controls.Add(this.cbStatusType);
            this.Controls.Add(this.btnAddNewLocalLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtInputFilter);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocalApplications);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLocalDrivingLicenseApplicationsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLocalDrivingLicenseApplicationsScreen";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtInputFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewLocalLicense;
        private System.Windows.Forms.ComboBox cbStatusType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator editApplicaionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEnter;
    }
}