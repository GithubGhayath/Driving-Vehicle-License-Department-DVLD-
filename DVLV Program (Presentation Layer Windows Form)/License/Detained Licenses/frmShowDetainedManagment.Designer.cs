namespace DVLV_Program
{
    partial class frmShowDetainedManagment
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
            this.dgvDetainInformation = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnter = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainInformation)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetainInformation
            // 
            this.dgvDetainInformation.AllowUserToAddRows = false;
            this.dgvDetainInformation.AllowUserToDeleteRows = false;
            this.dgvDetainInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainInformation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDetainInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainInformation.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetainInformation.Location = new System.Drawing.Point(37, 226);
            this.dgvDetainInformation.Name = "dgvDetainInformation";
            this.dgvDetainInformation.ReadOnly = true;
            this.dgvDetainInformation.Size = new System.Drawing.Size(760, 224);
            this.dgvDetainInformation.TabIndex = 0;
            this.dgvDetainInformation.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDetainInformation_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLToolStripMenuItem,
            this.iToolStripMenuItem,
            this.cToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLToolStripMenuItem
            // 
            this.showLToolStripMenuItem.Name = "showLToolStripMenuItem";
            this.showLToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showLToolStripMenuItem.Text = "Show License Details";
            this.showLToolStripMenuItem.Click += new System.EventHandler(this.showLToolStripMenuItem_Click);
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.iToolStripMenuItem.Text = "Show Person License History";
            this.iToolStripMenuItem.Click += new System.EventHandler(this.iToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.cToolStripMenuItem.Text = "Release Detained License";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "#Records:";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(93, 459);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(31, 15);
            this.lblRowCount.TabIndex = 2;
            this.lblRowCount.Text = "[???]";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(721, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 21);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(88, 195);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(132, 20);
            this.txtFilterBy.TabIndex = 6;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None"});
            this.cbFilterBy.Location = new System.Drawing.Point(88, 169);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(132, 21);
            this.cbFilterBy.TabIndex = 7;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter By:";
            // 
            // lblEnter
            // 
            this.lblEnter.AutoSize = true;
            this.lblEnter.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnter.Location = new System.Drawing.Point(48, 197);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(36, 15);
            this.lblEnter.TabIndex = 10;
            this.lblEnter.Text = "Enter:";
            // 
            // btnDetain
            // 
            this.btnDetain.BackgroundImage = global::DVLV_Program.Properties.Resources.padlock__1_;
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetain.Location = new System.Drawing.Point(758, 187);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(36, 35);
            this.btnDetain.TabIndex = 5;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BackgroundImage = global::DVLV_Program.Properties.Resources.unlock;
            this.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelease.Location = new System.Drawing.Point(713, 187);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(36, 35);
            this.btnRelease.TabIndex = 4;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV_Program.Properties.Resources.Detained_And_Released_Managment;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(865, 507);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmShowDetainedManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 504);
            this.Controls.Add(this.lblEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetainInformation);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowDetainedManagment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowDetainedManagment";
            this.Load += new System.EventHandler(this.frmShowDetainedManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainInformation)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetainInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEnter;
    }
}