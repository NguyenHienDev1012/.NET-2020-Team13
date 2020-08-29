using System;
using System.Collections.Generic;
using Web2020Project.Model;

namespace Web2020Project.Website.Model
{
    public class GioHang
    {
        private String id;
        private ThanhVien thanhVien;
        private List<Item> item;
        private int trangthai;
        private String ngayThanhToan;

        public GioHang(string id, ThanhVien thanhVien, List<Item> item, int trangthai, string ngayThanhToan)
        {
            this.id = id;
            this.thanhVien = thanhVien;
            this.item = item;
            this.trangthai = trangthai;
            this.ngayThanhToan = ngayThanhToan;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public ThanhVien ThanhVien
        {
            get => thanhVien;
            set => thanhVien = value;
        }

        public List<Item> Item
        {
            get => item;
            set => item = value;
        }

        public int Trangthai
        {
            get => trangthai;
            set => trangthai = value;
        }

        public string NgayThanhToan
        {
            get => ngayThanhToan;
            set => ngayThanhToan = value;
        }

        public int TotalItem()
        {
            int count = 0;
            if (item != null && item.Count != 0)
            {
                foreach (Item i in item)
                {
                    count += i.SoLuong;
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
                    price += i.Gia * i.SoLuong;
                }
            }

            return price;
        }
    }
}