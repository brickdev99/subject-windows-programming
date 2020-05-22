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
    public partial class SelectContactForm : Form
    {
        public SelectContactForm()
        {
            InitializeComponent();
        }

        private void dataGridViewSelectContact_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectContactForm_Load_1(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            SqlCommand command = new SqlCommand("SELECT  id[ID], firstname[First Name], lastname[Last Name],  group_id[Group Id] FROM  dbo.contact  WHERE  userid  = @uid");
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserId;
            dataGridViewSelectContact.DataSource = contact.selectContactList(command);
            dataGridViewSelectContact.ReadOnly = true;
        }

        private void dataGridViewSelectContact_DoubleClick_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
