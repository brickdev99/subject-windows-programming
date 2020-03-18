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
