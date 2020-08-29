using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class MemberDAO
    {
        //User
        public static bool ChangePass(string userName, string password)
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
                cmd.Parameters.AddWithValue("@pass", MD5.ConvertToMD5(password));
                cmd.Parameters.AddWithValue("@usr", userName);
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

//Admin, User
        public static bool AddMember(Member member)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                String sql =
                    "INSERT INTO THANHVIEN VALUES (@taikhoan,@matkhau,@ten,@gioitinh,@email,@phone,@diachi,@level,@avatar)";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@taikhoan", member.UserName);
                cmd.Parameters.AddWithValue("@matkhau", MD5.ConvertToMD5(member.Password));
                cmd.Parameters.AddWithValue("@ten", member.Name);
                cmd.Parameters.AddWithValue("@gioitinh", member.Gender);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@phone", member.Phone);
                cmd.Parameters.AddWithValue("@diachi", member.Address);
                cmd.Parameters.AddWithValue("@level", member.Level);
                cmd.Parameters.AddWithValue("@avatar", member.Avatar);
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

//Admin, User
        public static bool EditMember(Member member)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                string sql =
                    "UPDATE THANHVIEN SET HOTEN=@ten,GIOITINH=@gioitinh,EMAIL=@email,SODIENTHOAI=@phone,DIACHI=@diachi,LEVEL=@level WHERE TAIKHOAN=@taikhoan";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ten", member.Name);
                cmd.Parameters.AddWithValue("@gioitinh", member.Gender);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@phone", member.Phone);
                cmd.Parameters.AddWithValue("@diachi", member.Address);
                cmd.Parameters.AddWithValue("@level", member.Level);
                cmd.Parameters.AddWithValue("@taikhoan", member.UserName);

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

        //Admin
        public static List<Member> LoadMember()
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            List<Member> members = new List<Member>();
            try
            {
                string sql = "SELECT TAIKHOAN,HOTEN,GIOITINH,EMAIL,SODIENTHOAI,DIACHI,LEVEL FROM THANHVIEN";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string userName = reader.GetString("taikhoan");
                        string name = reader.GetString("hoten");
                        string gender = reader.GetString("gioitinh");
                        string email = reader.GetString("email");
                        string phone = reader.GetString("sodienthoai");
                        string address = reader.GetString("diachi");
                        int level = reader.GetInt16("level");
                        members.Add(new Member(userName, name, gender, email, phone, address, level));
                    }
                }

                return members.Count != 0 ? members : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }

        public static Member GetMember(string usrName)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "SELECT HOTEN,GIOITINH,EMAIL,SODIENTHOAI,DIACHI,LEVEL FROM THANHVIEN WHERE TAIKHOAN=@usrName";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@usrName", usrName);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader.Read()) return null; //Chi duoc ton tai 1 tai khoan
                        string name = reader.GetString("hoten");
                        string gender = reader.GetString("gioitinh");
                        string email = reader.GetString("email");
                        string phone = reader.GetString("sodienthoai");
                        string address = reader.GetString("diachi");
                        int level = reader.GetInt16("level");
                        return new Member(usrName, name, gender, email, phone, address, level);
                    }
                }

                return null;
            }
            catch (Exception e)
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