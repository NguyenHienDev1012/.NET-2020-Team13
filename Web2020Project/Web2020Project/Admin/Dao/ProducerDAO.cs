﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Admin.Dao
{
    public class ProducerDAO
    {
        public static List<Producer> LoadProducer()
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Producer> producers = new List<Producer>();
            try
            {
                string sql = "SELECT * FROM NHACUNGCAP";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producers.Add(new Producer().GetProducer(reader));
                    }
                }

                return producers.Count != 0 ? producers : null;
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

        public static bool AddProducer(Producer producer)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "INSERT INTO NHACUNGCAP VALUES (@producerID,@producerName,@producerAddress)";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@producerID", producer.ProducerId);
                cmd.Parameters.AddWithValue("@producerName", producer.ProducerName);
                cmd.Parameters.AddWithValue("@producerAddress", producer.ProducerAddress);
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

        public static bool EditProducer(Producer producer)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "UPDATE NHACUNGCAP SET TENNHACUNGCAP=@prName,DIACHI=@prAddress WHERE MANHACUNGCAP=@prID";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@prName", producer.ProducerName);
                cmd.Parameters.AddWithValue("@prAddress", producer.ProducerAddress);
                cmd.Parameters.AddWithValue("@prID", producer.ProducerId);
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

        public static bool EditNewID(Producer producer, String pr_ID_Old)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "UPDATE NHACUNGCAP SET MANHACUNGCAP=@prID ,TENNHACUNGCAP=@prName,DIACHI=@prAddress WHERE MANHACUNGCAP=@prIDOld";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@prID", producer.ProducerName);
                cmd.Parameters.AddWithValue("@prName", producer.ProducerName);
                cmd.Parameters.AddWithValue("@prAddress", producer.ProducerAddress);
                cmd.Parameters.AddWithValue("@prIDOld", pr_ID_Old);
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

        public static Producer GetProducer(string ProducerID)
        {
            MySqlDataReader reader = null;
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql =
                    "SELECT MANHACUNGCAP,TENNHACUNGCAP,DIACHI FROM NHACUNGCAP WHERE MANHACUNGCAP=@MANHACUNGCAP";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MANHACUNGCAP", ProducerID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader.Read()) return null; //Chi duoc ton tai 1 tai khoan
                        string producerID = reader.GetString("MANHACUNGCAP");
                        string producerName = reader.GetString("TENNHACUNGCAP");
                        string producerAddress = reader.GetString("DIACHI");
                        return new Producer(producerID, producerName, producerAddress);
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