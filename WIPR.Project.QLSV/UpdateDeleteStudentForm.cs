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

        }

        Student student = new Student();

        //Search theo Student ID, 
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.TextBoxID.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM student WHERE id = " + id);

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
