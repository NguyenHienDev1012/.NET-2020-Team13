using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class News
    {
        private int newsID;
        private String title;
        private String description;
        private String picture;
        private String content;
        private String dateOfWriting;
        private int kind;

        public News()
        {
        }

        public News(int newsId, string title, string dateOfWriting, int kind)
        {
            newsID = newsId;
            this.title = title;
            this.dateOfWriting = dateOfWriting;
            this.kind = kind;
        }

        public int NewsId
        {
            get => newsID;
            set => newsID = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Picture
        {
            get => picture;
            set => picture = value;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public string DateOfWriting
        {
            get => dateOfWriting;
            set => dateOfWriting = value;
        }

        public int Kind
        {
            get => kind;
            set => kind = value;
        }

        public News GetNews(MySqlDataReader reader)
        {
            NewsId = reader.GetInt32("id");
            Title = reader.GetString("tieude");
            Picture = reader.GetString("anhmota");
            Description = reader.GetString("mota");
            Content = reader.GetString("noidung");
            DateOfWriting = reader.GetString("ngayviet");
            Kind = reader.GetInt16("loai");
            return this;
        }
    }
}