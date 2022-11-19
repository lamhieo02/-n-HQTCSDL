using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCenter.DAL
{
    class DataAccess
    {
        // Dừng debug: Shift + F5
        private static SqlConnection conn = null;
        public static SqlConnection getConnection()
        {
            if (conn == null)
            {
                string connectionString = @"Data Source=LAPTOP-AU2P2PHD;Initial Catalog=LanguageCenter_DEMO2;Integrated Security=True;MultipleActiveResultSets=True;";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            return conn;
        }
    }
}
