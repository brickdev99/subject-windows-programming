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
    public partial class EditContactForm : Form
    {
        public EditContactForm()
        {
            InitializeComponent();
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

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            Group group = new Group();
            comboBoxGroupId.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxGroupId.DisplayMember = "name";
            comboBoxGroupId.ValueMember = "id";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxMail.Text;
            try
            {
                int id = Convert.ToInt32(textBoxIDContact.Text);

                int groupid = (int)comboBoxGroupId.SelectedValue;

                MemoryStream pic = new MemoryStream();
                pictureBoxContactImage.Image.Save(pic, pictureBoxContactImage.Image.RawFormat);

                if (contact.updateContact(id, fname, lname, phone, address, email, groupid, pic))
                {
                    MessageBox.Show("Contact Inormation UpDated", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSelectIDContact_Click_1(object sender, EventArgs e)
        {
            SelectContactForm SelectContactF = new SelectContactForm();
            SelectContactF.ShowDialog();
            try
            {
                int contactId = Convert.ToInt32(SelectContactF.dataGridViewSelectContact.CurrentRow.Cells[0].Value.ToString());

                Contact contact = new Contact();
                DataTable table = contact.getContactById(contactId);

                textBoxIDContact.Text = table.Rows[0]["id"].ToString();
                textBoxFname.Text = table.Rows[0]["firstname"].ToString();
                textBoxLname.Text = table.Rows[0]["lastname"].ToString();
                comboBoxGroupId.SelectedValue = table.Rows[0]["group_id"];
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxMail.Text = table.Rows[0]["email"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxContactImage.Image = Image.FromStream(picture);
                pictureBoxContactImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {

            }
        }
    }
}
