using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cameronDuckettClientSchedule.Database
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        //function to open connection
        public static void OpenConnection()
        {
            // connect to DB
            // get connection string
            string constr = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

            try
            {
                //assign conn to new MySqlConnection using constr for connection string
                conn = new MySqlConnection(constr);
                //Open Connection to database
                conn.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error connecting to database: " + ex.Message);
            }
        }

        //function to close connection
        public static void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error closing the database connection: " + ex.Message);
            }
        }
    }
}
