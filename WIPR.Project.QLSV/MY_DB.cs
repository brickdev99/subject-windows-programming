using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    class MY_DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=QLSVDB; Integrated Security = True;");

        //Get the connection
        public SqlConnection GetConnection
        {
            get { return this.connection; }
        }

        //Open the connection
        public void openConnection()
        {
            if ((this.connection.State == System.Data.ConnectionState.Closed)) { this.connection.Open(); }
        }

        //Closed the connection
        public void closeConnection()
        {
            if ((this.connection.State == System.Data.ConnectionState.Open)) { this.connection.Close(); }
        }
    }
}
