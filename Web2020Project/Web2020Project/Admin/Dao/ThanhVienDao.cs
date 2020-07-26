using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.Dao;
using Web2020Project.libs;
using Web2020Project.Model;

namespace Web2020Project.Admin.Dao
{
    public class ThanhVienDao: ObjectDao
    {
        public bool add(object obj)
        {
            ThanhVien thanhVien = (ThanhVien) obj;
            MySqlCommand mySqlCommand = null;
            string sql;
            MySqlConnection conn= null;
            try
            {
                sql =
                    "insert into thanhvien(taikhoan, matkhau, hoten, gioitinh, email, sodienthoai, diachi, level, avatar) values (@taikhoan, @matkhau, @hoten, @gioitinh, @email, @sodienthoai, @diachi, @level, @avatar) ";
                conn = DBConnection.getDBConnection();
                conn.Open();
                mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.Parameters.AddWithValue("taikhoan", thanhVien.TaiKhoan);
                mySqlCommand.Parameters.AddWithValue("matkhau", thanhVien.MatKhau);
                mySqlCommand.Parameters.AddWithValue("hoten", thanhVien.HoTen);
                mySqlCommand.Parameters.AddWithValue("gioitinh", thanhVien.GioiTinh);
                mySqlCommand.Parameters.AddWithValue("email", thanhVien.Email);
                mySqlCommand.Parameters.AddWithValue("sodienthoai", thanhVien.SoDienThoai);
                mySqlCommand.Parameters.AddWithValue("diachi", thanhVien.DiaChi);
                mySqlCommand.Parameters.AddWithValue("level", thanhVien.Level);
                mySqlCommand.Parameters.AddWithValue("avatar", thanhVien.Avatar);

                mySqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                if(conn!=null) conn.Close();  
            }
            
            return false;
        }

        public bool remove(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool edit(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}