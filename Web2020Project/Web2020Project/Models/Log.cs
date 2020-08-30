using System;
using Web2020Project.Model;

namespace Web2020Project.Website.Models
{
    public class Log
    {
        private int id;
        private string message;
        private string level;
        private Member member;
        private string address;
        private string ip;
        private DateTime createdDateTime;

        public Log(int id, string message, string level, Member member, string address, string ip, DateTime createdDateTime)
        {
            this.id = id;
            this.message = message;
            this.level = level;
            this.member = member;
            this.address = address;
            this.ip = ip;
            this.createdDateTime = createdDateTime;
        }

        public Log()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }

        public string Level
        {
            get => level;
            set => level = value;
        }

        public Member Member
        {
            get => member;
            set => member = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Ip
        {
            get => ip;
            set => ip = value;
        }

        public DateTime CreatedDateTime
        {
            get => createdDateTime;
            set => createdDateTime = value;
        }

        public override string ToString()
        {
            return "ID:"+id+ "Message:"+message +"Level:" +level+
                   "Username:"+member.UserName+"Address:"+address+"IP:"+ip+"createdDate:"+ createdDateTime;
        }
    }
}