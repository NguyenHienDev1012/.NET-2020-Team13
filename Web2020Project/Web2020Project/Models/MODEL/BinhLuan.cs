namespace Web2020Project.Models.MODEL
{
    public class Comment
    {
        private string hoTen;
        private string noiDung;
        private int maSanPham;
        private string sanPham;
        private string ngayBinhLuan;

        public Comment()
        {
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