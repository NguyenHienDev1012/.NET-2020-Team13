using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Website.Model;

namespace Web2020Project.Website.Dao
{
    public class CartDAO
    {
        public bool InsertCart(GioHang gioHang)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            String sql = "INSERT INTO GIOHANG VALUES (@mgh,@hoten,@email,@sdt,@diachi,NOW())";
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                String mgh = gioHang.ThanhVien.TaiKhoan + "" + (new Random().Next(99999));
                cmd.Parameters.AddWithValue("@mgh", mgh);
                cmd.Parameters.AddWithValue("@hoten", gioHang.ThanhVien.HoTen);
                cmd.Parameters.AddWithValue("@email", gioHang.ThanhVien.Email);
                cmd.Parameters.AddWithValue("@sdt", gioHang.ThanhVien.SoDienThoai);
                cmd.Parameters.AddWithValue("@diachi", gioHang.ThanhVien.DiaChi);
                int row = cmd.ExecuteNonQuery();
                if (row < 0) return false;
                sql =
                    "INSERT INTO CHITIETDONHANG(MAGIOHANG,TENSANPHAM,SOTIEN,TRANGTHAI,SOLUONG,HINHANH) VALUES (@mgh,@tensp,@sotien,@trangthai,@soluong,@hinhanh)";
                cmd = new MySqlCommand(sql, connection);
                foreach (Item item in gioHang.Item)
                {
                    cmd.Parameters.AddWithValue("@mgh", mgh);
                    cmd.Parameters.AddWithValue("@tensp", item.SanPham.TenSanPham);
                    cmd.Parameters.AddWithValue("@sotien", (item.SoLuong * item.Gia));
                    cmd.Parameters.AddWithValue("@trangthai", gioHang.Trangthai);
                    cmd.Parameters.AddWithValue("@soluong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@hinhanh", item.SanPham.HinhAnh);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
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
            }
        }
    }
}