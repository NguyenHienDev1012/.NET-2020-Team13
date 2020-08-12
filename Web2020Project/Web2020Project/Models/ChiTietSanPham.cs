using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class ChiTietSanPham
    {
        private SanPham sanPham;
        private int danhGia;
        private double xepHang;
        private String quaTang;
        private ThongSoKyThuat thongSoKyThuat;

        public ChiTietSanPham()
        {
        }

        public ChiTietSanPham(SanPham sanPham, int danhGia, double xepHang, string quaTang,
            ThongSoKyThuat thongSoKyThuat)
        {
            this.sanPham = sanPham;
            this.danhGia = danhGia;
            this.xepHang = xepHang;
            this.quaTang = quaTang;
            this.thongSoKyThuat = thongSoKyThuat;
        }

        public SanPham SanPham
        {
            get => sanPham;
            set => sanPham = value;
        }

        public int DanhGia
        {
            get => danhGia;
            set => danhGia = value;
        }

        public double XepHang
        {
            get => xepHang;
            set => xepHang = value;
        }

        public string QuaTang
        {
            get => quaTang;
            set => quaTang = value;
        }

        public ThongSoKyThuat ThongSoKyThuat
        {
            get => thongSoKyThuat;
            set => thongSoKyThuat = value;
        }

        public ChiTietSanPham GetChiTietSanPham(MySqlDataReader reader)
        {
            ChiTietSanPham chiTietSanPham = new ChiTietSanPham();
            chiTietSanPham.SanPham = new SanPham().GetSanPham(reader);
            chiTietSanPham.QuaTang = reader.GetString("quatang");
            chiTietSanPham.DanhGia = reader.GetInt16("danhgia");
            chiTietSanPham.XepHang = reader.GetDouble("xephang");
            chiTietSanPham.ThongSoKyThuat = new ThongSoKyThuat().ThemTSKT(reader);
            return chiTietSanPham;
        }
    }
}