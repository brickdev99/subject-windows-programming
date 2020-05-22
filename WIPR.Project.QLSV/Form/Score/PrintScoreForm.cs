using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class PrintScoreForm : Form
    {
        public PrintScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        string str_scores = "SELECT student_id[ID Student], firstname[First Name], " +
                                    "lastname[Last Name],course_id[Course ID],label[Name Cousre], student_score[Score] " +
                                    "FROM(dbo.score JOIN dbo.student ON id = student_id) JOIN dbo.course ON  " +
                                    "course.id = course_id; ";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            loadData(str_scores);
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_command"></param>
        void loadData(string str_command)
        {
            dataGridView1.DataSource = score.getScore(new SqlCommand(str_command));

            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSavetoFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            dialog.FileName = "ListScore";
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

            builder.AppendLine(string.Join("", "ID Student\t\tFirst Name\t\tLast Name\t\tCourse ID\tName Course\tScore".ToArray()));
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

        /// <summary>
        /// 
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
    }
}
