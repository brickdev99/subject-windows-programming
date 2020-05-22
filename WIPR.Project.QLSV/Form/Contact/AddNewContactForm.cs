using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIPR.Project.QLSV
{
    public partial class AddNewContactForm : Form
    {
        public AddNewContactForm()
        {
            InitializeComponent();
        }

        MY_DB mydb = new MY_DB();

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png,*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxContactImage.Image = Image.FromFile(opf.FileName);
                pictureBoxContactImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDContact.Text);
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxMail.Text;
            int userid = Globals.GlobalUserId;

            int groupid = (int)comboBoxGroupId.SelectedValue;
            MemoryStream pic = new MemoryStream();
            pictureBoxContactImage.Image.Save(pic, pictureBoxContactImage.Image.RawFormat);
            Contact contact = new Contact();
            if (!contact.checkID(id))
            {
                if (contact.insertContact(id, fname, lname, phone, address, email, userid, groupid, pic))
                {
                    //contact.insertContact(id, fname,lname,phone,address,email,userid,groupid,)
                    MessageBox.Show("New Contact Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxIDContact.Text = textBoxFname.Text = textBoxLname.Text = textBoxPhone.Text = textBoxAddress.Text = textBoxMail.Text = "";
                    comboBoxGroupId.SelectedItem = null;
                    pictureBoxContactImage.Image = null;
                }
                else
                {
                    MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This ID Already Exists, Try Another One", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddNewContactForm_Load(object sender, EventArgs e)
        {
            Group group = new Group();
            comboBoxGroupId.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxGroupId.DisplayMember = "name";
            comboBoxGroupId.ValueMember = "id";
        }

    }
}
