namespace WIPR.Project.QLSV
{
    partial class AddNewContactForm
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
            this.comboBoxGroupId = new System.Windows.Forms.ComboBox();
            this.pictureBoxContactImage = new System.Windows.Forms.PictureBox();
            this.ButtonUploadImage = new System.Windows.Forms.Button();
            this.labelAddNewContact = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxLname = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxIDContact = new System.Windows.Forms.TextBox();
            this.labelPicture = new System.Windows.Forms.Label();
            this.labelLname = new System.Windows.Forms.Label();
            this.FName_Label = new System.Windows.Forms.Label();
            this.labelIdContact = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContactImage)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxGroupId
            // 
            this.comboBoxGroupId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGroupId.FormattingEnabled = true;
            this.comboBoxGroupId.Location = new System.Drawing.Point(485, 89);
            this.comboBoxGroupId.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxGroupId.Name = "comboBoxGroupId";
            this.comboBoxGroupId.Size = new System.Drawing.Size(150, 28);
            this.comboBoxGroupId.TabIndex = 85;
            // 
            // pictureBoxContactImage
            // 
            this.pictureBoxContactImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxContactImage.Location = new System.Drawing.Point(160, 185);
            this.pictureBoxContactImage.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxContactImage.Name = "pictureBoxContactImage";
            this.pictureBoxContactImage.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxContactImage.TabIndex = 83;
            this.pictureBoxContactImage.TabStop = false;
            // 
            // ButtonUploadImage
            // 
            this.ButtonUploadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUploadImage.Location = new System.Drawing.Point(53, 304);
            this.ButtonUploadImage.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonUploadImage.Name = "ButtonUploadImage";
            this.ButtonUploadImage.Size = new System.Drawing.Size(99, 28);
            this.ButtonUploadImage.TabIndex = 84;
            this.ButtonUploadImage.Text = "Upload File";
            this.ButtonUploadImage.UseVisualStyleBackColor = true;
            this.ButtonUploadImage.Click += new System.EventHandler(this.ButtonUploadImage_Click);
            // 
            // labelAddNewContact
            // 
            this.labelAddNewContact.AutoSize = true;
            this.labelAddNewContact.BackColor = System.Drawing.Color.Transparent;
            this.labelAddNewContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddNewContact.Location = new System.Drawing.Point(48, 37);
            this.labelAddNewContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddNewContact.Name = "labelAddNewContact";
            this.labelAddNewContact.Size = new System.Drawing.Size(282, 39);
            this.labelAddNewContact.TabIndex = 82;
            this.labelAddNewContact.Text = "Add New Contact";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(515, 292);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 73;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(387, 292);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(120, 40);
            this.buttonAdd.TabIndex = 72;
            this.buttonAdd.Text = "Add Contact";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(485, 182);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(150, 83);
            this.textBoxAddress.TabIndex = 70;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMail.Location = new System.Drawing.Point(485, 151);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(150, 26);
            this.textBoxMail.TabIndex = 71;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.Location = new System.Drawing.Point(485, 120);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(150, 26);
            this.textBoxPhone.TabIndex = 69;
            // 
            // textBoxLname
            // 
            this.textBoxLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLname.Location = new System.Drawing.Point(159, 154);
            this.textBoxLname.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLname.Name = "textBoxLname";
            this.textBoxLname.Size = new System.Drawing.Size(151, 26);
            this.textBoxLname.TabIndex = 68;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(395, 185);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(84, 20);
            this.labelAddress.TabIndex = 75;
            this.labelAddress.Text = "Address:";
            // 
            // textBoxFname
            // 
            this.textBoxFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFname.Location = new System.Drawing.Point(159, 123);
            this.textBoxFname.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.Size = new System.Drawing.Size(151, 26);
            this.textBoxFname.TabIndex = 67;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.BackColor = System.Drawing.Color.Transparent;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMail.Location = new System.Drawing.Point(395, 154);
            this.labelMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(50, 20);
            this.labelMail.TabIndex = 76;
            this.labelMail.Text = "Mail:";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.BackColor = System.Drawing.Color.Transparent;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroup.Location = new System.Drawing.Point(395, 92);
            this.labelGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(66, 20);
            this.labelGroup.TabIndex = 77;
            this.labelGroup.Text = "Group:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.BackColor = System.Drawing.Color.Transparent;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.Location = new System.Drawing.Point(395, 123);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(67, 20);
            this.labelPhone.TabIndex = 78;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxIDContact
            // 
            this.textBoxIDContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDContact.Location = new System.Drawing.Point(159, 92);
            this.textBoxIDContact.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIDContact.Name = "textBoxIDContact";
            this.textBoxIDContact.Size = new System.Drawing.Size(150, 26);
            this.textBoxIDContact.TabIndex = 66;
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.BackColor = System.Drawing.Color.Transparent;
            this.labelPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPicture.Location = new System.Drawing.Point(49, 188);
            this.labelPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(75, 20);
            this.labelPicture.TabIndex = 79;
            this.labelPicture.Text = "Picture:";
            // 
            // labelLname
            // 
            this.labelLname.AutoSize = true;
            this.labelLname.BackColor = System.Drawing.Color.Transparent;
            this.labelLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLname.Location = new System.Drawing.Point(49, 157);
            this.labelLname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLname.Name = "labelLname";
            this.labelLname.Size = new System.Drawing.Size(106, 20);
            this.labelLname.TabIndex = 80;
            this.labelLname.Text = "Last Name:";
            // 
            // FName_Label
            // 
            this.FName_Label.AutoSize = true;
            this.FName_Label.BackColor = System.Drawing.Color.Transparent;
            this.FName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FName_Label.Location = new System.Drawing.Point(49, 126);
            this.FName_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FName_Label.Name = "FName_Label";
            this.FName_Label.Size = new System.Drawing.Size(108, 20);
            this.FName_Label.TabIndex = 81;
            this.FName_Label.Text = "First Name:";
            // 
            // labelIdContact
            // 
            this.labelIdContact.AutoSize = true;
            this.labelIdContact.BackColor = System.Drawing.Color.Transparent;
            this.labelIdContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdContact.Location = new System.Drawing.Point(49, 95);
            this.labelIdContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIdContact.Name = "labelIdContact";
            this.labelIdContact.Size = new System.Drawing.Size(105, 20);
            this.labelIdContact.TabIndex = 74;
            this.labelIdContact.Text = "ID Contact:";
            // 
            // AddNewContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 372);
            this.Controls.Add(this.comboBoxGroupId);
            this.Controls.Add(this.pictureBoxContactImage);
            this.Controls.Add(this.ButtonUploadImage);
            this.Controls.Add(this.labelAddNewContact);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxLname);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxFname);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxIDContact);
            this.Controls.Add(this.labelPicture);
            this.Controls.Add(this.labelLname);
            this.Controls.Add(this.FName_Label);
            this.Controls.Add(this.labelIdContact);
            this.Name = "AddNewContactForm";
            this.Text = "AddNewContactForm";
            this.Load += new System.EventHandler(this.AddNewContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContactImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGroupId;
        public System.Windows.Forms.PictureBox pictureBoxContactImage;
        private System.Windows.Forms.Button ButtonUploadImage;
        private System.Windows.Forms.Label labelAddNewContact;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxLname;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxFname;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxIDContact;
        private System.Windows.Forms.Label labelPicture;
        private System.Windows.Forms.Label labelLname;
        private System.Windows.Forms.Label FName_Label;
        private System.Windows.Forms.Label labelIdContact;
    }
}