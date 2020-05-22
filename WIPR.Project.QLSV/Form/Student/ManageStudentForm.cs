using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Copy from Old Form, import image on disk
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

        Student student = new Student();

        public object SystemDBnull { get; private set; }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            fillGird(new SqlCommand("SELECT * FROM student"));
        }

        /// <summary>
        /// Copy from the StudentListFrom, import data to DataGridView
        /// </summary>
        /// <param name="command"></param>
        public void fillGird(SqlCommand command)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet.student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.qLSVDBDataSet.student);

            DataGridView1.ReadOnly = true;

            //Xu ly hinh anh, tham khao MSDN.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();        //Doi tuong lam viec la Image cua DataGirdView
            DataGridView1.RowTemplate.Height = 80;      //Tham khao MSDN 10/03/2019, co gian Image dep. Dang tim Auto-Size 
            DataGridView1.DataSource = student.getStudents(command);

            imageColumn = (DataGridViewImageColumn)DataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;

            // Count all student
            labelTotalStudents.Text = ("Total Students: " + DataGridView1.Rows.Count);
        }

        /// <summary>
        /// Reset the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            TextBoxID.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxPhone.Text = "";
            TextBoxAddress.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            RadioButtonMale.Checked = true;
            PictureBoxStudentImage.Image = null;
        }

        /// <summary>
        /// Download image, save file on disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDownloadImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.FileName = ("Student_" + TextBoxID.Text);

            if (PictureBoxStudentImage.Image == null)
            {
                MessageBox.Show("No image!");
            }
            else if ((file.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image.Save((file.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        /// <summary>
        /// Copy from AddStudentForm, add one student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            int id = Convert.ToInt32(TextBoxID.Text);
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

            refreshDataGirdView();
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
        /// Copy from UpdateDeleteStudentForm, edit information student
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            refreshDataGirdView();
        }

        /// <summary>
        /// Copy from UpdateDeleteStudentForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            //Delete Student
            try
            {
                int studentid = Convert.ToInt32(TextBoxID.Text);

                //Display show a information before the delete
                if (MessageBox.Show("Are you sure want to delete This Student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

            refreshDataGirdView();
        }

        /// <summary>
        /// Button search by operator LIKE%% in SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student WHERE CONCAT(firstname,lastname,address) LIKE'%" + textBoxSearch.Text + "%'");
            fillGird(command);
        }

        /// <summary>
        /// Copy Old form
        /// </summary>
        private void refreshDataGirdView()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student");
            DataGridView1.ReadOnly = true;

            //Xu ly hinh anh, tham khao MSDN.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();    //Doi tuong lam viec la Image cua DataGirdView
            DataGridView1.RowTemplate.Height = 80;  //Tham khao MSDN 10/03/2019, co gian Image dep. Dang tim Auto-Size 
            DataGridView1.DataSource = student.getStudents(command);

            imageColumn = (DataGridViewImageColumn)DataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Import information student form DataGridView when DoubleClick on student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lay du lieu tu Student ID - FName - LName - BirthDate - Gender - Phone - Address - Picture
            TextBoxID.Text = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
            TextBoxFirstName.Text = this.DataGridView1.CurrentRow.Cells[1].Value.ToString();
            TextBoxLastName.Text = this.DataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)this.DataGridView1.CurrentRow.Cells[3].Value;
            //Gender
            if ((this.DataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")) { RadioButtonFemale.Checked = true; }
            else { RadioButtonMale.Checked = true; }
            TextBoxPhone.Text = this.DataGridView1.CurrentRow.Cells[5].Value.ToString();
            TextBoxAddress.Text = this.DataGridView1.CurrentRow.Cells[6].Value.ToString();

            //Picture
            byte[] pic;
            if (DataGridView1.CurrentRow.Cells[7].Value != DBNull.Value)
            {
                pic = (byte[])this.DataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }
           
        }
    }
}
