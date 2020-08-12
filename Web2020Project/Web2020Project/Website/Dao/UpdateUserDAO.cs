using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class UpdateUserDAO
    {
        public static bool ChangePass(string usr_name, string pass)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                string sql = "UPDATE THANHVIEN SET MATKHAU=@pass WHERE TAIKHOAN=@usr";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@pass", MD5.ConvertToMD5(pass));
                cmd.Parameters.AddWithValue("@usr", usr_name);
                return cmd.ExecuteNonQuery() > 0;
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

        public static bool CheckCurrentPass(String current, String inputPass)
        {
            return current.Equals(MD5.ConvertToMD5(inputPass));
        }

        public bool AddUser(ThanhVien thanhVien)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                String sql =
                    "INSERT INTO THANHVIEN VALUES (@taikhoan,@matkhau,@ten,@gioitinh,@email,@sdt,@diachi,@level,@avatar)";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@taikhoan", thanhVien.TaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", MD5.ConvertToMD5(thanhVien.MatKhau));
                cmd.Parameters.AddWithValue("@ten", thanhVien.HoTen);
                cmd.Parameters.AddWithValue("@gioitinh", thanhVien.GioiTinh);
                cmd.Parameters.AddWithValue("@email", thanhVien.Email);
                cmd.Parameters.AddWithValue("@sdt", thanhVien.SoDienThoai);
                cmd.Parameters.AddWithValue("@diachi", thanhVien.DiaChi);
                cmd.Parameters.AddWithValue("@level", thanhVien.Level);
                cmd.Parameters.AddWithValue("@avatar", thanhVien.Avatar);
                return cmd.ExecuteNonQuery() > 0;
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

        public static bool UpdateUserInfor(ThanhVien thanhVien)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                string sql =
                    "UPDATE THANHVIEN SET HOTEN=@ten,GIOITINH=@gioitinh,EMAIL=@email,SODIENTHOAI=@sdt,DIACHI=@diachi WHERE TAIKHOAN=@taikhoan";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ten", thanhVien.HoTen);
                cmd.Parameters.AddWithValue("@gioitinh", thanhVien.GioiTinh);
                cmd.Parameters.AddWithValue("@email", thanhVien.Email);
                cmd.Parameters.AddWithValue("@sdt", thanhVien.SoDienThoai);
                cmd.Parameters.AddWithValue("@diachi", thanhVien.DiaChi);
                cmd.Parameters.AddWithValue("@taikhoan", thanhVien.TaiKhoan);

                return cmd.ExecuteNonQuery() > 0;
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