using System;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using Web2020Project.libs;

namespace Web2020Project.Utils
{
    public class CheckObjExists
    {
        public static bool IsExist(string table, string primaryK, string value)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            StringBuilder str_builder;
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                str_builder = new StringBuilder("SELECT 1 FROM ");
                str_builder.Append(table).Append(" WHERE ");
                str_builder.Append(primaryK).Append("=@value");
                string sql = str_builder.ToString();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@value", value);
                reader = cmd.ExecuteReader();
                return reader.Read();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }
    }
}