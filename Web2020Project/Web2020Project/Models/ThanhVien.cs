using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class ThanhVien
    {
        private string taiKhoan;
        private string matKhau;
        private string hoTen;
        private string gioiTinh;
        private string email;
        private string soDienThoai;
        private string diaChi;
        private int level=0;
        private string avatar;

        public ThanhVien()
        {
        }

        public ThanhVien(string taiKhoan, string matKhau, string hoTen, string gioiTinh, string email, string soDienThoai, string diaChi, int level, string avatar)
        {
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.email = email;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.level = level;
            this.avatar = avatar;
        }

        public string TaiKhoan
        {
            get => taiKhoan;
            set => taiKhoan = value;
        }

        public string MatKhau
        {
            get => matKhau;
            set => matKhau = value;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public string GioiTinh
        {
            get => gioiTinh;
            set => gioiTinh = value;
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

        public int Level
        {
            get => level;
            set => level = value;
        }

        public string Avatar
        {
            get => avatar;
            set => avatar = value;
        }

        public ThanhVien ThemThanhVien( MySqlDataReader reader)
        {
            ThanhVien thanhVien = new ThanhVien();
            thanhVien.TaiKhoan=reader.GetString("taikhoan");
            thanhVien.MatKhau=reader.GetString("matkhau");
            thanhVien.Level=reader.GetInt32("level");
            thanhVien.GioiTinh=reader.GetString("gioitinh");
            thanhVien.SoDienThoai=reader.GetString("sodienthoai");
            thanhVien.DiaChi=reader.GetString("diachi");
            thanhVien.Email=reader.GetString("email");
            thanhVien.HoTen=reader.GetString("hoten");
            return thanhVien;
        }
    }
}