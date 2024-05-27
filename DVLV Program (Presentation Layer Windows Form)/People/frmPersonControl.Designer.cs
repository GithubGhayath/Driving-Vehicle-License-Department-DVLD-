namespace DVLV_Program
{
    partial class frmPersonControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlAboutPerson1 = new DVLV_Program.ctrlAboutPerson();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(450, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlAboutPerson1
            // 
            this.ctrlAboutPerson1.BackColor = System.Drawing.Color.Snow;
            this.ctrlAboutPerson1.Location = new System.Drawing.Point(-10, -3);
            this.ctrlAboutPerson1.Name = "ctrlAboutPerson1";
            this.ctrlAboutPerson1.Size = new System.Drawing.Size(642, 373);
            this.ctrlAboutPerson1.TabIndex = 0;
            // 
            // frmPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(627, 380);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlAboutPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPersonControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Person Info.";
            this.Load += new System.EventHandler(this.frmPersonControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAboutPerson ctrlAboutPerson1;
        private System.Windows.Forms.Button button1;
    }
}