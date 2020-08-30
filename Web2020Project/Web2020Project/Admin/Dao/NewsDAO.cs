﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Web2020Project.Dao;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Admin.Dao
{
    public class NewsDAO
    {
        public static List<News> LoadNews()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<News> newses = new List<News>();
            try
            {
                string sql = "SELECT ID,TIEUDE,NGAYVIET,LOAI FROM TINTUC";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int newsID = reader.GetInt16("id");
                        string title = reader.GetString("tieude");
                        string dateOfWriting = reader.GetString("ngayviet");
                        int kind = reader.GetInt16("loai");
                        newses.Add(new News(newsID, title, dateOfWriting, kind));
                    }
                }

                return newses.Count != 0 ? newses : null;
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

        public static News FindByID(int newsID)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            try
            {
                string sql = "SELECT * FROM TINTUC WHERE ID=@newsID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@newsID", newsID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return new News().GetNews(reader);
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

        public static bool RemoveNews(int newsID)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "DELETE FROM TINTUC WHERE ID=@newsID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@newsID", newsID);
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

        public static bool AddNews(News news)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "INSERT INTO TINTUC(tieude,anhmota,mota,ngayviet,noidung,loai) VALUES (@title,@picture,@description,@dateOfWrite,@content,@kind)";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@title", news.Title);
                cmd.Parameters.AddWithValue("@picture", news.Picture);
                cmd.Parameters.AddWithValue("@description", news.Description);
                cmd.Parameters.AddWithValue("@dateOfWrite", news.DateOfWriting);
                cmd.Parameters.AddWithValue("@content", news.Content);
                cmd.Parameters.AddWithValue("@kind", news.Kind);
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

        public static bool EditNews(News news)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "UPDATE TINTUC SET tieude=@title, anhmota=@picture,mota=@description,ngayviet=dateOfWrite,noidung=@content,loai=@kind WHERE id=@idNews";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@title", news.Title);
                cmd.Parameters.AddWithValue("@picture", news.Picture);
                cmd.Parameters.AddWithValue("@description", news.Description);
                cmd.Parameters.AddWithValue("@dateOfWrite", news.DateOfWriting);
                cmd.Parameters.AddWithValue("@content", news.Content);
                cmd.Parameters.AddWithValue("@kind", news.Kind);
                cmd.Parameters.AddWithValue("@idNews", news.NewsId);
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