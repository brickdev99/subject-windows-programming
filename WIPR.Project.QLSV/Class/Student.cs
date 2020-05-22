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
    public class Student
    {
        MY_DB dB = new MY_DB();

        /// <summary>
        /// Function to insert a new student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="birthdate"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
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

            if ((command.ExecuteNonQuery() == 1)) { dB.closeConnection(); return true; }
            else { dB.closeConnection(); return false; }
        }

        /// <summary>
        /// Get student information from Database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = dB.GetConnection;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="birthdate"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        public bool updateStudent(int id, string firstname, string lastname, DateTime birthdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE student SET firstname=@Fname, lastname=@Lname, birthdate=@Bdate, gender=@Gender, phone=@Phone, address=@Address, picture=@Picture WHERE  id=@ID",
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

            if ((command.ExecuteNonQuery() == 1)) { dB.closeConnection(); return true; }
            else { dB.closeConnection(); return false; }
        }

        /// <summary>
        /// Delete one student in Database by (StudentID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM student WHERE id = @id", dB.GetConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            dB.openConnection();
             
            if((command.ExecuteNonQuery() == 1)) { dB.closeConnection();return true; }
            else { dB.closeConnection(); return false; }
        }

        /// <summary>
        /// Count student
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, dB.GetConnection);
            dB.openConnection();

            String count = command.ExecuteScalar().ToString();
            dB.closeConnection();

            return count;
        }

        /// <summary>
        /// Count all student from database
        /// </summary>
        /// <returns></returns>
        public string totalStudent()
        {
            return execCount("SELECT COUNT(*) FROM student");
        }

        /// <summary>
        /// Count all male from database
        /// </summary>
        /// <returns></returns>
        public string totalMaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM student WHERE gender = 'Male' ");
        }

        /// <summary>
        /// Count all female from database
        /// </summary>
        /// <returns></returns>
        public string totalFemaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM student WHERE gender = 'Female'");
        }
    }
}
    