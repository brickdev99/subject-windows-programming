using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIPR.Project.QLSV.Login;

namespace WIPR.Project.QLSV
{
    public partial class HumanResourceForm : Form
    {
        public HumanResourceForm()
        {
            InitializeComponent();
        }

        MY_DB dB = new MY_DB();
        Contact contact = new Contact();
        Group group = new Group();

        private void HumanResourceForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
            loadDataComboBox();
        }

        void getImageAndUsername()
        {
            DataTable table = new DataTable();
            string str_command = "SELECT * FROM dbo.users WHERE uid = @ID";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = Globals.GlobalUserId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                if(table.Rows[0]["picture"] != DBNull.Value)
                {
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBoxUserImage.Image = Image.FromStream(picture);
                    pictureBoxUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                labelUserName.Text = "Welcome! (" + table.Rows[0]["username"].ToString().Trim() + ")" + "\n" + table.Rows[0]["firstname"].ToString().Trim() + " " + table.Rows[0]["lastname"].ToString().Trim();
            }
        }

        void loadDataComboBox()
        {
            loadDataComboBox1();
            loadDataComboBox2();
        }
        void loadDataComboBox1()
        {
            comboBoxGroupId1.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxGroupId1.DisplayMember = "name";
            comboBoxGroupId1.ValueMember = "id";
            comboBoxGroupId1.SelectedItem = null;
        }
        void loadDataComboBox2()
        {
            comboBoxGroupId2.DataSource = group.getGroups(Globals.GlobalUserId);
            comboBoxGroupId2.DisplayMember = "name";
            comboBoxGroupId2.ValueMember = "id";
            comboBoxGroupId2.SelectedItem = null;
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            AddNewContactForm form = new AddNewContactForm();
            form.ShowDialog();
        }

        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            EditContactForm form = new EditContactForm();
            form.ShowDialog();
        }

        private void buttonSeclectContact_Click(object sender, EventArgs e)
        {
            SelectContactForm form = new SelectContactForm();
            form.ShowDialog();

            try
            {
                textBoxContactID.Text = form.dataGridViewSelectContact.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonRemoveContact_Click(object sender, EventArgs e)
        {
            try
            {
                int Idcontact = Convert.ToInt32(textBoxContactID.Text.Trim());
                if ((MessageBox.Show("Are you sure you want to delete this Contact?", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (contact.deleteContact(Idcontact))
                    {
                        MessageBox.Show("Contact Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxContactID.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Contact Not Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid ID!", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string namegroup = textBoxGroupName1.Text.Trim();
                int userid = Globals.GlobalUserId;
                int groupid = Convert.ToInt32(textBoxIDGroup.Text.Trim());

                Group group = new Group();
                if (!group.checkID(groupid))
                {
                    if (group.insertGroup(groupid, namegroup, userid))
                    {
                        MessageBox.Show("New Group Added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataComboBox();
                        textBoxGroupName1.Text = textBoxIDGroup.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This ID Already Exists, Try Another One", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowFullContact_Click(object sender, EventArgs e)
        {
            ShowFullContactForm form = new ShowFullContactForm();
            form.ShowDialog();
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxGroupId1.SelectedValue) == 0)
            {
                MessageBox.Show("Please select the group!", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string namegroup = textBoxGroupName2.Text.Trim();
                int groupid = Convert.ToInt32(comboBoxGroupId1.SelectedValue);

                if (group.updateGroup(groupid, namegroup))
                {
                    MessageBox.Show("Group Information UpDated", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataComboBox();
                    textBoxGroupName2.Text = "";
                }
                else
                {
                    MessageBox.Show("Error", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int IdGroup = Convert.ToInt32(comboBoxGroupId2.SelectedValue);
                if ((MessageBox.Show("Are you sure you want to delete this Group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (group.deleteGroup(IdGroup))
                    {
                        MessageBox.Show("Group Deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Group Not Deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid ID!", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabelEditMyInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditAccountForm editAccount = new EditAccountForm();
            editAccount.ShowDialog();
            getImageAndUsername();
        }
    }
}
