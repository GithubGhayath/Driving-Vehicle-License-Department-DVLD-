namespace DVLV_Program
{
    partial class ctrlAboutPerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.txtlastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.rbMaleChoice = new System.Windows.Forms.RadioButton();
            this.rbFemaleChoice = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pbPersonalPhoto = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "National NO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gendor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(89, 133);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(116, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressOnlyText);
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtSecondName
            // 
            this.txtSecondName.Location = new System.Drawing.Point(220, 133);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(116, 20);
            this.txtSecondName.TabIndex = 1;
            this.txtSecondName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressOnlyText);
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtThirdName
            // 
            this.txtThirdName.Location = new System.Drawing.Point(351, 133);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(116, 20);
            this.txtThirdName.TabIndex = 3;
            this.txtThirdName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressOnlyText);
            // 
            // txtlastName
            // 
            this.txtlastName.Location = new System.Drawing.Point(482, 133);
            this.txtlastName.Name = "txtlastName";
            this.txtlastName.Size = new System.Drawing.Size(116, 20);
            this.txtlastName.TabIndex = 4;
            this.txtlastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressOnlyText);
            this.txtlastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(133, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "First";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(257, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Second";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(394, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Third";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(527, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Last";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Person ID:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(89, 259);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(116, 20);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Location = new System.Drawing.Point(89, 175);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(116, 20);
            this.txtNationalNo.TabIndex = 5;
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(91, 304);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(361, 35);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(246, 178);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "Date Of Birth:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(278, 220);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = "Phone:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(272, 262);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "Country:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(336, 217);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(116, 20);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPressOnlyNumbers);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "00/00/0000";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpBirthDate.Location = new System.Drawing.Point(336, 175);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(116, 20);
            this.dtpBirthDate.TabIndex = 6;
            this.dtpBirthDate.Value = new System.DateTime(2024, 3, 20, 0, 0, 0, 0);
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(336, 259);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(116, 21);
            this.cbCountry.TabIndex = 11;
            this.cbCountry.Validating += new System.ComponentModel.CancelEventHandler(this.cbCountry_Validating);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(513, 295);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Set Image";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(517, 322);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(47, 13);
            this.lblRemove.TabIndex = 14;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "Remove";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // rbMaleChoice
            // 
            this.rbMaleChoice.AutoSize = true;
            this.rbMaleChoice.Font = new System.Drawing.Font("Myanmar Text", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaleChoice.Location = new System.Drawing.Point(124, 217);
            this.rbMaleChoice.Name = "rbMaleChoice";
            this.rbMaleChoice.Size = new System.Drawing.Size(48, 21);
            this.rbMaleChoice.TabIndex = 7;
            this.rbMaleChoice.TabStop = true;
            this.rbMaleChoice.Text = "Male";
            this.rbMaleChoice.UseVisualStyleBackColor = true;
            this.rbMaleChoice.CheckedChanged += new System.EventHandler(this.rbMaleChoice_CheckedChanged);
            this.rbMaleChoice.Click += new System.EventHandler(this._SetDefualtPersonPhoto);
            // 
            // rbFemaleChoice
            // 
            this.rbFemaleChoice.AutoSize = true;
            this.rbFemaleChoice.Font = new System.Drawing.Font("Myanmar Text", 6.75F, System.Drawing.FontStyle.Bold);
            this.rbFemaleChoice.Location = new System.Drawing.Point(199, 217);
            this.rbFemaleChoice.Name = "rbFemaleChoice";
            this.rbFemaleChoice.Size = new System.Drawing.Size(57, 21);
            this.rbFemaleChoice.TabIndex = 8;
            this.rbFemaleChoice.TabStop = true;
            this.rbFemaleChoice.Text = "Female";
            this.rbFemaleChoice.UseVisualStyleBackColor = true;
            this.rbFemaleChoice.Click += new System.EventHandler(this._SetDefualtPersonPhoto);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(545, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 22);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonID.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(89, 83);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(19, 15);
            this.lblPersonID.TabIndex = 44;
            this.lblPersonID.Text = "00";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(229, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 30);
            this.lblTitle.TabIndex = 46;
            this.lblTitle.Text = "Add Person";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::DVLV_Program.Properties.Resources.woman;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox10.Location = new System.Drawing.Point(173, 217);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(20, 20);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 40;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::DVLV_Program.Properties.Resources.man;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox7.Location = new System.Drawing.Point(98, 217);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 37;
            this.pictureBox7.TabStop = false;
            // 
            // pbPersonalPhoto
            // 
            this.pbPersonalPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPersonalPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonalPhoto.Location = new System.Drawing.Point(485, 166);
            this.pbPersonalPhoto.Name = "pbPersonalPhoto";
            this.pbPersonalPhoto.Size = new System.Drawing.Size(110, 120);
            this.pbPersonalPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonalPhoto.TabIndex = 27;
            this.pbPersonalPhoto.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLV_Program.Properties.Resources.Add_New_Edit_Person;
            this.pictureBox1.Location = new System.Drawing.Point(-24, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlAboutPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.rbFemaleChoice);
            this.Controls.Add(this.rbMaleChoice);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pbPersonalPhoto);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtlastName);
            this.Controls.Add(this.txtThirdName);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ctrlAboutPerson";
            this.Size = new System.Drawing.Size(639, 393);
            this.Load += new System.EventHandler(this.ctrlAboutPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.TextBox txtlastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.PictureBox pbPersonalPhoto;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.RadioButton rbMaleChoice;
        private System.Windows.Forms.RadioButton rbFemaleChoice;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
    }
}
