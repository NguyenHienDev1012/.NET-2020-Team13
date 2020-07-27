using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class CommentDAO
    {
        public static bool InsertCMT(BinhLuan binhLuan)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "INSERT INTO BINHLUAN(HOTEN,NOIDUNG,MASANPHAM,SANPHAM,NGAYBINHLUAN) VALUES (@ten,@noidung,@ma_sp,@sp,NOW())";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ten", binhLuan.HoTen);
                cmd.Parameters.AddWithValue("@noidung", binhLuan.NoiDung);
                cmd.Parameters.AddWithValue("@ma_sp", binhLuan.MaSanPham);
                cmd.Parameters.AddWithValue("@sp", binhLuan.SanPham);
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

        public static List<BinhLuan> LoadCMT(int masanpham)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<BinhLuan> binhLuans = new List<BinhLuan>();
            try
            {
                string sql = "SELECT HOTEN,SANPHAM,NOIDUNG,NGAYBINHLUAN FROM BINHLUAN WHERE MASANPHAM=@msp";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@msp", masanpham);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        binhLuans.Add(new BinhLuan().GetBinhLuan(reader));
                    }
                }

                return binhLuans.Count != 0 ? binhLuans : null;
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