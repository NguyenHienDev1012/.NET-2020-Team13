using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class ProductDetail
    {
        private Product product;
        private int rate;
        private double rank;
        private string gift;
        private Technical technical;

        public ProductDetail()
        {
        }

        public ProductDetail(Product product, string gift, Technical technical)
        {
            this.product = product;
            this.gift = gift;
            this.technical = technical;
        }

        public ProductDetail(Product product, int rate, double rank, string gift, Technical technical)
        {
            this.product = product;
            this.rate = rate;
            this.rank = rank;
            this.gift = gift;
            this.technical = technical;
        }


        public Product Product
        {
            get => product;
            set => product = value;
        }

        public int Rate
        {
            get => rate;
            set => rate = value;
        }

        public double Rank
        {
            get => rank;
            set => rank = value;
        }

        public string Gift
        {
            get => gift;
            set => gift = value;
        }

        public Technical Technical
        {
            get => technical;
            set => technical = value;
        }

        public ProductDetail GetProductDetail(MySqlDataReader reader)
        {
            Product = new Product().GetProduct(reader);
            Gift = reader.GetString("quatang");
            Rate = reader.GetInt16("danhgia");
            Rank = reader.GetDouble("xephang");
            Technical = new Technical().GetTechnical(reader);
            return this;
        }
    }
}