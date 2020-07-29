using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Website.Model;

namespace Web2020Project.Website.Dao
{
    public class CartDAO
    {
        public bool InsertCart(Cart cart)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            String sql = "INSERT INTO GIOHANG VALUES (@mgh,@hoten,@email,@phone,@diachi,NOW())";
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                String cartID = cart.Member.UserName + "" + (new Random().Next(99999));
                cmd.Parameters.AddWithValue("@mgh", cartID);
                cmd.Parameters.AddWithValue("@hoten", cart.Member.Name);
                cmd.Parameters.AddWithValue("@email", cart.Member.Email);
                cmd.Parameters.AddWithValue("@phone", cart.Member.Phone);
                cmd.Parameters.AddWithValue("@diachi", cart.Member.Address);
                if (cmd.ExecuteNonQuery() < 0) return false;
                sql =
                    "INSERT INTO CHITIETDONHANG(MAGIOHANG,TENSANPHAM,SOTIEN,TRANGTHAI,SOLUONG,HINHANH) VALUES (@mgh,@tensp,@sotien,@trangthai,@soluong,@hinhanh)";
                cmd = new MySqlCommand(sql, connection);
                foreach (Item item in cart.Item)
                {
                    cmd.Parameters.AddWithValue("@mgh", cartID);
                    cmd.Parameters.AddWithValue("@tensp", item.Product.ProductId);
                    cmd.Parameters.AddWithValue("@sotien", (item.Amount * item.Price));
                    cmd.Parameters.AddWithValue("@trangthai",cart.CartStatus);
                    cmd.Parameters.AddWithValue("@soluong", item.Amount);
                    cmd.Parameters.AddWithValue("@hinhanh", item.Product.Picture);
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