namespace Web2020Project.Models.MODEL
{
    public class ChiTietSanPham
    {
        private SanPham sanPham;
        private int danhGia;
        private double xepHang;
        private string quaTang;
        private ThongSoKyThuat thongSoKyThuat;

        public ChiTietSanPham()
        {
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

        public override string ToString()
        {
            return "ChiTietSanPham{" +
                   "sanPham=" + sanPham +
                   ", danhGia=" + danhGia +
                   ", xepHang=" + xepHang +
                   ", quaTang='" + quaTang + '\'' +
                   ", thongSoKyThuat=" + thongSoKyThuat +
                   '}';
        }
    }
}