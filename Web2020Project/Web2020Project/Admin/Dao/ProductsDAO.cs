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


        public static ProductDetail LoadProductDetail(string IDProducts)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            List<ProductDetail> productDetails = new List<ProductDetail>();
            try
            {
                string sql =
                    "SELECT * FROM sanpham as sp JOIN chitietsanpham as ct on sp.masanpham=ct.masanpham where sp.masanpham=@IDProducts";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@IDProducts", IDProducts);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        // return new News().GetNews(reader);
                        return new ProductDetail().GetProductDetail(reader);
                    }
                }

                return null;
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

        public static bool EditProduct(ProductDetail productDetail)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "UPDATE SANPHAM AS SP JOIN CHITIETSANPHAM AS CTSP ON SP.MASANPHAM = CTSP.MASANPHAM SET SP.TENSANPHAM=@productName,SP.GIADAGIAM=@salePrice,SP.GIABAN=@price,SP.SOLUONG=@amount,SP.HINHANH=@picture,SP.TRANGTHAI=@status,SP.LOAISANPHAM=@kind, CTSP.QUATANG=@gift,CTSP.MANHINH=@screen,CTSP.HEDIEUHANH=@OperatingSystem,CTSP.CPU=@CPU,CTSP.RAM=@RAM,CTSP.CAMERA=@CAMERA,CTSP.PIN=@PIN WHERE SP.MASANPHAM=@productID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@productName", productDetail.Product.ProductName);
                cmd.Parameters.AddWithValue("@salePrice", productDetail.Product.SalePrice);
                cmd.Parameters.AddWithValue("@price", productDetail.Product.Price);
                cmd.Parameters.AddWithValue("@amount", productDetail.Product.Amount);
                cmd.Parameters.AddWithValue("@picture", productDetail.Product.Picture);
                cmd.Parameters.AddWithValue("@status", productDetail.Product.Status);
                cmd.Parameters.AddWithValue("@kind", productDetail.Product.Kind);
                cmd.Parameters.AddWithValue("@gift", productDetail.Gift);
                cmd.Parameters.AddWithValue("@screen", productDetail.Technical.Screen);
                cmd.Parameters.AddWithValue("@OperatingSystem", productDetail.Technical.OperatingSystem);
                cmd.Parameters.AddWithValue("@CPU", productDetail.Technical.Cpu);
                cmd.Parameters.AddWithValue("@RAM", productDetail.Technical.Ram);
                cmd.Parameters.AddWithValue("@CAMERA", productDetail.Technical.Camera);
                cmd.Parameters.AddWithValue("@PIN", productDetail.Technical.Pin);
                cmd.Parameters.AddWithValue("@productID", productDetail.Product.ProductId);
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

        public static bool add(ProductDetail productDetail)
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
                    "INSERT INTO CHITIETSANPHAM(QUATANG,MANHINH,HEDIEUHANH,CPU,RAM,CAMERA,PIN) values (@gift,@screen,@os,@cpu,@ram,@cam,@pin)";
                cmd = new MySqlCommand(sql2, connection);
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