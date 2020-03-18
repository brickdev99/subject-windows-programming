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
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.qLSVDBDataSet.student);

            SqlCommand command = new SqlCommand("SELECT * FROM student");
            DataGridView1.ReadOnly = true;

            //Xu ly hinh anh, tham khao MSDN.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();        //Doi tuong lam viec la Image cua DataGirdView
            DataGridView1.RowTemplate.Height = 80;      //Tham khao MSDN 10/03/2019, co gian Image dep. Dang tim Auto-Size 
            DataGridView1.DataSource = student.getStudents(command);

            imageColumn = (DataGridViewImageColumn)DataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
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

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteForm = new UpdateDeleteStudentForm();
            
            //Lay du lieu tu Student ID - FName - LName - BirthDate - Gender - Phone - Address - Picture
            updateDeleteForm.TextBoxID.Text = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteForm.TextBoxFisrtName.Text = this.DataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteForm.TextBoxLastName.Text = this.DataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeleteForm.dateTimePicker1.Value = (DateTime)this.DataGridView1.CurrentRow.Cells[3].Value;
            //Gender
            if((this.DataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")) { updateDeleteForm.RadioButtonFemale.Checked = true; }
            else { updateDeleteForm.RadioButtonMale.Checked = true; }
            updateDeleteForm.TextBoxPhone.Text = this.DataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleteForm.TextBoxAddress.Text = this.DataGridView1.CurrentRow.Cells[6].Value.ToString();

            //Picture
            byte[] pic;
            pic = (byte[])this.DataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteForm.pictureBox1.Image = Image.FromStream(picture);
            this.Show();

            updateDeleteForm.Show();
        }
    }
}
