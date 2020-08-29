using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class Product
    {
        private int productID;
        private string productName;
        private string producer;
        private double salePrice;
        private double price;
        private string picture;
        private int amount;
        private int status;
        private int kind;

        public Product()
        {
        }

        public Product(int productId, string productName, string producer, double salePrice, double price, string picture, int amount, int status, int kind)
        {
            productID = productId;
            this.productName = productName;
            this.producer = producer;
            this.salePrice = salePrice;
            this.price = price;
            this.picture = picture;
            this.amount = amount;
            this.status = status;
            this.kind = kind;
        }

        public int ProductId
        {
            get => productID;
            set => productID = value;
        }

        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        public string Producer
        {
            get => producer;
            set => producer = value;
        }

        public double SalePrice
        {
            get => salePrice;
            set => salePrice = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public string Picture
        {
            get => picture;
            set => picture = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public int Kind
        {
            get => kind;
            set => kind = value;
        }

        public Product GetProduct(MySqlDataReader reader)
        {
            ProductId = reader.GetInt16("masanpham");
            ProductName = reader.GetString("tensanpham");
            Producer = reader.GetString("nhacungcap");
            SalePrice = reader.GetDouble("giadagiam");
            Price = reader.GetDouble("giaban");
            Amount = reader.GetInt16("soluong");
            Picture = reader.GetString("hinhanh");
            Status = reader.GetInt16("trangthai");
            Kind = reader.GetInt16("loaisanpham");
            return this;
        }
    }
}