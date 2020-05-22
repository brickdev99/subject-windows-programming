namespace WIPR.Project.QLSV
{
    partial class ShowFullContactForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonShowFull = new System.Windows.Forms.Button();
            this.textBoxFullAddress = new System.Windows.Forms.TextBox();
            this.labelGroupName1 = new System.Windows.Forms.Label();
            this.dataGridViewAllContact = new System.Windows.Forms.DataGridView();
            this.labelAllContact = new System.Windows.Forms.Label();
            this.listBoxAllGroup = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllContact)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(998, 409);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(167, 28);
            this.buttonCancel.TabIndex = 48;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // buttonShowFull
            // 
            this.buttonShowFull.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonShowFull.FlatAppearance.BorderSize = 0;
            this.buttonShowFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowFull.Location = new System.Drawing.Point(479, 37);
            this.buttonShowFull.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowFull.Name = "buttonShowFull";
            this.buttonShowFull.Size = new System.Drawing.Size(167, 28);
            this.buttonShowFull.TabIndex = 49;
            this.buttonShowFull.Text = "Show Full";
            this.buttonShowFull.UseVisualStyleBackColor = false;
            this.buttonShowFull.Click += new System.EventHandler(this.buttonShowFull_Click_1);
            // 
            // textBoxFullAddress
            // 
            this.textBoxFullAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullAddress.Location = new System.Drawing.Point(321, 409);
            this.textBoxFullAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFullAddress.Multiline = true;
            this.textBoxFullAddress.Name = "textBoxFullAddress";
            this.textBoxFullAddress.Size = new System.Drawing.Size(445, 27);
            this.textBoxFullAddress.TabIndex = 47;
            // 
            // labelGroupName1
            // 
            this.labelGroupName1.AutoSize = true;
            this.labelGroupName1.BackColor = System.Drawing.Color.Transparent;
            this.labelGroupName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupName1.Location = new System.Drawing.Point(317, 384);
            this.labelGroupName1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroupName1.Name = "labelGroupName1";
            this.labelGroupName1.Size = new System.Drawing.Size(121, 20);
            this.labelGroupName1.TabIndex = 46;
            this.labelGroupName1.Text = "Full Address:";
            // 
            // dataGridViewAllContact
            // 
            this.dataGridViewAllContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllContact.Location = new System.Drawing.Point(321, 69);
            this.dataGridViewAllContact.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAllContact.Name = "dataGridViewAllContact";
            this.dataGridViewAllContact.RowHeadersWidth = 51;
            this.dataGridViewAllContact.Size = new System.Drawing.Size(844, 311);
            this.dataGridViewAllContact.TabIndex = 45;
            this.dataGridViewAllContact.Click += new System.EventHandler(this.dataGridViewAllContact_Click_1);
            // 
            // labelAllContact
            // 
            this.labelAllContact.AutoSize = true;
            this.labelAllContact.BackColor = System.Drawing.Color.Transparent;
            this.labelAllContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllContact.Location = new System.Drawing.Point(314, 35);
            this.labelAllContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAllContact.Name = "labelAllContact";
            this.labelAllContact.Size = new System.Drawing.Size(147, 29);
            this.labelAllContact.TabIndex = 44;
            this.labelAllContact.Text = "All Contact";
            // 
            // listBoxAllGroup
            // 
            this.listBoxAllGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAllGroup.FormattingEnabled = true;
            this.listBoxAllGroup.ItemHeight = 20;
            this.listBoxAllGroup.Location = new System.Drawing.Point(50, 69);
            this.listBoxAllGroup.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxAllGroup.Name = "listBoxAllGroup";
            this.listBoxAllGroup.Size = new System.Drawing.Size(241, 224);
            this.listBoxAllGroup.TabIndex = 43;
            this.listBoxAllGroup.Click += new System.EventHandler(this.listBoxAllGroup_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 29);
            this.label4.TabIndex = 42;
            this.label4.Text = "Group";
            // 
            // ShowFullContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 473);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonShowFull);
            this.Controls.Add(this.textBoxFullAddress);
            this.Controls.Add(this.labelGroupName1);
            this.Controls.Add(this.dataGridViewAllContact);
            this.Controls.Add(this.labelAllContact);
            this.Controls.Add(this.listBoxAllGroup);
            this.Controls.Add(this.label4);
            this.Name = "ShowFullContactForm";
            this.Text = "ShowFullContactForm";
            this.Load += new System.EventHandler(this.ShowFullContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonShowFull;
        private System.Windows.Forms.TextBox textBoxFullAddress;
        private System.Windows.Forms.Label labelGroupName1;
        private System.Windows.Forms.DataGridView dataGridViewAllContact;
        private System.Windows.Forms.Label labelAllContact;
        private System.Windows.Forms.ListBox listBoxAllGroup;
        private System.Windows.Forms.Label label4;
    }
}