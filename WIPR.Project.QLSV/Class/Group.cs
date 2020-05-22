using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    class Group
    {
        MY_DB dB = new MY_DB();
        bool check_command(SqlCommand command)
        {
            dB.openConnection();
            bool result = (command.ExecuteNonQuery() == 1);
            dB.closeConnection();
            return result;
        }
        public bool insertGroup(int id, string gname, int userid)
        {
            string str_command = "INSERT dbo.groups (id, name, userid) VALUES(@Id, @Name, @Userid)";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = gname;
            command.Parameters.Add("@Userid", SqlDbType.Int).Value = userid;
            return check_command(command);
        }
        public bool updateGroup(int id, string gname)
        {
            //string str_command = "UPDATE dbo.groups SET name = N'CD' WHERE id = 6";
            string str_command = "UPDATE dbo.groups SET name = @Name WHERE id = @Id";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = gname;
            return check_command(command);
        }
        public bool deleteGroup(int id)
        {
            string str_command = "DELETE FROM dbo.groups WHERE id = @Id";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            return check_command(command);
        }
        public DataTable getGroups(int userId)
        {
            string str_command = "SELECT * FROM dbo.groups WHERE userid = @Userid";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Userid", SqlDbType.Int).Value = userId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool groupExist(string name, string operater, int userid = 0, int groupid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if (operater == "add")
            {
                query = "SELECT * FROM dbo.groups WHERE name = @Name AND userid = @Userid";
            }
            else if (operater == "edit")
            {
                query = "SELECT * FROM dbo.groups WHERE name = @Name AND userid = @Userid AND id <> @Gid";
                command.Parameters.Add("@Gid", SqlDbType.Int).Value = groupid;
            }
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@Userid", SqlDbType.Int).Value = userid;
            command.Connection = dB.GetConnection;
            command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return (table.Rows.Count > 0);
        }
        public bool checkID(int idGroup)
        {
            string str_command = "SELECT * FROM dbo.groups WHERE id = @Idgroup";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Idgroup", SqlDbType.Int).Value = idGroup;
            command.Connection = dB.GetConnection;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return (table.Rows.Count > 0);
        }
    }
}
