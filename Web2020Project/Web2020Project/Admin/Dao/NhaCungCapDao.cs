using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web2020Project.libs;
using Web2020Project.Models.MODEL;

namespace Web2020Project.Admin.Dao
{
    public class NhaCungCapDao
    {
        private static MySqlDataReader reader = null;

        public static List<NhaCungCap> getListProducer()
        {
            List<NhaCungCap> listProducer = new List<NhaCungCap>();
            string sql =
                "select manhacungcap, tennhacungcap, diachi from nhacungcap";
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
                        string manhacungcap = reader[0].ToString();
                        string tennhacungcap = reader[1].ToString();
                        string diachi = reader[2].ToString();
                        NhaCungCap ncc = new NhaCungCap(manhacungcap, tennhacungcap, diachi);
                        listProducer.Add(ncc);
                    }
                }

                return listProducer;
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