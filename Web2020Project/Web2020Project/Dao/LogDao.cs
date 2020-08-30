using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web;
using Web2020Project.libs;
using MySql.Data.MySqlClient;
using Web2020Project.Model;
using Web2020Project.Models;
using Web2020Project.Utils;
using Web2020Project.Website.Models;

namespace Web2020Project.DAO
{
    public class LogDao
    {
        public static bool add(Log log)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            try
            {
                string sql = "INSERT INTO LOG(thongbao, capdo, taikhoan, diachi, ip, ngaythuchien) VALUES (@thongbao, @capdo, @taikhoan, @diachi, @ip, now())";
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@thongbao", log.Message);
                cmd.Parameters.AddWithValue("@capdo", log.Level);
                cmd.Parameters.AddWithValue("@taikhoan", log.Member.UserName);
                cmd.Parameters.AddWithValue("@diachi", log.Address);
                cmd.Parameters.AddWithValue("@ip", log.Ip);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }
            finally
            {
                ReleaseResources.Release(connection, null, cmd);
            }

        }
        public static string GetIPAddress()
        {
           string ipaddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;
        }

        public static List<Role> loadRolesByUserName(string username)
        { 
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            List<Role> roles= new List<Role>();
            string sql = "SELECT control,action FROM resource,userrole  WHERE  userrole.username=@username and userrole.idResource = resource.id and resource.active =1";
            try
            {
                connection = DBConnection.getConnection();
                connection.Open();
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role(reader.GetString("control"), reader.GetString("action")));
                    }
                }
                return roles.Count!=0? roles: null;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                ReleaseResources.Release(connection, reader, cmd);
            }
            
            
        }
        public static void LogBase(Log log, string message, string address)
        {
            log.Message = message;
            log.Address = address;
            log.Member = HttpContext.Current.Session["memberLogin"] as Member;
            log.Ip = GetIPAddress();
            add(log);
        }
        public static void FAILEDLOGIN(string message, string address)
        {
            Log log =new Log();
            log.Message = message;
            log.Member= new Member();
            log.Level = Level.INFOR.ToString();
            log.Address = address;
            log.Ip = GetIPAddress();
            add(log);
        }

        public static void INFO(string message, string address)
        {
            Log log= new Log();
            log.Level = Level.INFOR.ToString();
            LogBase(log, message, address);
        }

        public static void WARNING(string message, string address)
        {
            Log log= new Log();
            log.Level = Level.WARNING.ToString();
            LogBase(log, message, address);
        }
        public static void ALERT(string message, string address)
        {
            Log log= new Log();
            log.Level = Level.ALERT.ToString();
            LogBase(log, message, address);
        }
    }
}