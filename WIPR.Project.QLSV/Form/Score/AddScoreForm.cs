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
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        Course course = new Course();
        Student student = new Student();

        /// <summary>
        /// Add Score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                int studentid = Convert.ToInt32(TextBoxStudentID.Text);
                float scoress = (float)Math.Round(Convert.ToDouble(textBox_Score.Text.Trim()), 2);
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
                        loadData();
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
            catch { }
        }

        /// <summary>
        /// load information
        /// </summary>
        private void loadData()
        {
            string str_command = "SELECT	a.student_id[Student ID], b.label[Name Course], a.student_score[Score], a.description[Description] FROM dbo.score a, dbo.course b WHERE a.course_id = b.Id";
            dataGridView1.DataSource = course.getAllCourses(new SqlCommand(str_command));
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            loadData();
            dataGridView1.ReadOnly = true;
            // dùng combobox lay ten Course 
            SqlCommand command1 = new SqlCommand("SELECT * FROM Course");
            comboBox_SelectCourse.DataSource = course.getAllCourses(command1);
            comboBox_SelectCourse.DisplayMember = "label";
            comboBox_SelectCourse.ValueMember = "id";
            comboBox_SelectCourse.SelectedItem = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void fillCombo(int index)
        {
            SqlCommand command1 = new SqlCommand("SELECT * FROM Course");
            comboBox_SelectCourse.DataSource = course.getAllCourses(command1);
            comboBox_SelectCourse.DisplayMember = "label";
            comboBox_SelectCourse.ValueMember = "id";
            comboBox_SelectCourse.SelectedIndex = index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TextBoxStudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox_SelectCourse.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_Score.Text = Math.Round(Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim()), 2).ToString();
            TextBoxDescription.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox_SelectCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);
            }
            catch { }
        }
    }
}
