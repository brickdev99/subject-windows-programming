namespace WIPR.Project.QLSV
{
    partial class StaticsResultForm
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
            this.labelStaticResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelFail = new System.Windows.Forms.Label();
            this.labelStaticCourse = new System.Windows.Forms.Label();
            this.panelRemoveContact = new System.Windows.Forms.Panel();
            this.listBoxStaticCourse = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panelRemoveContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStaticResult
            // 
            this.labelStaticResult.AutoSize = true;
            this.labelStaticResult.BackColor = System.Drawing.Color.Transparent;
            this.labelStaticResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStaticResult.Location = new System.Drawing.Point(410, 36);
            this.labelStaticResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStaticResult.Name = "labelStaticResult";
            this.labelStaticResult.Size = new System.Drawing.Size(206, 29);
            this.labelStaticResult.TabIndex = 39;
            this.labelStaticResult.Text = "Static by Result";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chocolate;
            this.panel1.Controls.Add(this.labelPass);
            this.panel1.Controls.Add(this.labelFail);
            this.panel1.Location = new System.Drawing.Point(417, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 226);
            this.panel1.TabIndex = 41;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.BackColor = System.Drawing.Color.Transparent;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(-5, 4);
            this.labelPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(72, 26);
            this.labelPass.TabIndex = 36;
            this.labelPass.Text = "Pass:";
            // 
            // labelFail
            // 
            this.labelFail.AutoSize = true;
            this.labelFail.BackColor = System.Drawing.Color.Transparent;
            this.labelFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFail.Location = new System.Drawing.Point(-5, 50);
            this.labelFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFail.Name = "labelFail";
            this.labelFail.Size = new System.Drawing.Size(58, 26);
            this.labelFail.TabIndex = 36;
            this.labelFail.Text = "Fail:";
            // 
            // labelStaticCourse
            // 
            this.labelStaticCourse.AutoSize = true;
            this.labelStaticCourse.BackColor = System.Drawing.Color.Transparent;
            this.labelStaticCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStaticCourse.Location = new System.Drawing.Point(39, 36);
            this.labelStaticCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStaticCourse.Name = "labelStaticCourse";
            this.labelStaticCourse.Size = new System.Drawing.Size(215, 29);
            this.labelStaticCourse.TabIndex = 40;
            this.labelStaticCourse.Text = "Static by Course";
            // 
            // panelRemoveContact
            // 
            this.panelRemoveContact.BackColor = System.Drawing.Color.Gainsboro;
            this.panelRemoveContact.Controls.Add(this.listBoxStaticCourse);
            this.panelRemoveContact.Location = new System.Drawing.Point(46, 71);
            this.panelRemoveContact.Margin = new System.Windows.Forms.Padding(4);
            this.panelRemoveContact.Name = "panelRemoveContact";
            this.panelRemoveContact.Size = new System.Drawing.Size(321, 226);
            this.panelRemoveContact.TabIndex = 42;
            // 
            // listBoxStaticCourse
            // 
            this.listBoxStaticCourse.BackColor = System.Drawing.Color.DodgerBlue;
            this.listBoxStaticCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxStaticCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxStaticCourse.FormattingEnabled = true;
            this.listBoxStaticCourse.ItemHeight = 26;
            this.listBoxStaticCourse.Location = new System.Drawing.Point(0, 4);
            this.listBoxStaticCourse.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxStaticCourse.Name = "listBoxStaticCourse";
            this.listBoxStaticCourse.Size = new System.Drawing.Size(321, 208);
            this.listBoxStaticCourse.TabIndex = 35;
            // 
            // StaticsResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 332);
            this.Controls.Add(this.labelStaticResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStaticCourse);
            this.Controls.Add(this.panelRemoveContact);
            this.Name = "StaticsResultForm";
            this.Text = "StaticsResultForm";
            this.Load += new System.EventHandler(this.StaticsResultForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRemoveContact.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStaticResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelFail;
        private System.Windows.Forms.Label labelStaticCourse;
        private System.Windows.Forms.Panel panelRemoveContact;
        private System.Windows.Forms.ListBox listBoxStaticCourse;
    }
}