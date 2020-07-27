using MySql.Data.MySqlClient;

namespace Web2020Project.Utils
{
    public class ReleaseResources
    {
        public static void Release(MySqlConnection connection, MySqlDataReader reader, MySqlCommand cmd)
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }

            if (cmd != null)
            {
                cmd.Dispose();
            }

            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }
    }
}