namespace Web2020Project.Models.MODEL
{
    public class BinhLuan
    {
        private int id;
        private string hoTen;
        private string noiDung;
        private int maSanPham;
        private string sanPham;
        private string ngayBinhLuan;

        public BinhLuan()
        {
        }

        public BinhLuan(int id, string hoTen, string noiDung, int maSanPham, string sanPham, string ngayBinhLuan)
        {
            this.id = id;
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
    }
}