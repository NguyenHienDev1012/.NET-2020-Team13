
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Models.MODEL;

namespace Web2020Project.Admin.Dao
{
    public class BinhLuanDao
    {
        private static MySqlDataReader reader = null;

        public static List<BinhLuan> getListComment()
        {
            List<BinhLuan> listComment = new List<BinhLuan>();
            string sql =
                "select * from binhluan";
            MySqlConnection conn = DBConnection.getDBConnection();
            conn.Open();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string hoten = reader[1].ToString();
                        string noidung = reader[2].ToString();
                        int masanpham = reader.GetInt32(3);
                        string sanpham = reader[4].ToString();
                        string ngaybinhluan = reader[5].ToString();
                        BinhLuan bl = new BinhLuan(id, hoten, noidung, masanpham, sanpham, ngaybinhluan);
                        listComment.Add(bl);
                    }
                }

                return listComment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
        }

       
    }
    }