using System;
using Web2020Project.Model;

namespace Web2020Project.Website.Model
{
    public class Item
    {
        private int itemID;
        private Product product;
        private int amount;
        private double price;

        public Item()
        {
        }

        public Item(int itemId, Product product, int amount, double price)
        {
            itemID = itemId;
            this.product = product;
            this.amount = amount;
            this.price = price;
        }

        public int ItemId
        {
            get => itemID;
            set => itemID = value;
        }

        public Product Product
        {
            get => product;
            set => product = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }
    }
}