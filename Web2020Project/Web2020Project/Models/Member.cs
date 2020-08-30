using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Web2020Project.Models;

namespace Web2020Project.Model
{
    public class Member
    {
        private string userName;
        private string password;
        private string c_password;
        private string name;
        private string gender;
        private string email;
        private string phone;
        private string address;
        private int level;
        private string avatar;
        private List<Role> roles;// quyền này cho từng user  thực thi action

        public Member()
        {
        }

        public Member(string username)
        {
            this.UserName = username;
        }

        
        public Member(string userName,string name, string gender, string email, string phone, string address, int level)
        {
            this.userName = userName;
            this.name = name;
            this.gender = gender;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.level = level;
        }

        public string CPassword
        {
            get => c_password;
            set => c_password = value;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public string Avatar
        {
            get => avatar;
            set => avatar = value;
        }

        public List<Role> Roles
        {
            get => roles;
            set => roles = value;
        }

        public Member GetMember( MySqlDataReader reader)
        {
            UserName=reader.GetString("taikhoan");
            Password=reader.GetString("matkhau");
            Name=reader.GetString("hoten");
            Gender=reader.GetString("gioitinh");
            Email=reader.GetString("email");
            Phone=reader.GetString("sodienthoai");
            Address=reader.GetString("diachi");
            Level=reader.GetInt32("level");
            // Avatar = reader.GetString("avatar");
            return this;
        }

        public override string ToString()
        {
            return "Tai khoan: "+userName+ ", ten: "+ name+ ", gioi tinh: "+gender+", email: "+ email+ ", sdt: "+phone+ ", dia chi: "+address+ ", level: "+ level;
        }
    }
}