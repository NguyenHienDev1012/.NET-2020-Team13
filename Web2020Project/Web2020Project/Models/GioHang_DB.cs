using System;

namespace Web2020Project.Model
{
    public class GioHang_DB
    {
        private String maGioHang;
        private String hoten;
        private String email;
        private String soDienThoai;
        private String diaChi;
        private String tenSanPham;
        private int trangThai;
        private int soLuong;
        private double soTien;
        private String ngayThanhToan;
        private String hinhanh;

        public GioHang_DB()
        {
        }

        public GioHang_DB(string maGioHang, string hoten, string email, string soDienThoai, string diaChi, string tenSanPham, int trangThai, int soLuong, double soTien, string ngayThanhToan, string hinhanh)
        {
            this.maGioHang = maGioHang;
            this.hoten = hoten;
            this.email = email;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.tenSanPham = tenSanPham;
            this.trangThai = trangThai;
            this.soLuong = soLuong;
            this.soTien = soTien;
            this.ngayThanhToan = ngayThanhToan;
            this.hinhanh = hinhanh;
        }

        public string MaGioHang
        {
            get => maGioHang;
            set => maGioHang = value;
        }

        public string Hoten
        {
            get => hoten;
            set => hoten = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string SoDienThoai
        {
            get => soDienThoai;
            set => soDienThoai = value;
        }

        public string DiaChi
        {
            get => diaChi;
            set => diaChi = value;
        }

        public string TenSanPham
        {
            get => tenSanPham;
            set => tenSanPham = value;
        }

        public int TrangThai
        {
            get => trangThai;
            set => trangThai = value;
        }

        public int SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        public double SoTien
        {
            get => soTien;
            set => soTien = value;
        }

        public string NgayThanhToan
        {
            get => ngayThanhToan;
            set => ngayThanhToan = value;
        }

        public string Hinhanh
        {
            get => hinhanh;
            set => hinhanh = value;
        }
        
    }
}