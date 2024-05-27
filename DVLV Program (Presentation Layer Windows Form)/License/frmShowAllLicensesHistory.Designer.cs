namespace DVLV_Program
{
    partial class frmShowAllLicensesHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocalLicense = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternationalLicense = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountRows = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlSelectPerson1 = new DVLV_Program.ctrlSelectPerson();
            this.tabControl1.SuspendLayout();
            this.tpLocalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tpInternationalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocalLicense);
            this.tabControl1.Controls.Add(this.tpInternationalLicense);
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(23, 461);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(650, 126);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpLocalLicense
            // 
            this.tpLocalLicense.Controls.Add(this.dgvLocalLicenses);
            this.tpLocalLicense.Location = new System.Drawing.Point(4, 24);
            this.tpLocalLicense.Name = "tpLocalLicense";
            this.tpLocalLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicense.Size = new System.Drawing.Size(642, 98);
            this.tpLocalLicense.TabIndex = 0;
            this.tpLocalLicense.Text = "Local";
            this.tpLocalLicense.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(3, 3);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersVisible = false;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(636, 92);
            this.dgvLocalLicenses.TabIndex = 0;
            this.dgvLocalLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalLicenses_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 26);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // tpInternationalLicense
            // 
            this.tpInternationalLicense.Controls.Add(this.dgvInternationalLicenses);
            this.tpInternationalLicense.Location = new System.Drawing.Point(4, 22);
            this.tpInternationalLicense.Name = "tpInternationalLicense";
            this.tpInternationalLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicense.Size = new System.Drawing.Size(642, 100);
            this.tpInternationalLicense.TabIndex = 1;
            this.tpInternationalLicense.Text = "Intrenational";
            this.tpInternationalLicense.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInternationalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(3, 3);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(636, 94);
            this.dgvInternationalLicenses.TabIndex = 0;
            this.dgvInternationalLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInternationalLicenses_CellMouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Driver Licenses";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(656, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-13, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "#Records:";
            // 
            // lblCountRows
            // 
            this.lblCountRows.AutoSize = true;
            this.lblCountRows.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRows.Location = new System.Drawing.Point(45, 628);
            this.lblCountRows.Name = "lblCountRows";
            this.lblCountRows.Size = new System.Drawing.Size(28, 14);
            this.lblCountRows.TabIndex = 6;
            this.lblCountRows.Text = "???";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLV_Program.Properties.Resources.LIcense_History1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(705, 605);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlSelectPerson1
            // 
            this.ctrlSelectPerson1.Location = new System.Drawing.Point(44, 45);
            this.ctrlSelectPerson1.Name = "ctrlSelectPerson1";
            this.ctrlSelectPerson1.Size = new System.Drawing.Size(629, 386);
            this.ctrlSelectPerson1.TabIndex = 0;
            // 
            // frmShowAllLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 605);
            this.Controls.Add(this.lblCountRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ctrlSelectPerson1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowAllLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmShowAllLicensesHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpLocalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpInternationalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSelectPerson ctrlSelectPerson1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocalLicense;
        private System.Windows.Forms.TabPage tpInternationalLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountRows;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}