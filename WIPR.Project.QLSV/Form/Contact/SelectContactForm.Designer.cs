namespace WIPR.Project.QLSV
{
    partial class SelectContactForm
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
            this.dataGridViewSelectContact = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectContact)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSelectContact
            // 
            this.dataGridViewSelectContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSelectContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectContact.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewSelectContact.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSelectContact.Name = "dataGridViewSelectContact";
            this.dataGridViewSelectContact.RowHeadersWidth = 51;
            this.dataGridViewSelectContact.Size = new System.Drawing.Size(709, 345);
            this.dataGridViewSelectContact.TabIndex = 1;
            this.dataGridViewSelectContact.DoubleClick += new System.EventHandler(this.dataGridViewSelectContact_DoubleClick_1);
            // 
            // SelectContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 370);
            this.Controls.Add(this.dataGridViewSelectContact);
            this.Name = "SelectContactForm";
            this.Text = "SelectContactForm";
            this.Load += new System.EventHandler(this.SelectContactForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewSelectContact;
    }
}