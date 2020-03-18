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
    class Student
    {
        MY_DB dB = new MY_DB();

        //Function to insert a new student
        public bool insertStudent(int id, string firstname, string lastname, DateTime birthdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO student (id, firstname, lastname, birthdate, gender, phone, address, picture)"
                + " VALUES (@ID, @Fname, @Lname, @Bdate, @Gender, @Phone, @Address, @Picture)", dB.GetConnection);

            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = firstname;
            command.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = lastname;
            command.Parameters.Add("@Bdate", System.Data.SqlDbType.DateTime).Value = birthdate;
            command.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@Picture", System.Data.SqlDbType.Image).Value = picture.ToArray();

            dB.openConnection();

            if((command.ExecuteNonQuery() == 1))
            {
                dB.closeConnection();
                return true;
            }
            else
            {
                dB.closeConnection();
                return false;
            }
        }

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = dB.GetConnection;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool updateStudent(int id, string firstname, string lastname, DateTime birthdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE student SET firstname=@Fname, lastname=@Lname, birthdate=@Bdate, gender=@Gender, phone=@Phone, address=@Address, picture=@Picture WHERE  id=@ID",
                dB.GetConnection);

            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@Fname", System.Data.SqlDbType.VarChar).Value = firstname;
            command.Parameters.Add("@Lname", System.Data.SqlDbType.VarChar).Value = lastname;
            command.Parameters.Add("@Bdate", System.Data.SqlDbType.DateTime).Value = birthdate;
            command.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@Picture", System.Data.SqlDbType.Image).Value = picture.ToArray();

            dB.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                dB.closeConnection();
                return true;
            }
            else
            {
                dB.closeConnection();
                return false;
            }
        }
    }
}
