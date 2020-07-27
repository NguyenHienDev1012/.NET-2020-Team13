using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class ProductDAO
    {
        public static SanPham getProductID(int msp)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                String sql =
                    "SELECT MASANPHAM,TENSANPHAM,GIADAGIAM,HINHDANH FROM SANPHAM WHERE TRANGTHAI>0 AND MASANPHAM=@msp";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@msp", msp);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        SanPham sanPham = new SanPham();
                        sanPham.MaSanPham = reader.GetInt16("masanpham");
                        sanPham.TenSanPham = reader.GetString("tensanpham");
                        sanPham.GiaDaGiam = reader.GetDouble("giadagiam");
                        sanPham.HinhAnh = reader.GetString("hinhanh");
                        return sanPham;
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
    }
}