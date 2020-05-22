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
    public partial class ShowFullContactForm : Form
    {
        public ShowFullContactForm()
        {
            InitializeComponent();
        }

        MY_DB dB = new MY_DB();
        Group group = new Group();
        Contact contact = new Contact();

        void loadDataListBox()
        {
            listBoxAllGroup.DataSource = group.getGroups(Globals.GlobalUserId);
            listBoxAllGroup.DisplayMember = "name";
            listBoxAllGroup.ValueMember = "id";
            listBoxAllGroup.SelectedItem = null;
        }
        public static bool IsOld(int value)
        {
            return value % 2 != 0;
        }
        void sortdataGirdView()
        {
            for (int i = 0; i < dataGridViewAllContact.Rows.Count; i++)
            {
                if (IsOld(i))
                {
                    dataGridViewAllContact.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }
        void loadDataGirdView(bool check)
        {
            try
            {
                int groupId = Convert.ToInt32(listBoxAllGroup.SelectedValue);
                SqlCommand command = new SqlCommand(contact.fullContactList(check), dB.GetConnection);
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = Globals.GlobalUserId;
                if (check == false)
                {
                    command.Parameters.Add("@GroupID", SqlDbType.Int).Value = groupId;
                }
                dataGridViewAllContact.DataSource = contact.selectContactList(command);
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                picCol = (DataGridViewImageColumn)dataGridViewAllContact.Columns[6];
                dataGridViewAllContact.RowTemplate.Height = 70;
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewAllContact.AllowUserToAddRows = false;

                sortdataGirdView();
            }
            catch (Exception)
            {

            }
            dataGridViewAllContact.ClearSelection();
        }


        private void ShowFullContactForm_Load(object sender, EventArgs e)
        {
            loadDataListBox();
            loadDataGirdView(true);
        }

        private void buttonShowFull_Click_1(object sender, EventArgs e)
        {
            loadDataGirdView(true);
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            loadDataGirdView(true);
        }

        private void listBoxAllGroup_Click_1(object sender, EventArgs e)
        {
            loadDataGirdView(false);
        }

        private void dataGridViewAllContact_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBoxFullAddress.Text = dataGridViewAllContact.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
