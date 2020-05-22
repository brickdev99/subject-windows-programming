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
using Word = Microsoft.Office.Interop.Word;

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
            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "Text File|*.txt";
            //dialog.FileName = "ListStudent";
            ////if (TextBoxSearch.Text != "")
            ////{
            ////    dialog.FileName += "_Find+" + TextBoxSearch.Text.Trim();
            ////}
            //var result = dialog.ShowDialog();
            //if (result != DialogResult.OK)
            //    return;
            //StringBuilder builder = new StringBuilder();
            //int rowcount = dataGridView1.Rows.Count;
            //int columncount = dataGridView1.Columns.Count;
            //builder.AppendLine(string.Join("", "ID\t\tFirstName\t\tLastNameBirthDate\t\tGender\t\tPhone\t\t\tAddress".ToArray()));
            //for (int i = 0; i < rowcount; i++)
            //{
            //    List<string> cols = new List<string>();
            //    for (int j = 0; j < columncount - 1; j++)
            //    {
            //        cols.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
            //    }
            //    builder.AppendLine(string.Join("\t", cols.ToArray()));
            //    //builder.AppendLine(string.Join("  ", "==================================".ToArray()));
            //}
            //System.IO.File.WriteAllText(dialog.FileName, builder.ToString());
            ////MessageBox.Show(@"Text file was created.");
           
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "ListStudent.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }

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

        /// <summary>
        /// Using https://stackoverflow.com/questions/29729413/export-datagridview-to-word-document-c-sharp
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="filename"></param>
        public void Export_Data_To_Word(DataGridView DGV, string filename)
    {
        if (DGV.Rows.Count != 0)
        {
            int RowCount = DGV.Rows.Count;
            int ColumnCount = DGV.Columns.Count;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

            //add rows
            int r = 0;
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                for (r = 0; r <= RowCount - 1; r++)
                {
                    DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                } //end row loop
            } //end column loop

            Word.Document oDoc = new Word.Document();
            oDoc.Application.Visible = true;

            //page orintation
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


            dynamic oRange = oDoc.Content.Application.Selection.Range;
            string oTemp = "";
            for (r = 0; r <= RowCount - 1; r++)
            {
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oTemp = oTemp + DataArray[r, c] + "\t";
                }
            }

            //table format
            oRange.Text = oTemp;

            object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            object ApplyBorders = true;
            object AutoFit = true;
            object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

            oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                  Type.Missing, Type.Missing, ref ApplyBorders,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

            oRange.Select();

            oDoc.Application.Selection.Tables[1].Select();
            oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.InsertRowsAbove(1);
            oDoc.Application.Selection.Tables[1].Rows[1].Select();

            //header row style
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

            //add header row manually
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
            }

            //table style 
            oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //header text
            foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                headerRange.Text = "your header text";
                headerRange.Font.Size = 16;
                headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

            //save the file
            oDoc.SaveAs2(filename);

            //NASSIM LOUCHANI
        }
    }

    }
}
