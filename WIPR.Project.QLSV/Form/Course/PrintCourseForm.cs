using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class PrintCourseForm : Form
    {
        public PrintCourseForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Import data from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintCourseForm_Load(object sender, EventArgs e)
        {
            Course course = new Course();
            dataGridView1.DataSource = course.getAllCourses();
        }

        /// <summary>
        /// Print data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = printDocument1;
            printDialog.AllowSomePages = true;
            printDialog.AllowSelection = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Doucument printer";
                printDocument1.Print();
            }
        }

        /// <summary>
        /// Button Save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSavetoFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            dialog.FileName = "ListCourse";
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

            builder.AppendLine(string.Join("", "ID\t\tNameCourse\t\tPeriod\t\tDecription".ToArray()));
            for (int i = 0; i < rowcount - 1; i++)
            {
                List<string> cols = new List<string>();
                for (int j = 0; j < columncount; j++)
                {
                    cols.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                builder.AppendLine(string.Join("\t\t", cols.ToArray()));
                //builder.AppendLine(string.Join("  ", "==================================".ToArray()));
            }
            System.IO.File.WriteAllText(dialog.FileName, builder.ToString());
            //MessageBox.Show(@"Text file was created.");
        }
    }
}
