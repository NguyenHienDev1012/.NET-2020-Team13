using System;
using Web2020Project.Model;

namespace Web2020Project.Website.Model
{
    public class Item
    {
        private String id;
        private SanPham sanPham;
        private int soLuong;
        private double gia;

        public Item()
        {
        }

        public Item(string id, SanPham sanPham, int soLuong, double gia)
        {
            this.id = id;
            this.sanPham = sanPham;
            this.soLuong = soLuong;
            this.gia = gia;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public SanPham SanPham
        {
            get => sanPham;
            set => sanPham = value;
        }

        public int SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        public double Gia
        {
            get => gia;
            set => gia = value;
        }
    }
}