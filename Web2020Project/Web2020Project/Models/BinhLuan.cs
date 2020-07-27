using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class BinhLuan
    {
        private String hoTen;
        private String noiDung;
        private int maSanPham;
        private String sanPham;
        private String ngayBinhLuan;

        public BinhLuan()
        {
        }

        public BinhLuan(string hoTen, string noiDung, int maSanPham, string sanPham, string ngayBinhLuan)
        {
            this.hoTen = hoTen;
            this.noiDung = noiDung;
            this.maSanPham = maSanPham;
            this.sanPham = sanPham;
            this.ngayBinhLuan = ngayBinhLuan;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public string NoiDung
        {
            get => noiDung;
            set => noiDung = value;
        }

        public int MaSanPham
        {
            get => maSanPham;
            set => maSanPham = value;
        }

        public string SanPham
        {
            get => sanPham;
            set => sanPham = value;
        }

        public string NgayBinhLuan
        {
            get => ngayBinhLuan;
            set => ngayBinhLuan = value;
        }
        public BinhLuan GetBinhLuan(MySqlDataReader reader)
        {
            BinhLuan binhLuan = new BinhLuan();
            binhLuan.HoTen = reader.GetString("hoten");
            binhLuan.NoiDung = reader.GetString("noidung");
            binhLuan.SanPham = reader.GetString("sanpham");
            binhLuan.NgayBinhLuan = reader.GetString("ngaybinhluan");
            return binhLuan;
        }
    }
}