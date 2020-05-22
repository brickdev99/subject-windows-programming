using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    class Score
    {
        MY_DB dB = new MY_DB();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable getScore(SqlCommand command)// Lấy danh sách sinh viên
        {
            command.Connection = dB.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// Insert score
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="courseID"></param>
        /// <param name="scoreValue"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool insertScore(int studentID, int courseID, float scoreValue, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO score (student_id, course_id, student_score, description) VALUES (@sid,@cid,@scr" +
                ",@descr)", dB.GetConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;

            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@scr", SqlDbType.Float).Value = scoreValue;
            command.Parameters.Add("@descr", SqlDbType.VarChar).Value = description;

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
        /// Delete score by StudentID & CourseID
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool deleteScore(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM score WHERE student_id = @sid AND course_id = @cid", dB.GetConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

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
        /// Check score in database, decrease error
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool studentScoreExist(int studentId, int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM score WHERE student_id = @sid AND course_id = @cid", dB.GetConnection);

            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentId;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Get information
        /// </summary>
        /// <returns></returns>
        public DataTable getStudentsScore()
        {
            SqlCommand command = new SqlCommand();

            command.Connection = dB.GetConnection;
            command.CommandText = ("SELECT score.student_id, student.firstname, student.lastname, score.course_id, course.label, score." +
            "student_score FROM student INNER JOIN score on student.id = score.student_id INNER JOIN course on score.course_id = course.Id");

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Cal, get avgScore
        /// </summary>
        /// <returns></returns>
        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();

            command.Connection = dB.GetConnection;

            command.CommandText = "SELECT course.label, AVG(score.student_score) As [Average Grade]  FROM  course, score WHERE course.Id =" +
             " score.course_id   GROUP BY course.label";
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Get, avgSocre by Course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public DataTable getCourseScores(int courseId)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = dB.GetConnection;
            command.CommandText = ("SELECT score.student_id, student.firstname, student.lastname, score.course_id, course.label, score." +
            "student_score FROM student INNER JOIN score on student.id = score.student_id INNER JOIN course on score.course_id = course.Id WHERE score.course_id = " + courseId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// get, avgScore by Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public DataTable getStudentScores(int studentId)
        {
            SqlCommand command = new SqlCommand();

            command.Connection = dB.GetConnection;
            command.CommandText = ("SELECT score.student_id, student.firstname, student.lastname, score.course_id, course.label, score." +
            "student_score FROM student INNER JOIN score on student.id = score.student_id INNER JOIN course on score.course_id = course.Id WHERE score.student_id = " + studentId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Check
        /// </summary>
        /// <param name="scoreID"></param>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public bool checkScore(int scoreID, int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM score WHERE student_id = @Student_id AND course_id = @Course_id", dB.GetConnection);
            command.Parameters.Add("@Student_id", SqlDbType.Int).Value = scoreID;
            command.Parameters.Add("@Course_id", SqlDbType.Int).Value = courseID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkScore(float score, int courseId = 0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score WHERE student_score = @sScore And student_id <> @SID", dB.GetConnection);
            command.Parameters.Add("@sScore", SqlDbType.VarChar).Value = score;
            command.Parameters.Add("@SID", SqlDbType.Int).Value = courseId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Get List Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getScoreById(int id)
        {
            string str_command = "SELECT * FROM score WHERE student_id = @Id";
            SqlCommand command = new SqlCommand(str_command);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Connection = dB.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
