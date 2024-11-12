using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Core
{
    public class DataBaseConnection : IDataAcess
    {
        protected MySqlConnection conn;
        private readonly string connectionString = "Server=localhost;Port=3306;Database=gestion_dette_csharp;User ID=root;Password=;";
        public void closeConnection()
        {
            if (conn != null && conn.State != System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

        public MySqlConnection getConnection()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
