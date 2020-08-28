using System;
using System.Collections.Generic;
using Web2020Project.Model;

namespace Web2020Project.Website.Model
{
    public class Cart
    {
        private String cartID;
        private Member member;
        private List<Item> item;
        private int cartStatus;
        private String dayOfPayment;

        public Cart(string cartId, Member member, List<Item> item, int cartStatus, string dayOfPayment)
        {
            cartID = cartId;
            this.member = member;
            this.item = item;
            this.cartStatus = cartStatus;
            this.dayOfPayment = dayOfPayment;
        }

        public string CartId
        {
            get => cartID;
            set => cartID = value;
        }

        public Member Member
        {
            get => member;
            set => member = value;
        }

        public List<Item> Item
        {
            get => item;
            set => item = value;
        }

        public int CartStatus
        {
            get => cartStatus;
            set => cartStatus = value;
        }

        public string DayOfPayment
        {
            get => dayOfPayment;
            set => dayOfPayment = value;
        }

        public int TotalItem()
        {
            int count = 0;
            if (item != null && item.Count != 0)
            {
                foreach (Item i in item)
                {
                    count += i.Amount;
                }
            }

            return count;
        }

        public double TotalPrice()
        {
            double price = 0;
            if (item != null && item.Count != 0)
            {
                foreach (Item i in item)
                {
                    price += i.Price * i.Amount;
                }
            }

            return price;
        }
    }
}