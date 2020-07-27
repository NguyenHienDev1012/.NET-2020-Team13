using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class SearchDAO
    {
        public static List<SanPham> Search(String input)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<SanPham> sanPhams = new List<SanPham>();
            try
            {
                string sql = "SELECT * FROM SANPHAM WHERE TRANGTHAI>0 AND TENSANPHAM LIKE " + "'%" + input +
                             "%' LIMIT 6";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sanPhams.Add(new SanPham().GetSanPham(reader));
                    }
                }

                return sanPhams.Count != 0 ? sanPhams : null;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }

        public static List<ChiTietSanPham> SearchKey(String key)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<ChiTietSanPham> chiTietSanPhams = new List<ChiTietSanPham>();
            try
            {
                string sql =
                    "SELECT * FROM SANPHAM AS SP JOIN CHITIETSANPHAM AS CT WHERE SP.MASANPHAM=CT.MASANPHAM AND TRANGTHAI>0 AND SP.TENSANPHAM LIKE " +
                    "'%" + key + "%'";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        chiTietSanPhams.Add(new ChiTietSanPham().GetChiTietSanPham(reader));
                    }
                }

                return chiTietSanPhams.Count != 0 ? chiTietSanPhams : null;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }
    }
}