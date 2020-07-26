namespace Web2020Project.Models.MODEL
{
    public class GioHang_DB
    {
        private string maGioHang;
        private string hoten;
        private string email;
        private string soDienThoai;
        private string diaChi;
        private string tenSanPham;
        private int trangThai;
        private int soLuong;
        private double soTien;
        private string ngayThanhToan;
        private string hinhanh;

        public GioHang_DB()
        {
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