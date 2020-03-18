using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Form1 login = new Form1();
            if((login.ShowDialog() == DialogResult.OK)) { Application.Run(new Main_Form()); }
            else { Application.Exit(); }
        }
    }
}
