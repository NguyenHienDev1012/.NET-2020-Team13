using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Text;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class CategoryDAO
    {
        public static List<SanPham> findCateByType(int loai)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            List<SanPham> danhSachSanPham = new List<SanPham>();
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                string sql = "SELECT * FROM SANPHAM WHERE LOAISANPHAM=@loai_sp AND TRANGTHAI>0";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@loai_sp", loai);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        danhSachSanPham.Add(new SanPham().GetSanPham(reader));
                    }
                }

                return danhSachSanPham.Count != 0 ? danhSachSanPham : null;
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }

        public static List<SanPham> findCateByTypeAndPrice(int loai, double gia)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            List<SanPham> danhSachSanPham = new List<SanPham>();
            try
            {
                string sql = "SELECT * FROM SANPHAM WHERE LOAISANPHAM=@loai_sp AND TRANGTHAI>0 AND GIADAGIAM>@gia";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@loai_sp", loai);
                cmd.Parameters.AddWithValue("@gia", gia);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        danhSachSanPham.Add(new SanPham().GetSanPham(reader));
                    }
                }

                return danhSachSanPham.Count != 0 ? danhSachSanPham : null;
            }
            catch (SqlException e)
            {
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }

        public static MySqlDataReader findCateByTypeAndGift(int loai)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "SELECT sp.masanpham, sp.tensanpham, sp.giaban, sp.giadagiam, sp.hinhanh, ct.quatang FROM sanpham as sp JOIN chitietsanpham as ct on sp.masanpham=ct.masanpham WHERE sp.loaisanpham=@loai and sp.trangthai>0 ORDER BY sp.giadagiam DESC";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@loai", loai);
                reader = cmd.ExecuteReader();
                return reader;
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

        public static List<ChiTietSanPham> findCateByProducer(String id_producer, String sort, int page)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            List<ChiTietSanPham> ds_ctsp = new List<ChiTietSanPham>();
            String sql;
            StringBuilder str_builder = new StringBuilder(
                "SELECT * FROM SANPHAM AS SP JOIN CHITIETSANPHAM AS CT on SP.MASANPHAM=CT.MASANPHAM WHERE SP.TRANTHAI>0  AND SP.NHACUNGCAP=");
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                str_builder.Append("'").Append(id_producer).Append("'");
                if (sort != null)
                {
                    if (sort.Equals("desc"))
                    {
                        str_builder.Append(" ORDER BY SP.GIADAGIAM DESC ");
                    }
                    else if (sort.Equals("asc"))
                    {
                        str_builder.Append(" ORDER BY SP.GIADAGIAM ASC ");
                    }
                }

                str_builder.Append(" LIMIT @start,@end ");
                sql = str_builder.ToString();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@start", (page - 1) * 8);
                cmd.Parameters.AddWithValue("@end", 8);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ds_ctsp.Add(new ChiTietSanPham().GetChiTietSanPham(reader));
                    }
                }

                return ds_ctsp;
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

        public static ChiTietSanPham getDetailPrByID(int msp)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "SELECT * FROM SANPHAM AS SP JOIN CHITIETSANPHAM AS CT ON SP.MASANPHAM=CT.MASANPHAM WHERE SP.MASANPHAM=@msp";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@msp", msp);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return new ChiTietSanPham().GetChiTietSanPham(reader);
                    }
                }

                return null;
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

        public static int countOfCate(String nhacungcap)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "SELECT COUNT(*) AS SLUONG FROM SANPHAM WHERE NHACUNGCAP=@nhacungcap AND TRANGTHAI>0";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@nhacungcap", nhacungcap);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return reader.GetInt16("SLUONG");
                    }
                }

                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }
    }
}