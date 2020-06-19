using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace The_App_for_students.Class
{
    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; port=3306; " +
                                                         "username = root; password = root; database =authentificationdata");
        public void openConnect()
        {
            if (connection.State == System.Data.ConnectionState.Closed) { connection.Open(); }
        }
        public void closedConnect()
        {
            if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); }
        }
        public MySqlConnection GetConnection() { return connection; }
    }
}
 