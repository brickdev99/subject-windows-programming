namespace WIPR.Project.QLSV
{
    partial class AddScoreForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_SelectCourse = new System.Windows.Forms.ComboBox();
            this.ButtonAddCourse = new System.Windows.Forms.Button();
            this.textBox_Score = new System.Windows.Forms.TextBox();
            this.TextBoxStudentID = new System.Windows.Forms.TextBox();
            this.StudentID_Label = new System.Windows.Forms.Label();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.Address_Llabel = new System.Windows.Forms.Label();
            this.label_Score = new System.Windows.Forms.Label();
            this.label_SelectCourse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(433, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(553, 238);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // comboBox_SelectCourse
            // 
            this.comboBox_SelectCourse.FormattingEnabled = true;
            this.comboBox_SelectCourse.Location = new System.Drawing.Point(205, 64);
            this.comboBox_SelectCourse.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_SelectCourse.Name = "comboBox_SelectCourse";
            this.comboBox_SelectCourse.Size = new System.Drawing.Size(219, 24);
            this.comboBox_SelectCourse.TabIndex = 2;
            this.comboBox_SelectCourse.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectCourse_SelectedIndexChanged);
            // 
            // ButtonAddCourse
            // 
            this.ButtonAddCourse.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonAddCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddCourse.Location = new System.Drawing.Point(205, 219);
            this.ButtonAddCourse.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAddCourse.Name = "ButtonAddCourse";
            this.ButtonAddCourse.Size = new System.Drawing.Size(133, 49);
            this.ButtonAddCourse.TabIndex = 5;
            this.ButtonAddCourse.Text = "Add Score";
            this.ButtonAddCourse.UseVisualStyleBackColor = false;
            this.ButtonAddCourse.Click += new System.EventHandler(this.ButtonAddCourse_Click);
            // 
            // textBox_Score
            // 
            this.textBox_Score.Location = new System.Drawing.Point(205, 98);
            this.textBox_Score.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Score.Name = "textBox_Score";
            this.textBox_Score.Size = new System.Drawing.Size(219, 22);
            this.textBox_Score.TabIndex = 3;
            // 
            // TextBoxStudentID
            // 
            this.TextBoxStudentID.Location = new System.Drawing.Point(205, 31);
            this.TextBoxStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxStudentID.Name = "TextBoxStudentID";
            this.TextBoxStudentID.Size = new System.Drawing.Size(219, 22);
            this.TextBoxStudentID.TabIndex = 1;
            // 
            // StudentID_Label
            // 
            this.StudentID_Label.AutoSize = true;
            this.StudentID_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentID_Label.Location = new System.Drawing.Point(78, 32);
            this.StudentID_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StudentID_Label.Name = "StudentID_Label";
            this.StudentID_Label.Size = new System.Drawing.Size(104, 20);
            this.StudentID_Label.TabIndex = 64;
            this.StudentID_Label.Text = "Student ID:";
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(205, 130);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(219, 80);
            this.TextBoxDescription.TabIndex = 4;
            // 
            // Address_Llabel
            // 
            this.Address_Llabel.AutoSize = true;
            this.Address_Llabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address_Llabel.Location = new System.Drawing.Point(69, 132);
            this.Address_Llabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Address_Llabel.Name = "Address_Llabel";
            this.Address_Llabel.Size = new System.Drawing.Size(112, 20);
            this.Address_Llabel.TabIndex = 58;
            this.Address_Llabel.Text = "Description:";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.Location = new System.Drawing.Point(122, 100);
            this.label_Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(64, 20);
            this.label_Score.TabIndex = 59;
            this.label_Score.Text = "Score:";
            // 
            // label_SelectCourse
            // 
            this.label_SelectCourse.AutoSize = true;
            this.label_SelectCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectCourse.Location = new System.Drawing.Point(43, 65);
            this.label_SelectCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SelectCourse.Name = "label_SelectCourse";
            this.label_SelectCourse.Size = new System.Drawing.Size(134, 20);
            this.label_SelectCourse.TabIndex = 60;
            this.label_SelectCourse.Text = "Select Course:";
            // 
            // AddScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 310);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_SelectCourse);
            this.Controls.Add(this.ButtonAddCourse);
            this.Controls.Add(this.textBox_Score);
            this.Controls.Add(this.TextBoxStudentID);
            this.Controls.Add(this.StudentID_Label);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.Address_Llabel);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.label_SelectCourse);
            this.Name = "AddScoreForm";
            this.Text = "AddScoreForm";
            this.Load += new System.EventHandler(this.AddScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_SelectCourse;
        private System.Windows.Forms.Button ButtonAddCourse;
        private System.Windows.Forms.TextBox textBox_Score;
        private System.Windows.Forms.TextBox TextBoxStudentID;
        private System.Windows.Forms.Label StudentID_Label;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Label Address_Llabel;
        private System.Windows.Forms.Label label_Score;
        private System.Windows.Forms.Label label_SelectCourse;
    }
}