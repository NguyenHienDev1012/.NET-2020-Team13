using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Dao
{
    public class LoginDao
    {
        public static Member checkLogin(string userName, string password)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            string sql = "SELECT * FROM THANHVIEN WHERE TAIKHOAN= @taikhoan AND MATKHAU= @matkhau";
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@taikhoan", userName);
                cmd.Parameters.AddWithValue("@matkhau", MD5.ConvertToMD5(password));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return new Member().GetMember(reader);
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }
    }
}