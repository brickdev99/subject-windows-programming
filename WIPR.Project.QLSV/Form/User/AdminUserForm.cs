using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class AdminUserForm : Form
    {
        public AdminUserForm()
        {
            InitializeComponent();
        }

        bool check_sys()
        {
            // Kiểm tra ID và User đã có trên hệ thống chưa
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand commmand = new SqlCommand("SELECT * FROM dbo.users WHERE uid = @Id OR username = @Username", db.GetConnection);
            commmand.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(textBoxIDUser.Text);
            commmand.Parameters.Add("@Username", SqlDbType.NChar).Value = textBoxUsername.Text.Trim();
            adapter.SelectCommand = commmand;
            adapter.Fill(table);
            if (table.Rows.Count > 0)// Đã có id hoặc user trên hệ thống
            {
                return true;
            }
            return false;
        }
        bool check_inf()
        {
            if (textBoxIDUser.Text.Trim() == ""
              || textBoxUsername.Text.Trim() == ""
              || textBoxPassword.Text.Trim() == ""
              || textBoxRePassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        int check_pass()
        {
            if (textBoxPassword.Text.Trim() != textBoxRePassword.Text.Trim())
            {
                return 1; // Password vs ConfirmPassword không khớp nhau
            }
            //     @"^[a-zA-Z0-9]{1,7}$"
            //     @"^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$"
            string pattern = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\S+$).{8,}$";// Biểu thức chính quy

            if (!Regex.IsMatch(textBoxPassword.Text, pattern))
            {
                return 2;// Mật khẩu chưa đủ mạnh
            }
            return 3;// Ok
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png,*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxUserImage.Image = Image.FromFile(opf.FileName);
                pictureBoxUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (check_sys())
            {
                MessageBox.Show("ID or username already on the system!", "Add User Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = new User();
            int id = Convert.ToInt32(textBoxIDUser.Text);
            string fname = textBoxFname.Text.Trim();
            string lname = textBoxLname.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmpassword = textBoxRePassword.Text;
            MemoryStream pic = new MemoryStream();
            
            if(pictureBoxUserImage.Image != null) pictureBoxUserImage.Image.Save(pic, pictureBoxUserImage.Image.RawFormat);
            if (check_inf())
            {
                if (check_pass() == 1)
                {
                    MessageBox.Show("Password and password confirmation do not match!!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (check_pass() == 2)
                {
                    MessageBox.Show("The password error message is too simple!!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (user.insertUser(id, fname, lname, username, password, pic))
                    {
                        MessageBox.Show("New User Added!!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error!!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void linkLabelBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
