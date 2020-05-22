using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class StaticsResultForm : Form
    {
        public StaticsResultForm()
        {
            InitializeComponent();
        }

        MY_DB dB = new MY_DB();
        int count = 0;

        /// <summary>
        /// 
        /// </summary>
        private void clearList()
        {
            for (int i = 0; i < count; i++)
            {
                listBoxStaticCourse.Items.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaticsResultForm_Load(object sender, EventArgs e)
        {
            loadList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadList()
        {

            Score score = new Score();
            dB.openConnection();
            DataTable table = score.getAvgScoreByCourse();
            count = table.Rows.Count;

            clearList();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //Name Course] , AVG(score.student_score) AS [Average Grade]
                string temp = Math.Round(Convert.ToDouble(table.Rows[i]["Average Grade"].ToString()), 2).ToString();
                listBoxStaticCourse.Items.Add(table.Rows[i]["label"].ToString() + ":\n" + temp + "\n");

            }
            SqlCommand command = new SqlCommand("select * from result ", dB.GetConnection);
            DataTable table1 = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(command);
            adap.Fill(table1);

            int index = table1.Rows.Count;
            int numberFail = 0;

            for (int i = 0; i < index; i++)
            {
                if (table1.Rows[i]["Result"].ToString().Trim() == "Fail")
                {
                    numberFail++;
                }
            }

            float percentFail = (numberFail * 100) / index;
            float percentPass = 100 - percentFail;
            labelFail.Text = "Fail: " + percentFail + "%";
            labelPass.Text = "Pass: " + percentPass + "%";
        }
    }
}
