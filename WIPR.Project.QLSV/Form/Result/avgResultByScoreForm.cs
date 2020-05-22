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
    public partial class avgResultByScoreForm : Form
    {
        public avgResultByScoreForm()
        {
            InitializeComponent();
        }

        MY_DB dB = new MY_DB();
        Bitmap bmp;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewResult_DoubleClick(object sender, EventArgs e)
        {
            TextBoxID.Text = dataGridViewResult.CurrentRow.Cells[0].Value.ToString();
            TextBoxFname.Text = dataGridViewResult.CurrentRow.Cells[1].Value.ToString();
            TextBoxLname.Text = dataGridViewResult.CurrentRow.Cells[2].Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindInfor_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Result where CONCAT(Student_ID,firstname) LIKE'%" + textBoxSearch.Text + "%'", dB.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewResult.DataSource = table;
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        /// <summary>
        /// Load dataGirdView from table Student, Course, Score
        /// </summary>
        private void loadDataGirdView()
        {
            try
            {
                SqlCommand clearrecord = new SqlCommand("Delete from result", dB.GetConnection);
                dB.openConnection();
                clearrecord.ExecuteNonQuery();

                Score score = new Score();
                SqlCommand command = new SqlCommand("Select * From course order by label", dB.GetConnection);
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    SqlCommand deleteCol = new SqlCommand("Alter Table result drop column if exists" + "[" + table.Rows[i]["label"].ToString() + "]", dB.GetConnection);
                    deleteCol.ExecuteNonQuery();
                    SqlCommand command1 = new SqlCommand("ALTER TABLE result add " + "[" + table.Rows[i]["label"].ToString() + "]" + " float", dB.GetConnection);
                    command1.ExecuteNonQuery();
                }

                SqlCommand deleteCol1 = new SqlCommand("alter table result drop column if exists" + "[Average Score]", dB.GetConnection);
                deleteCol1.ExecuteNonQuery();
                SqlCommand deleteCol2 = new SqlCommand("alter table result drop column if exists" + "[Result]", dB.GetConnection);
                deleteCol2.ExecuteNonQuery();
                SqlCommand addAvg = new SqlCommand("Alter table result Add [Average Score] float", dB.GetConnection);
                addAvg.ExecuteNonQuery();
                SqlCommand addRe = new SqlCommand("Alter table result Add [Result] nvarchar(50)", dB.GetConnection);
                addRe.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("Select * from student", dB.GetConnection);
                DataTable table1 = new DataTable();

                table1.Load(query.ExecuteReader());
                foreach (DataRow row in table1.Rows)
                {
                    int id = Int32.Parse(row["id"].ToString());
                    DataTable diem = score.getScoreById(id);

                    float totalScore = 0, avgScore;
                    SqlCommand command3 = new SqlCommand("INSERT into result(Student_ID,firstname,lastname) VALUES(@id,@fn,@ln)", dB.GetConnection);
                    command3.Parameters.Add("@id", SqlDbType.NChar).Value = row["id"].ToString();
                    command3.Parameters.Add("@fn", SqlDbType.NChar).Value = row["firstname"].ToString();
                    command3.Parameters.Add("@ln", SqlDbType.NChar).Value = row["lastname"].ToString();
                    command3.ExecuteNonQuery();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        SqlCommand command2 = new SqlCommand("Update result Set " + "[" + table.Rows[i]["label"].ToString() + "]" + " = @value where Student_ID = " + row["id"].ToString(), dB.GetConnection);
                        float temp = float.Parse(diem.Rows[i]["student_score"].ToString());

                        command2.Parameters.Add("@value", SqlDbType.Float).Value = temp;

                        command2.ExecuteNonQuery();
                        totalScore += float.Parse(diem.Rows[i]["student_score"].ToString());
                    }

                    avgScore = totalScore / table.Rows.Count;
                    SqlCommand insertAvg = new SqlCommand("Update result set [Average Score] = " + avgScore + "where Student_ID = " + row["id"].ToString(), dB.GetConnection);
                    insertAvg.ExecuteNonQuery();
                    if (avgScore >= 5)
                    {
                        SqlCommand insertRe = new SqlCommand("Update result set [Result] = N'Pass'" + "where Student_ID = " + row["id"].ToString(), dB.GetConnection);
                        insertRe.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand insertRe = new SqlCommand("Update result set [Result] = N'Fail'" + "where Student_ID = " + row["id"].ToString(), dB.GetConnection);
                        insertRe.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dB.closeConnection();


            SqlCommand command4 = new SqlCommand("Select * from result", dB.GetConnection);
            DataTable table4 = new DataTable();
            dB.openConnection();
            table4.Load(command4.ExecuteReader());
            dataGridViewResult.DataSource = table4;
            for (int i = 3; i < dataGridViewResult.Columns.Count; i++)
            {
                dataGridViewResult.Columns[i].DefaultCellStyle.Format = "N2";
            }
            dB.closeConnection();
        }

        private void avgResultByScoreForm_Load(object sender, EventArgs e)
        {
            loadDataGirdView();
        }
    }
}
