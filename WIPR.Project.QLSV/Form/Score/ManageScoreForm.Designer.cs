namespace WIPR.Project.QLSV
{
    partial class ManageScoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonShowScores = new System.Windows.Forms.Button();
            this.buttonShowStudent = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_SelectCourse = new System.Windows.Forms.ComboBox();
            this.buttonAveragebyCourse = new System.Windows.Forms.Button();
            this.buttonRemoveScore = new System.Windows.Forms.Button();
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
            // buttonShowScores
            // 
            this.buttonShowScores.Location = new System.Drawing.Point(649, 51);
            this.buttonShowScores.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowScores.Name = "buttonShowScores";
            this.buttonShowScores.Size = new System.Drawing.Size(217, 28);
            this.buttonShowScores.TabIndex = 10;
            this.buttonShowScores.Text = "Show Scores";
            this.buttonShowScores.UseVisualStyleBackColor = true;
            this.buttonShowScores.Click += new System.EventHandler(this.buttonShowScores_Click);
            // 
            // buttonShowStudent
            // 
            this.buttonShowStudent.Location = new System.Drawing.Point(424, 51);
            this.buttonShowStudent.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowStudent.Name = "buttonShowStudent";
            this.buttonShowStudent.Size = new System.Drawing.Size(217, 28);
            this.buttonShowStudent.TabIndex = 9;
            this.buttonShowStudent.Text = "Show Student";
            this.buttonShowStudent.UseVisualStyleBackColor = true;
            this.buttonShowStudent.Click += new System.EventHandler(this.buttonShowStudent_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(424, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(776, 313);
            this.dataGridView1.TabIndex = 81;
            // 
            // comboBox_SelectCourse
            // 
            this.comboBox_SelectCourse.FormattingEnabled = true;
            this.comboBox_SelectCourse.Location = new System.Drawing.Point(196, 83);
            this.comboBox_SelectCourse.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_SelectCourse.Name = "comboBox_SelectCourse";
            this.comboBox_SelectCourse.Size = new System.Drawing.Size(219, 24);
            this.comboBox_SelectCourse.TabIndex = 2;
            // 
            // buttonAveragebyCourse
            // 
            this.buttonAveragebyCourse.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonAveragebyCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAveragebyCourse.Location = new System.Drawing.Point(45, 309);
            this.buttonAveragebyCourse.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAveragebyCourse.Name = "buttonAveragebyCourse";
            this.buttonAveragebyCourse.Size = new System.Drawing.Size(371, 49);
            this.buttonAveragebyCourse.TabIndex = 8;
            this.buttonAveragebyCourse.Text = "Average Score By Course";
            this.buttonAveragebyCourse.UseVisualStyleBackColor = false;
            this.buttonAveragebyCourse.Click += new System.EventHandler(this.buttonAveragebyCourse_Click);
            // 
            // buttonRemoveScore
            // 
            this.buttonRemoveScore.BackColor = System.Drawing.Color.Red;
            this.buttonRemoveScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveScore.Location = new System.Drawing.Point(245, 238);
            this.buttonRemoveScore.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveScore.Name = "buttonRemoveScore";
            this.buttonRemoveScore.Size = new System.Drawing.Size(171, 49);
            this.buttonRemoveScore.TabIndex = 6;
            this.buttonRemoveScore.Text = "Remove Score";
            this.buttonRemoveScore.UseVisualStyleBackColor = false;
            this.buttonRemoveScore.Click += new System.EventHandler(this.buttonRemoveScore_Click);
            // 
            // ButtonAddCourse
            // 
            this.ButtonAddCourse.BackColor = System.Drawing.Color.DodgerBlue;
            this.ButtonAddCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddCourse.Location = new System.Drawing.Point(45, 238);
            this.ButtonAddCourse.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAddCourse.Name = "ButtonAddCourse";
            this.ButtonAddCourse.Size = new System.Drawing.Size(171, 49);
            this.ButtonAddCourse.TabIndex = 5;
            this.ButtonAddCourse.Text = "Add Score";
            this.ButtonAddCourse.UseVisualStyleBackColor = false;
            this.ButtonAddCourse.Click += new System.EventHandler(this.ButtonAddCourse_Click);
            // 
            // textBox_Score
            // 
            this.textBox_Score.Location = new System.Drawing.Point(196, 117);
            this.textBox_Score.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Score.Name = "textBox_Score";
            this.textBox_Score.Size = new System.Drawing.Size(219, 22);
            this.textBox_Score.TabIndex = 3;
            // 
            // TextBoxStudentID
            // 
            this.TextBoxStudentID.Location = new System.Drawing.Point(196, 50);
            this.TextBoxStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxStudentID.Name = "TextBoxStudentID";
            this.TextBoxStudentID.Size = new System.Drawing.Size(219, 22);
            this.TextBoxStudentID.TabIndex = 1;
            // 
            // StudentID_Label
            // 
            this.StudentID_Label.AutoSize = true;
            this.StudentID_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentID_Label.Location = new System.Drawing.Point(69, 51);
            this.StudentID_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StudentID_Label.Name = "StudentID_Label";
            this.StudentID_Label.Size = new System.Drawing.Size(104, 20);
            this.StudentID_Label.TabIndex = 75;
            this.StudentID_Label.Text = "Student ID:";
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(196, 149);
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
            this.Address_Llabel.Location = new System.Drawing.Point(60, 151);
            this.Address_Llabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Address_Llabel.Name = "Address_Llabel";
            this.Address_Llabel.Size = new System.Drawing.Size(112, 20);
            this.Address_Llabel.TabIndex = 69;
            this.Address_Llabel.Text = "Description:";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.Location = new System.Drawing.Point(113, 119);
            this.label_Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(64, 20);
            this.label_Score.TabIndex = 70;
            this.label_Score.Text = "Score:";
            // 
            // label_SelectCourse
            // 
            this.label_SelectCourse.AutoSize = true;
            this.label_SelectCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectCourse.Location = new System.Drawing.Point(34, 84);
            this.label_SelectCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SelectCourse.Name = "label_SelectCourse";
            this.label_SelectCourse.Size = new System.Drawing.Size(134, 20);
            this.label_SelectCourse.TabIndex = 71;
            this.label_SelectCourse.Text = "Select Course:";
            // 
            // ManageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 450);
            this.Controls.Add(this.buttonShowScores);
            this.Controls.Add(this.buttonShowStudent);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_SelectCourse);
            this.Controls.Add(this.buttonAveragebyCourse);
            this.Controls.Add(this.buttonRemoveScore);
            this.Controls.Add(this.ButtonAddCourse);
            this.Controls.Add(this.textBox_Score);
            this.Controls.Add(this.TextBoxStudentID);
            this.Controls.Add(this.StudentID_Label);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.Address_Llabel);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.label_SelectCourse);
            this.Name = "ManageScoreForm";
            this.Text = "ManageScoreForm";
            this.Load += new System.EventHandler(this.ManageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonShowScores;
        private System.Windows.Forms.Button buttonShowStudent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_SelectCourse;
        private System.Windows.Forms.Button buttonAveragebyCourse;
        private System.Windows.Forms.Button buttonRemoveScore;
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