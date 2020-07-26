using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Models.MODEL;

namespace Web2020Project.Admin.Dao
{
    public class TinTucDao
    {
        private static MySqlDataReader reader = null;

        public static List<TinTuc> getListNews()
        {
            List<TinTuc> listNews = new List<TinTuc>();
            string sql =
                "select * from tintuc";
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
                        string tieude = reader[1].ToString();
                        string anhmota = reader[2].ToString();
                        string mota = reader[3].ToString();
                        string ngayviet = reader[4].ToString();
                        string noidung = reader[5].ToString();
                        int loai = reader.GetInt32(6);
                        TinTuc tt = new TinTuc(id, tieude, anhmota, mota, ngayviet, noidung, loai);
                        listNews.Add(tt);
                    }
                }

                return listNews;
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