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
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        public string str_command = "SELECT student_id[ID Student], firstname[First Name], " +
                                                            "lastname[Last Name],course_id[Course ID],label[Name Cousre], student_score[Score] " +
                                                            "FROM(dbo.score JOIN dbo.student ON id = student_id) JOIN dbo.course ON  " +
                                                            "course.id = course_id; ";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadData()
        {
            dataGridView1.DataSource = score.getScore(new SqlCommand(str_command));
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RemoveScore_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int courseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

                if ((MessageBox.Show("Are you sure you want to delete this Score?", "Delete Course!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (score.deleteScore(studentID, courseID))
                    {
                        MessageBox.Show("Score Deleted!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error!", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
