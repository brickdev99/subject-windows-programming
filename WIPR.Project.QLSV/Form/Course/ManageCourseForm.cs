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
    public partial class ManageCourseForm: Form
    {
        public ManageCourseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }

        Course course = new Course();
        int pos;
        
        /// <summary>
        /// Get, load data for ListBoxCourses from database
        /// </summary>
        void reloadListBoxData()
        {
            listBoxCourses.DataSource = course.getAllCourses();
            listBoxCourses.ValueMember = "id";
            listBoxCourses.DisplayMember = "label";

            listBoxCourses.SelectedItem = null;
            labelTotalCourses.Text = ("Total Courses: " + course.totalCourses());
        }

        /// <summary>
        /// Use to insert all information to control from database
        /// </summary>
        /// <param name="index"></param>
        private void showData(int index)
        {
            DataRow dr = course.getAllCourses().Rows[index];

            listBoxCourses.SelectedIndex = index;

            textBoxCourseID.Text = dr.ItemArray[0].ToString();
            textBoxLabel.Text = dr.ItemArray[1].ToString();
            numericUpDownPeriod.Value = int.Parse(dr.ItemArray[2].ToString());
            textBoxDescription.Text = dr.ItemArray[3].ToString();
        }

        /// <summary>
        /// While select change, import information to control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCourses_Click_1(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)listBoxCourses.SelectedItem;
            pos = listBoxCourses.SelectedIndex;

            if (pos < 0 || pos > course.getAllCourses().Rows.Count - 1) pos = 0;
            showData(pos);
        }

        /// <summary>
        /// ButtonAdd one course to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Firstly, check label not empty
            // check this course already exist
            // The period must be > 10

            int sID = Convert.ToInt32(textBoxCourseID.Text);
            string label = textBoxLabel.Text;
            int period = Convert.ToInt32(numericUpDownPeriod.Value);
            string desc = textBoxDescription.Text;

            Course course = new Course();

            // Remove all space
            if (label.Trim() == "")
            {
                MessageBox.Show("Add A Course label", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (course.checkCourseName(label))
            {
                if (course.insertCourse(sID, label, period, desc))
                {
                    MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("This Course label Already Exists", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            reloadListBoxData();
        }

        /// <summary>
        /// ButtonEdit process change information to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name = textBoxLabel.Text;
            int hrs = (int)numericUpDownPeriod.Value;
            string descr = textBoxDescription.Text;
            int id = Convert.ToInt32(textBoxCourseID.Text);

            // Check label course
            if (!course.checkCourseName(name, Convert.ToInt32(textBoxCourseID.Text)))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, name, hrs, descr))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pos = 0;
            reloadListBoxData();
        }

        /// <summary>
        /// ButtonRemove process, remove course by ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = Convert.ToInt32(textBoxCourseID.Text);

                if ((MessageBox.Show("Are Yousure You Want To Delete This Course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (course.deleteCourse(courseID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // clear fields
                        textBoxCourseID.Text = "";
                        textBoxLabel.Text = "";
                        numericUpDownPeriod.Value = 10;
                        textBoxDescription.Text = "";

                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
            catch
            {
                MessageBox.Show("Enter A Valid Numeric ID", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pos = 0;
            reloadListBoxData();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pos < (course.getAllCourses().Rows.Count - 1))
            {
                pos = pos + 1;
                showData(pos);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos = pos - 1;
                showData(pos);
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            pos = course.getAllCourses().Rows.Count - 1;
            showData(pos);
        }
    }
}


