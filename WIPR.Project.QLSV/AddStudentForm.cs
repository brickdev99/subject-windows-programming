using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            int id = Convert.ToInt32(TextBoxStudentID.Text);
            string firstname = TextBoxFirstName.Text;
            string lastname = TextBoxLastName.Text;
            DateTime birthdate = dateTimePicker1.Value;
            string phone = TextBoxPhone.Text;
            string address = TextBoxAddress.Text;
            string gender = "Male";
            if((RadioButtonFemale.Checked)) { gender = "Female"; }
            MemoryStream picture = new MemoryStream();

            int bornYear = dateTimePicker1.Value.Year;
            int thisYear = DateTime.Now.Year;

            //Sinh vien 10 - 100, co the thay doi
            if((thisYear - bornYear) < 10 || (thisYear - bornYear) > 100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(verif())
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

        //Kiem tra du lieu Input
        bool verif()
        {
            if((TextBoxFirstName.Text.Trim() == "")
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

        private void bt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Select Image(*.jpg;*.png;*.gif)|*.ipg;*.png;*.gif";

            if((open.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(open.FileName);
            }
        }

        private void TextBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
