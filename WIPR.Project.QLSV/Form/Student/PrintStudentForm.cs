using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class PrintStudentForm : Form
    {
        public PrintStudentForm()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// get data from Database to DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintStudentForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student ");
            fillGrid(command);

            // Check no use Date Range
            if(radioButtonNo.Checked)
            {
                dateTimePickerBegin.Enabled = false;
                dateTimePickerEnd.Enabled = false;
            }
        }

        /// <summary>
        /// Copy from the StudentListFrom, import data to DataGridView
        /// </summary>
        /// <param name="command"></param>
        public void fillGrid(SqlCommand command)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet.student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.qLSVDBDataSet.student);

            dataGridView1.ReadOnly = true;

            //Xu ly hinh anh, tham khao MSDN.
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();        //Doi tuong lam viec la Image cua DataGirdView
            dataGridView1.RowTemplate.Height = 80;      //Tham khao MSDN 10/03/2019, co gian Image dep. Dang tim Auto-Size 
            dataGridView1.DataSource = student.getStudents(command);

            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// While change, use Date Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerBegin.Enabled = true;
            dateTimePickerEnd.Enabled = true;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerBegin.Enabled = false;
            dateTimePickerEnd.Enabled = false;
        }

        /// <summary>
        /// Process button Check by use Date Range or  not use Date Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            String query;
            
            if (radioButtonYes.Checked)
            {
                string date1 = dateTimePickerBegin.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickerEnd.Value.ToString("yyyy-MM-dd");

                if (radioButtonMale.Checked)
                {
                    query = "SELECT * FROM student WHERE gender = 'Male' AND birthdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "SELECT * FROM student WHERE gender = 'Female' AND birthdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }
                else
                {
                    query = "SELECT * FROM student WHERE birthdate BETWEEN '" + date1 + " 'AND' " + date2 + "'";
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }
            else // if not use Range Date
            {
                if (radioButtonMale.Checked)
                {
                    query = "SELECT * FROM student WHERE gender = 'Male'";
                }
                else if (radioButtonFemale.Checked)
                {
                    query = "SELECT * FROM student WHERE gender = 'Female'";
                }
                else // All
                {
                    query = "SELECT * FROM student"; 
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }

        }

        /// <summary>
        /// Save information student on disk with TXT file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            dialog.FileName = "ListStudent";
            //if (TextBoxSearch.Text != "")
            //{
            //    dialog.FileName += "_Find+" + TextBoxSearch.Text.Trim();
            //}
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            StringBuilder builder = new StringBuilder();
            int rowcount = dataGridView1.Rows.Count;
            int columncount = dataGridView1.Columns.Count;
            builder.AppendLine(string.Join("", "ID\t\tFirstName\t\tLastNameBirthDate\t\tGender\t\tPhone\t\t\tAddress".ToArray()));
            for (int i = 0; i < rowcount; i++)
            {
                List<string> cols = new List<string>();
                for (int j = 0; j < columncount - 1; j++)
                {
                    cols.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                builder.AppendLine(string.Join("\t", cols.ToArray()));
                //builder.AppendLine(string.Join("  ", "==================================".ToArray()));
            }
            System.IO.File.WriteAllText(dialog.FileName, builder.ToString());
            //MessageBox.Show(@"Text file was created.");

        }

        /// <summary>
        /// Print information student with Printer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.AllowSomePages = true;
            printDialog.AllowSelection = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Document printer";
                printDocument1.Print();
            }
        }

       
    }
}
