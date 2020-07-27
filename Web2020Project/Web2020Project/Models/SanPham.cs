using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class SanPham
    {
        private int maSanPham;
        private String tenSanPham;
        private String nhaCungCap;
        private double giaDaGiam;
        private double giaBan;
        private String hinhAnh;
        private int soLuong;
        private int trangTHai;
        private int loai;

        public SanPham()
        {
        }

        public SanPham(int maSanPham, string tenSanPham, string nhaCungCap, double giaDaGiam, double giaBan,
            string hinhAnh, int soLuong, int trangTHai, int loai)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.nhaCungCap = nhaCungCap;
            this.giaDaGiam = giaDaGiam;
            this.giaBan = giaBan;
            this.hinhAnh = hinhAnh;
            this.soLuong = soLuong;
            this.trangTHai = trangTHai;
            this.loai = loai;
        }

        public int MaSanPham
        {
            get => maSanPham;
            set => maSanPham = value;
        }

        public string TenSanPham
        {
            get => tenSanPham;
            set => tenSanPham = value;
        }

        public string NhaCungCap
        {
            get => nhaCungCap;
            set => nhaCungCap = value;
        }

        public double GiaDaGiam
        {
            get => giaDaGiam;
            set => giaDaGiam = value;
        }

        public double GiaBan
        {
            get => giaBan;
            set => giaBan = value;
        }

        public string HinhAnh
        {
            get => hinhAnh;
            set => hinhAnh = value;
        }

        public int SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        public int TrangTHai
        {
            get => trangTHai;
            set => trangTHai = value;
        }

        public int Loai
        {
            get => loai;
            set => loai = value;
        }

        public SanPham GetSanPham(MySqlDataReader reader)
        {
            SanPham sanpham = new SanPham();
            sanpham.MaSanPham = reader.GetInt16("masanpham");
            sanpham.TenSanPham = reader.GetString("tensanpham");
            sanpham.NhaCungCap = reader.GetString("nhacungcap");
            sanpham.GiaDaGiam = reader.GetDouble("giadagiam");
            sanpham.GiaBan = reader.GetDouble("giaban");
            sanpham.SoLuong = reader.GetInt16("soluong");
            sanpham.HinhAnh = reader.GetString("hinhanh");
            sanpham.TrangTHai = reader.GetInt16("trangthai");
            sanpham.Loai = reader.GetInt16("loaisanpham");
            return sanpham;
        }
    }
}