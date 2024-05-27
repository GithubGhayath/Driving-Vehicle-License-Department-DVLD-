namespace DVLV_Program
{
    partial class frmShowPersonDetails
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
            this.ctrlShowPersonDetale1 = new DVLV_Program.ctrlShowPersonDetale();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLV_Program.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlShowPersonDetale1
            // 
            this.ctrlShowPersonDetale1.Location = new System.Drawing.Point(1, 2);
            this.ctrlShowPersonDetale1.Name = "ctrlShowPersonDetale1";
            this.ctrlShowPersonDetale1.PersonID = 0;
            this.ctrlShowPersonDetale1.Size = new System.Drawing.Size(640, 349);
            this.ctrlShowPersonDetale1.TabIndex = 0;
            // 
            // frmShowPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 358);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowPersonDetale1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Card";
            this.Load += new System.EventHandler(this.frmShowPersonDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowPersonDetale ctrlShowPersonDetale1;
        private System.Windows.Forms.Button button1;
    }
}