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
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }

        Course course = new Course();

        /// <summary>
        /// Form load, Get all course from Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            comboBoxSelectCourse.DataSource = course.getAllCourses();
            comboBoxSelectCourse.DisplayMember = "Label";
            comboBoxSelectCourse.ValueMember = "id";
            comboBoxSelectCourse.SelectedItem = null;
        }

        public void fillCombo(int index)
        {
            comboBoxSelectCourse.DataSource = course.getAllCourses();
            comboBoxSelectCourse.DisplayMember = "Label";
            comboBoxSelectCourse.ValueMember = "id";
            comboBoxSelectCourse.SelectedIndex = index;
        }

        /// <summary>
        /// While select item in comboBox, process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get data
                int id = Convert.ToInt32(comboBoxSelectCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);

                textBoxLabel.Text = table.Rows[0][1].ToString();
                numericUpDownPeriod.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBoxDescription.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        /// <summary>
        /// ButtonEdit, process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name = textBoxLabel.Text;
            int hrs = (int)numericUpDownPeriod.Value;
            string descr = textBoxDescription.Text;
            int id = (int)comboBoxSelectCourse.SelectedValue;

            // Check label course
            if (!course.checkCourseName(name, Convert.ToInt32(comboBoxSelectCourse.SelectedValue)))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.updateCourse(id, name, hrs, descr))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillCombo(comboBoxSelectCourse.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
    