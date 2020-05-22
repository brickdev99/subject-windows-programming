using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    class Contact
    {
        MY_DB dB = new MY_DB();
        bool check_command(SqlCommand command)
        {
            dB.openConnection();

            if ((command.ExecuteNonQuery() == 1)) { dB.closeConnection(); return true; }
            else { dB.closeConnection(); return false; }
        }
        public bool insertContact(int id, string firstname, string lastname, string phone, string address, string email, int userid, int groupid, MemoryStream picture)
        {
            string str_command = "INSERT INTO dbo.contact(id, firstname, lastname, group_id, phone, email, address, picture, userid) VALUES(@Id, @firstname, @lastname, @Groupid, @Phone, @Email, @Addr, @Pic, @Userid)";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
            command.Parameters.Add("@Groupid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@Phone", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@Addr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@Userid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@Pic", SqlDbType.Image).Value = picture.ToArray();
            return check_command(command);
        }
        public bool updateContact(int contactid, string firstname, string lastname, string phone, string address, string mail, int groupid, MemoryStream picture)
        {
            string str_command = "UPDATE dbo.contact SET " +
                "firstname = @firstname, lastname = @lastname, group_id = @Groupid, phone = @Phone, email = @Mail, address = @Addr, picture = @Pic " +
                "WHERE id = @Idcontact";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Idcontact", SqlDbType.Int).Value = contactid;
            command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
            command.Parameters.Add("@Groupid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@Phone", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@Mail", SqlDbType.NChar).Value = mail;
            command.Parameters.Add("@Addr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@Pic", SqlDbType.Image).Value = picture.ToArray();
            return check_command(command);
        }
        public bool deleteContact(int contactid)
        {
            string str_command = "DELETE FROM dbo.contact WHERE id = @Id";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = contactid;
            return check_command(command);
        }
        //Load dữ liệu
        public DataTable selectContactList(SqlCommand command)
        {
            command.Connection = dB.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string fullContactList(bool check)
        {
            string str_command = "SELECT firstname[First Name], lastname[Last Name], dbo.groups.name[Group Name], phone[Phone], email[Mail], address[Address], picture[Picture] FROM dbo.contact INNER JOIN dbo.groups ON groups.id = dbo.contact.group_id WHERE contact.userid = @UserID ";
            if (check == false)
            {
                str_command += "AND dbo.contact.group_id = @GroupID";
            }
            return str_command;

        }
        public DataTable getContactById(int contactid)
        {
            string str_command = "SELECT * FROM dbo.contact WHERE id = @ContactId";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool checkID(int idContact)
        {
            string str_command = "SELECT * FROM dbo.contact WHERE id = @Idcontact";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Idcontact", SqlDbType.Int).Value = idContact;
            command.Connection = dB.GetConnection;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return (table.Rows.Count > 0);
        }
    }
}
