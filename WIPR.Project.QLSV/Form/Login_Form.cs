using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            MY_DB dB = new MY_DB();

            string str_command;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            if (radioButtonStudent.Checked == true)
            {
                str_command = "SELECT * FROM login WHERE username = @User AND password = @Pass";
            }
            else
            {
                str_command = "SELECT * FROM users WHERE username = @User AND password = @Pass";
            }
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //MessageBox.Show("Ok, next time will be go to Main Menu of App");
                this.Hide();
                if (radioButtonStudent.Checked == true)
                {
                    Main_Form main = new Main_Form();
                    main.ShowDialog(this);
                }
                else
                {
                    HumanResourceForm human = new HumanResourceForm();
                    int userid = Convert.ToInt32(table.Rows[0][0].ToString());
                    Globals.setGlobalUserId(userid);
                    human.ShowDialog(this);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/user.png");
            pictureBox2.Image = Image.FromFile("../../images/pic_logoSPKT.png");
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            AdminUserForm form = new AdminUserForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
