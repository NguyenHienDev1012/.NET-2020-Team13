using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class SearchDAO
    {
        public static List<Product> Search(String input)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Product> products = new List<Product>();
            try
            {
                string sql = "SELECT * FROM SANPHAM WHERE TRANGTHAI>0 AND TENSANPHAM LIKE " + "'%" + input +
                             "%' LIMIT 6";
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

        public static List<ProductDetail> SearchKey(String key)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<ProductDetail> productDetails = new List<ProductDetail>();
            try
            {
                string sql =
                    "SELECT * FROM SANPHAM AS SP JOIN CHITIETSANPHAM AS CT WHERE SP.MASANPHAM=CT.MASANPHAM AND TRANGTHAI>0 AND SP.TENSANPHAM LIKE " +
                    "'%" + key + "%'";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productDetails.Add(new ProductDetail().GetProductDetail(reader));
                    }
                }

                return productDetails.Count != 0 ? productDetails : null;
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