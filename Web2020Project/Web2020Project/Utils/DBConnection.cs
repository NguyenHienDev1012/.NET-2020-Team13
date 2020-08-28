
using MySql.Data.MySqlClient;

namespace Web2020Project.libs

{
    public class DBConnection
    {
        public static MySqlConnection getConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "websellphone";
            string username = "root";
            string password = "1012";
            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn= new MySqlConnection(connString);
            return conn;
        }
    }
}