using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        Course course = new Course();
        //Use Student = 1 || Scores = 2
        int check = 1;

        string str_student = "SELECT id[ID Student], firstname[Firse Name], lastname[Last Name]," +
                                          " birthdate[Birth Date]FROM dbo.student;";
        string str_scores = "SELECT student_id[ID Student], firstname[First Name], " +
                                        "lastname[Last Name],course_id[Course ID],label[Name Cousre], student_score[Score] " +
                                        "FROM(dbo.score JOIN dbo.student ON id = student_id) JOIN dbo.course ON  " +
                                        "course.id = course_id; ";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool check_info()
        {
            return !(TextBoxDescription.Text == "" ||
                TextBoxStudentID.Text == "" ||
                textBox_Score.Text == "" ||
                comboBox_SelectCourse.Text == "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            loadData(str_student);
            SqlCommand command = new SqlCommand("SELECT * FROM Course");
            comboBox_SelectCourse.DataSource = course.getAllCourses(command);
            comboBox_SelectCourse.DisplayMember = "label";
            comboBox_SelectCourse.ValueMember = "id";
            comboBox_SelectCourse.SelectedItem = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_command"></param>
        void loadData(string str_command)
        {
            dataGridView1.DataSource = score.getScore(new SqlCommand(str_command));

            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            if (check_info())
            {
                int studentid = Convert.ToInt32(TextBoxStudentID.Text);
                float scoress = (float)Convert.ToDouble(textBox_Score.Text);
                string description = TextBoxDescription.Text;
                int courseid = (int)comboBox_SelectCourse.SelectedValue;
                if (textBox_Score.Text.Trim() == "")
                {
                    MessageBox.Show("Score is not available", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (score.checkScore(studentid, courseid))
                {
                    if (score.insertScore(studentid, courseid, scoress, description))
                    {
                        MessageBox.Show("New Score Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(str_scores);
                        dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                        check = 2;
                        TextBoxDescription.Text = TextBoxStudentID.Text = comboBox_SelectCourse.Text = textBox_Score.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Score Not Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Score information already exists", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Miss information, please input all information!", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveScore_Click(object sender, EventArgs e)
        {
            if (check == 2)
            {
                try
                {
                    int studentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    int courseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

                    if ((MessageBox.Show("Are you sure you want to delete this Score?", "Delete Course!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (score.deleteScore(studentID, courseID))
                        {
                            MessageBox.Show("Score Deleted!", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData(str_scores);
                            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                            check = 2;
                        }
                        else
                        {
                            MessageBox.Show("Score Not Deleted!", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Error!", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please show to the scoreboard", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData(str_scores);
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                check = 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAveragebyCourse_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm avgScore = new avgScoreByCourseForm();
            avgScore.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowStudent_Click(object sender, EventArgs e)
        {
            loadData(str_student);
            check = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowScores_Click(object sender, EventArgs e)
        {
            loadData(str_scores);
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            check = 2;
        }
    }
}
