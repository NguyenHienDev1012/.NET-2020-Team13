using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class ProductDAO
    {
        public static List<Product> LoadProducts()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Product> products = new List<Product>();
            try
            {
                string sql = "SELECT * FROM SANPHAM";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        products.Add(new Product().GetProduct(reader));
                    }
                }

                return products.Count != 0 ? products : null;
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

        public static Product getProductID(int productID)
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
                cmd.Parameters.AddWithValue("@msp", productID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId= reader.GetInt16("masanpham");
                        product.ProductName = reader.GetString("tensanpham");
                        product.SalePrice = reader.GetDouble("giadagiam");
                        product.Picture = reader.GetString("hinhanh");
                        return product;
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