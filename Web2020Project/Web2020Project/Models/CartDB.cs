using System;

namespace Web2020Project.Model
{
    public class CartDB
    {
        private String cartID;
        private String name;
        private String email;
        private String phone;
        private String address;
        private String productName;
        private int status;
        private int amount;
        private double totalMoney;
        private String dateOfpayment;
        private String picture;

        public CartDB()
        {
        }

        public CartDB(string cartId, string name, string email, string phone, string address,String dateOfpayment)
        {
            cartID = cartId;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.dateOfpayment = dateOfpayment;
        }

        public CartDB(string productName, int status, int amount, double totalMoney, string picture)
        {
            this.productName = productName;
            this.status = status;
            this.amount = amount;
            this.totalMoney = totalMoney;
            this.picture = picture;
        }

        public string CartId
        {
            get => cartID;
            set => cartID = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
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

        public string ProductName
        {
            get => productName;
            set => productName = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public double TotalMoney
        {
            get => totalMoney;
            set => totalMoney = value;
        }

        public string DateOfpayment
        {
            get => dateOfpayment;
            set => dateOfpayment = value;
        }

        public string Picture
        {
            get => picture;
            set => picture = value;
        }
    }
}