using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    class Course
    {
        MY_DB dB = new MY_DB();

        /// <summary>
        /// Add new course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseName"></param>
        /// <param name="hoursNumber"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool insertCourse(int id, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO course (id, label, period, description) VALUES (@id,@label,@per,@desc)", dB.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@label", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@per", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@desc", SqlDbType.VarChar).Value = description;

            dB.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// update information Course
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="courseName"></param>
        /// <param name="hoursNumber"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool updateCourse(int courseID, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE course SET label=@label, period=@per, description=@desc WHERE id = @sid", dB.GetConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@label", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@per", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@desc", SqlDbType.VarChar).Value = description;

            dB.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete course in Database by courseID
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool deleteCourse(int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id = @sid", dB.GetConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = courseID;

            dB.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Search course by courseName
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool checkCourseName(string courseName, int courseId = 0)
        {

            // sid is parameter
            SqlCommand command = new SqlCommand("SELECT * FROM course WHERE label=@sName And id <> @sid", dB.GetConnection);

            command.Parameters.Add("@sName", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@sid", SqlDbType.Int).Value = courseId;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count > 0)) // If one row like name
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Get all Course from Database
        /// </summary>
        /// <returns></returns>
        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM course", dB.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public DataTable getAllCourses(SqlCommand command)// Lấy danh sách sinh viên
        {
            command.Connection = dB.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        /// <summary>
        /// Get one course by courseID
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public DataTable getCourseById(int courseID)
        {

            SqlCommand command = new SqlCommand("SELECT * FROM course WHERE id = @sid", dB.GetConnection);

            command.Parameters.Add("@sid", SqlDbType.VarChar).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Function excute query
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
        /// return total number course from Database
        /// </summary>
        /// <returns></returns>
        public string totalCourses()
        {
            return execCount("SELECT COUNT(*) FROM course");
        }

    }
}