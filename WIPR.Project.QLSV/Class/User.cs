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
    class User
    {
        MY_DB dB = new MY_DB();

        bool check_command(SqlCommand command)
        {
            dB.openConnection();
            bool result = (command.ExecuteNonQuery() == 1);
            dB.closeConnection();
            return result;
        }
        public DataTable getUserById(int userId)
        {
            string str_command = "SELECT * FROM dbo.users WHERE uid = @Uid";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Uid", SqlDbType.Int).Value = userId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertUser(int uid, string fname, string lname, string username, string password, MemoryStream picture)// type = true ==> Stundent
        {
            string str_command;
            str_command = "INSERT INTO dbo.users (uid, firstname, lastname, username, password, picture) VALUES(@Uid, @Fname, @Lname, @username, @password, @picture)";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Uid", SqlDbType.Int).Value = uid;
            command.Parameters.Add("@Fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@Lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@username", SqlDbType.NChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.NChar).Value = password;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
            return check_command(command);
        }
        public bool updateUser(int uid, string fname, string lname, string username, string password, MemoryStream picture)
        {
            string str_command = "UPDATE dbo.users SET firstname = @Fname, lastname = @Lname, username = @username, password = @password, picture = @picture WHERE uid = @Uid";
            SqlCommand command = new SqlCommand(str_command, dB.GetConnection);
            command.Parameters.Add("@Uid", SqlDbType.Int).Value = uid;
            command.Parameters.Add("@Fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@Lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@username", SqlDbType.NChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.NChar).Value = password;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
            return check_command(command);
        }
        /// <summary>
        /// Kiểm tra tồn tại
        /// </summary>
        /// <param name="username"></param>
        /// <param name="operation"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool usernameExist(string username, string operation, int userid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if (operation == "register")
            {
                query = "SELECT * FROM dbo.users WHERE username = @username";
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM dbo.users WHERE username = @username AND id <> @Uid";
                command.Parameters.Add("@Uid", SqlDbType.Int).Value = userid;
            }
            command.CommandText = query;
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Connection = dB.GetConnection;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return (table.Rows.Count > 0);
        }
    }
}
