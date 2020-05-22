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

namespace WIPR.Project.QLSV.Login
{
    public partial class EditAccountForm : Form
    {
        public EditAccountForm()
        {
            InitializeComponent();
        }

        User user = new User();

        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            DataTable table = user.getUserById(Globals.GlobalUserId);
            if (table.Rows.Count > 0)
            {
                textBoxIDUser.Text = table.Rows[0]["uid"].ToString().Trim();
                textBoxFname.Text = table.Rows[0]["firstname"].ToString().Trim();
                textBoxLname.Text = table.Rows[0]["lastname"].ToString().Trim();
                textBoxUsername.Text = table.Rows[0]["username"].ToString().Trim();
                textBoxPassword.Text = table.Rows[0]["password"].ToString().Trim();
                textBoxRePassword.Text = table.Rows[0]["password"].ToString().Trim();

                if (table.Rows[0]["picture"] != DBNull.Value)
                {
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBoxUserImage.Image = Image.FromStream(picture);
                    pictureBoxUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!check_sys())
            {
                MessageBox.Show("ID or username already on the system!", "Update User Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pictureBoxUserImage.Image.Save(pic, pictureBoxUserImage.Image.RawFormat);
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
                    if (user.updateUser(id, fname, lname, username, password, pic))
                    {
                        MessageBox.Show("User Updated!!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error!!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
