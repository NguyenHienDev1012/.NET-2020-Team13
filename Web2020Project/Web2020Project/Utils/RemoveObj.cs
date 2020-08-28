using System;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using Web2020Project.libs;

namespace Web2020Project.Utils
{
    public class RemoveObj
    {
        public static bool Remove(string table, string primaryK, string value, bool isInteger)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            StringBuilder str_builder;
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                str_builder = new StringBuilder("DELETE FROM ");
                str_builder.Append(table);
                str_builder.Append(" WHERE ");
                str_builder.Append(primaryK).Append("=@value");
                string sql = str_builder.ToString();
                cmd = new MySqlCommand(sql, connection);
                if (isInteger)
                {
                    cmd.Parameters.AddWithValue("@value", Convert.ToInt16(value));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@value", value);
                }

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                ReleaseResources.Release(connection, null, cmd);
            }
        }
    }
}