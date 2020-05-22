using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm form = new StaticsForm();
            form.Show(this);
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show(this);
        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm studentList = new StudentListForm();
            studentList.Show(this);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm form = new ManageStudentForm();
            form.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm form = new UpdateDeleteStudentForm();
            form.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudentForm form = new PrintStudentForm();
            form.Show(this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseForm form = new AddCourseForm();
            form.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm form = new RemoveCourseForm();
            form.Show(this);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm form = new EditCourseForm();
            form.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourseForm form = new ManageCourseForm();
            form.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourseForm form = new PrintCourseForm();
            form.Show(this);
        }

        /// <summary>
        /// Score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm form = new AddScoreForm();
            form.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm form = new RemoveScoreForm();
            form.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm form = new ManageScoreForm();
            form.Show(this);
        }

        private void avgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avgScoreByCourseForm form = new avgScoreByCourseForm();
            form.Show(this);
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScoreForm form = new PrintScoreForm();
            form.Show(this);
        }

        private void avgToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            avgResultByScoreForm form = new avgResultByScoreForm();
            form.Show(this);
        }

        private void staticsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsResultForm form = new StaticsResultForm();
            form.Show(this);
        }
    }
}
