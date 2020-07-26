using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Models.MODEL;

namespace Web2020Project.Dao
{
    public class SanPhamDao
    {
        private static MySqlDataReader reader = null;

        public static List<SanPham> getListProduct()
        {
            List<SanPham> listProduct = new List<SanPham>();
            string sql =
                "select * from sanpham";
            MySqlConnection conn = DBConnection.getDBConnection();
            conn.Open();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(13132);
                    while (reader.Read())
                    {
                        int maSanPham = reader.GetInt32(0);
                        string tenSanPham = reader[1].ToString();
                        string nhaCungCap = reader[2].ToString();
                        double giaDaGiam = reader.GetDouble(3);
                        double giaBan = reader.GetDouble(4);
                        int soLuong = reader.GetInt32(5);
                        string hinhAnh = reader[6].ToString();
                        
                        
                        int trangTHai = reader.GetInt32(7);
                        int loai = reader.GetInt32(8);
                        SanPham sp = new SanPham(maSanPham, tenSanPham, nhaCungCap, giaDaGiam, giaBan, hinhAnh, soLuong,
                            trangTHai, loai);
                        listProduct.Add(sp);
                    }

                   
                }
                return listProduct;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
        }
    }
}