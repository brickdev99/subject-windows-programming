using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Import image from disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Select Image(*.jpg;*.png;*.gif)|*.ipg;*.png;*.gif";

            if ((open.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(open.FileName);
            }
        }

        private void UpdateDeleteStudentForm_DoubleClick(object sender, EventArgs e)
        {

        }

        Student student = new Student();

        /// <summary>
        /// Search student by StudentID or Phone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            //Dieu kien search
            int chosse;
            if (ComboBoxSearch.SelectedItem == null) { MessageBox.Show("Please chosse for Search!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                if(ComboBoxSearch.SelectedItem.ToString() == "ID") { chosse = Convert.ToInt32(this.TextBoxID.Text); }
                else { chosse = Convert.ToInt32(this.TextBoxPhone.Text); }
                SqlCommand command = new SqlCommand("SELECT * FROM student WHERE id = " + chosse + "or phone = " + chosse);

                DataTable table = student.getStudents(command);
                if (table.Rows.Count > 0)
                {
                    this.TextBoxID.Text = table.Rows[0]["id"].ToString();
                    this.TextBoxFirstName.Text = table.Rows[0]["firstname"].ToString();
                    this.TextBoxLastName.Text = table.Rows[0]["lastname"].ToString();
                    this.dateTimePicker1.Value = (DateTime)table.Rows[0]["birthdate"];
                    //Gender
                    if (table.Rows[0]["gender"].ToString() == "Female") { this.RadioButtonFemale.Checked = true; }
                    else { this.RadioButtonMale.Checked = true; }
                    this.TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    this.TextBoxAddress.Text = table.Rows[0]["address"].ToString();

                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    this.PictureBoxStudentImage.Image = Image.FromStream(picture);
                }
                else
                {
                    MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //Kiem Tra du lieu dau vao
        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        /// <summary>
        /// Edit, update student information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int id;
            string firstname = TextBoxFirstName.Text;
            string lastname = TextBoxLastName.Text;
            DateTime birthdate = dateTimePicker1.Value;
            string phone = TextBoxPhone.Text;
            string address = TextBoxAddress.Text;
            string gender = "Male";
            if ((RadioButtonFemale.Checked)) { gender = "Female"; }
            MemoryStream picture = new MemoryStream();

            int bornYear = dateTimePicker1.Value.Year;
            int thisYear = DateTime.Now.Year;

            //Sinh vien 10 - 100, co the thay doi
            if ((thisYear - bornYear) < 10 || (thisYear - bornYear) > 100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(TextBoxID.Text);
                    PictureBoxStudentImage.Image.Save(picture, PictureBoxStudentImage.Image.RawFormat);

                    if (student.updateStudent(id, firstname, lastname, birthdate, gender, phone, address, picture))
                    {
                        MessageBox.Show("Student Information update!", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Kiem tra du lieu Input
        bool verif()
        {
            if ((TextBoxFirstName.Text.Trim() == "")
                || (TextBoxLastName.Text.Trim() == "")
                || (TextBoxAddress.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (PictureBoxStudentImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Remove, delete student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            //Delete Student
            try
            {
                int  studentid = Convert.ToInt32(TextBoxID.Text);

                //Display show a information before the delete
                if(MessageBox.Show("Are you sure want to delete This Student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStudent(studentid))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Clean all of the data
                        TextBoxID.Text = "";
                        TextBoxFirstName.Text = "";
                        TextBoxLastName.Text = "";
                        TextBoxPhone.Text = "";
                        TextBoxAddress.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        PictureBoxStudentImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
