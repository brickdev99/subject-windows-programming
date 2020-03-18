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

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDeleteStudentForm_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {

        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TextBoxStudentID.Text);
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
                PictureBoxStudentImage.Image.Save(picture, PictureBoxStudentImage.Image.RawFormat);

                if (student.insertStudent(id, firstname, lastname, birthdate, gender, phone, address, picture))
                {
                    MessageBox.Show("New Student Add", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

        Student student = new Student();
        string chosseComboBox;
        //Search theo Student ID, 
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if(this.ComboBoxSearch.SelectedIndex.ToString() == "ID") { chosseComboBox = TextBoxID.Text; }
            else if(this.ComboBoxSearch.SelectedIndex.ToString() == "First Name") { chosseComboBox = TextBoxFisrtName.Text; }
            else if(this.ComboBoxSearch.SelectedIndex.ToString() == "Phone") { chosseComboBox = TextBoxPhone.Text; }
            else if(this.ComboBoxSearch.SelectedIndex.ToString() == "Address") { chosseComboBox = TextBoxAddress.Text; }

            SqlCommand command = new SqlCommand("SELECT * FROM student WHERE id = " + Convert.ToString(chosseComboBox));

            DataTable table = student.getStudents(command);
            if(table.Rows.Count > 0)
            {
                this.TextBoxFisrtName.Text = table.Rows[0]["firstname"].ToString();
                this.TextBoxLastName.Text = table.Rows[0]["lastname"].ToString();
                this.dateTimePicker1.Value = (DateTime)table.Rows[0]["birthdate"];
                //Gender
                if(table.Rows[0]["gender"].ToString() == "Female") { this.RadioButtonFemale.Checked = true; }
                else { this.RadioButtonMale.Checked = true; }
                this.TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                this.TextBoxAddress.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                this.pictureBox1.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("Not Found!", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
