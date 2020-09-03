using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Admin.Dao
{
    public class OrderDAO
    {
        public static List<CartDB> OrdersList()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<CartDB> cartDbs = new List<CartDB>();
            try
            {
                string sql = "SELECT MAGIOHANG,HOTEN,EMAIL,SODIENTHOAI,DIACHI,NGAYTHANHTOAN FROM GIOHANG";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String cartID = reader.GetString("magiohang");
                        String name = reader.GetString("hoten");
                        String email = reader.GetString("email");
                        String phone = reader.GetString("sodienthoai");
                        String address = reader.GetString("diachi");
                        String dateOfpayment = reader.GetString("ngaythanhtoan");
                        cartDbs.Add(new CartDB(cartID, name, email, phone, address, dateOfpayment));
                    }
                }

                return cartDbs.Count != 0 ? cartDbs : null;
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

        public static List<CartDB> OrdersDetailList(String cartID)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<CartDB> cartDbs = new List<CartDB>();
            try
            {
                string sql =
                    "SELECT TENSANPHAM,TRANGTHAI,SOLUONG,SOTIEN,HINHANH FROM CHITIETDONHANG WHERE MAGIOHANG=@cartID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cartID", cartID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString("tensanpham");
                        int status = reader.GetInt16("trangthai");
                        int amount = reader.GetInt16("soluong");
                        double totalMoney = reader.GetDouble("sotien");
                        string picture = reader.GetString("hinhanh");
                        cartDbs.Add(new CartDB(productName, status, amount, totalMoney, picture));
                    }
                }

                return cartDbs;
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

        public static bool RemoveOrders(String cartID)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "DELETE FROM GIOHANG WHERE MAGIOHANG=@cartID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cartID", cartID);
                if (cmd.ExecuteNonQuery() < 1) return false;
                sql = "DELETE FROM CHITIETDONHANG WHERE MAGIOHANG=@cartID";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cartID", cartID);
                if (cmd.ExecuteNonQuery() > 0) return true;
                return false;
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
        public static CartDB GetCartDB(string cartID)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "SELECT MAGIOHANGF, HOTEN, EMAIL, SODIENTHOAI, DIACHI, NGAYTHANHTOAN WHERE MAGIOHANG=@MAGIOHANG";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MAGIOHANG", cartID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return new CartDB().GetOrder(reader);
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