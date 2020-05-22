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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ButtonAdd one course to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Firstly, check label not empty
            // check this course already exist
            // The period must be > 10

            int sID = Convert.ToInt32(textBoxCourseID.Text);
            string label = textBoxLabel.Text;
            int period = Convert.ToInt32(textBoxPeriod.Text);
            string desc = textBoxDesciption.Text;

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
        }
        
    }
}
