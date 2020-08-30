using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Website.Dao
{
    public class CommentDAO
    {
        public static List<Comment> LoadComment()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Comment> listComment = new List<Comment>();
            try
            {
                string sql = "SELECT * FROM BINHLUAN";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listComment.Add(new Comment().GetComment(reader));
                    }
                }

                return listComment.Count != 0 ? listComment : null;
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
        public static bool InsertCMT(Comment comment)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "INSERT INTO BINHLUAN(HOTEN,NOIDUNG,MASANPHAM,SANPHAM,NGAYBINHLUAN) VALUES (@ten,@noidung,@ma_sp,@sp,NOW())";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ten", comment.Name);
                cmd.Parameters.AddWithValue("@noidung", comment.Content);
                cmd.Parameters.AddWithValue("@ma_sp", comment.ProductId);
                cmd.Parameters.AddWithValue("@sp", comment.Product);
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

        public static List<Comment> LoadCMT(int productID)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Comment> comments = new List<Comment>();
            try
            {
                string sql = "SELECT HOTEN,SANPHAM,NOIDUNG,NGAYBINHLUAN FROM BINHLUAN WHERE MASANPHAM=@msp";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@msp", productID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comments.Add(new Comment().GetComment(reader));
                    }
                }

                return comments.Count != 0 ? comments : null;
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