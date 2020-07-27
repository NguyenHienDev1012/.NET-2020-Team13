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
        private static MySqlDataReader reader = null;
  

        public static ThanhVien checkLogin(string taikhoan, string matkhau)
        {
            string sql = "select * from thanhvien where taikhoan= @taikhoan and matkhau= @matkhau";
            MySqlConnection conn = DBConnection.getConnection();
            conn.Open();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.Parameters.AddWithValue("taikhoan", taikhoan);
                mySqlCommand.Parameters.AddWithValue("matkhau", MD5.ConvertToMD5(matkhau));
                
                reader = mySqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string taiKhoan = reader[0].ToString();
                            string matKhau = reader[1].ToString();
                            string hoTen = reader[2].ToString();
                            string gioiTinh = reader[3].ToString();
                            string email = reader[4].ToString();
                            int soDienThoai = reader.GetInt32(5);
                            string diaChi = reader[6].ToString();
                            int level = Convert.ToInt32(reader.GetDecimal(7));
                            string avatar = reader[8].ToString();
                            ThanhVien thanhvien = new ThanhVien(taikhoan, matkhau, hoTen, gioiTinh, email, "",
                                                   diaChi, level, avatar);
                            return thanhvien;
                        }
                    }
                    else
                    {
                        return null;
                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                if(reader!=null) reader.Close();
                if(conn != null) conn.Close();
            }

            return null;
        }
    }
    }