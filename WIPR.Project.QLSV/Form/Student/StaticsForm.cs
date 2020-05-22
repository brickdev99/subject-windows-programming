using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class StaticsForm : Form
    {
        public StaticsForm()
        {
            InitializeComponent();
        }

        Color panTotalColor;
        Color panMaleColor;
        Color panFemaleColor;
        /// <summary>
        /// Process for statics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaticsForm_Load(object sender, EventArgs e)
        {
            //  Get panels color
            panTotalColor = panelTotal.BackColor;
            panMaleColor = panelMale.BackColor;
            panFemaleColor = panelFemale.BackColor;

            //  Display the values
            Student Student = new Student();
            double total = Convert.ToDouble(Student.totalStudent());
            double totalMale = Convert.ToDouble(Student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(Student.totalFemaleStudent());

            //  (Total Students X 100) / (total Students)            
            double maleStudentsPercentage = (totalMale * (100 / total));
            double femaleStudentsPercentage = (totalFemale * (100 / total));
            labelTotal.Text = ("Total Students: " + total.ToString());
            labelMale.Text = ("Male : " + (maleStudentsPercentage.ToString("0.00") + "%"));
            labelFemale.Text = ("Female : " + (femaleStudentsPercentage.ToString("0.00") + "%"));
        }

        /// <summary>
        /// Work with mouse(animation while move the mouse)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Label Total
        private void labelTotal_MouseEnter(object sender, EventArgs e)
        {
            labelTotal.ForeColor = panTotalColor;
            panelTotal.BackColor = Color.White;
        }

        private void labelTotal_MouseLeave(object sender, EventArgs e)
        {
            labelTotal.ForeColor = Color.White;
            panelTotal.BackColor = panTotalColor;
        }

        // Label Male
        private void labelMale_MouseEnter(object sender, EventArgs e)
        {
            labelMale.ForeColor = panMaleColor;
            panelMale.BackColor = Color.White;
        }

        private void labelMale_MouseLeave(object sender, EventArgs e)
        {
            labelMale.ForeColor = Color.White;
            panelMale.BackColor = panMaleColor;
        }

        // Label Female
        private void labelFemale_MouseEnter(object sender, EventArgs e)
        {
            labelFemale.ForeColor = panFemaleColor;
            panelFemale.BackColor = Color.White;
        }

        private void labelFemale_MouseLeave(object sender, EventArgs e)
        {
            labelFemale.ForeColor = Color.White;
            panelFemale.BackColor = panFemaleColor;
        }

    }
}
