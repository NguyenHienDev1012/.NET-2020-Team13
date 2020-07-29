using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Admin.Dao
{
    public class ProductsDAO
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


        public static List<ProductDetail> LoadProductDetail()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            List<ProductDetail> productDetails = new List<ProductDetail>();
            try
            {
                string sql = "SELECT * FROM sanpham as sp JOIN chitietsanpham as ct on sp.masanpham=ct.masanpham";
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
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
        }

        public bool EditProducer(ProductDetail productDetail)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql1 =
                    "UPDATE SANPHAM SET TENSANPHAM=@prName,GIADAGIAM=@salePrice,GIABAN=@price,SOLUONG=@amount,HINHANH=@picture,TRANGTHAI=@status,LOAISANPHAM=@kind WHERE MASANPHAM=@prID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql1, connection);
                cmd.Parameters.AddWithValue("@prName", productDetail.Product.ProductName);
                cmd.Parameters.AddWithValue("@salePrice", productDetail.Product.SalePrice);
                cmd.Parameters.AddWithValue("@price", productDetail.Product.Price);
                cmd.Parameters.AddWithValue("@amount", productDetail.Product.Amount);
                cmd.Parameters.AddWithValue("@picture", productDetail.Product.Picture);
                cmd.Parameters.AddWithValue("@status", productDetail.Product.Status);
                cmd.Parameters.AddWithValue("@kind", productDetail.Product.Kind);
                cmd.Parameters.AddWithValue("@prID", productDetail.Product.ProductId);
                if (cmd.ExecuteNonQuery() < 0) return false;
                string sql2 =
                    "UPDATE CHITIETSANPHAM SET  QUATANG=@gift,MANHINH=@screen,HEDIEUHANH=@os,CPU=@cpu,RAM=@ram,CAMERA=@cam,PIN=@pin WHERE MASANPHAM=@prID";
                cmd = new MySqlCommand(sql1, connection);
                cmd.Parameters.AddWithValue("@gift", productDetail.Gift);
                cmd.Parameters.AddWithValue("@screen", productDetail.Technical.Screen);
                cmd.Parameters.AddWithValue("@os", productDetail.Technical.OperatingSystem);
                cmd.Parameters.AddWithValue("@cpu", productDetail.Technical.Cpu);
                cmd.Parameters.AddWithValue("@ram", productDetail.Technical.Ram);
                cmd.Parameters.AddWithValue("@cam", productDetail.Technical.Camera);
                cmd.Parameters.AddWithValue("@pin", productDetail.Technical.Pin);
                cmd.Parameters.AddWithValue("@prID", productDetail.Product.ProductId);
                return cmd.ExecuteNonQuery() > 0;
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

        public bool add(ProductDetail productDetail)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql1 =
                    "INSERT INTO SANPHAM(TENSANPHAM,NHACUNGCAP,GIADAGIAM,GIABAN,SOLUONG,HINHANH,TRANGTHAI,LOAISANPHAM) VALUES (@prName,@producer,@salePrice,@price,@amount,@picture,@status,@kind)";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql1, connection);
                cmd.Parameters.AddWithValue("@prName", productDetail.Product.ProductName);
                cmd.Parameters.AddWithValue("@producer", productDetail.Product.Producer);
                cmd.Parameters.AddWithValue("@salePrice", productDetail.Product.SalePrice);
                cmd.Parameters.AddWithValue("@price", productDetail.Product.Price);
                cmd.Parameters.AddWithValue("@amount", productDetail.Product.Amount);
                cmd.Parameters.AddWithValue("@picture", productDetail.Product.Picture);
                cmd.Parameters.AddWithValue("@status", productDetail.Product.Status);
                cmd.Parameters.AddWithValue("@kind", productDetail.Product.Kind);
                if (cmd.ExecuteNonQuery() < 0) return false;
                string sql2 =
                    "INSERT INTO CHITIETSANPHAM(QUATANG,MAHINH,HEDIEUHANH,CPU,RAM,CAMERA,PIN) values (@gift,@screen,@os,@cpu,@ram,@cam,@pin)";
                cmd = new MySqlCommand(sql1, connection);
                cmd.Parameters.AddWithValue("@gift", productDetail.Gift);
                cmd.Parameters.AddWithValue("@screen", productDetail.Technical.Screen);
                cmd.Parameters.AddWithValue("@os", productDetail.Technical.OperatingSystem);
                cmd.Parameters.AddWithValue("@cpu", productDetail.Technical.Cpu);
                cmd.Parameters.AddWithValue("@ram", productDetail.Technical.Ram);
                cmd.Parameters.AddWithValue("@cam", productDetail.Technical.Camera);
                cmd.Parameters.AddWithValue("@pin", productDetail.Technical.Pin);
                return cmd.ExecuteNonQuery() > 0;
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
    }
}