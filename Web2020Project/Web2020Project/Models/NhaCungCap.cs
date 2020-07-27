using System;

namespace Web2020Project.Model
{
    public class NhaCungCap
    {
        private String maNhaCungCap;
        private String tenNhaCungCap;
        private String diaChi;

        public NhaCungCap()
        {
        }

        public NhaCungCap(string maNhaCungCap, string tenNhaCungCap, string diaChi)
        {
            this.maNhaCungCap = maNhaCungCap;
            this.tenNhaCungCap = tenNhaCungCap;
            this.diaChi = diaChi;
        }

        public string MaNhaCungCap
        {
            get => maNhaCungCap;
            set => maNhaCungCap = value;
        }

        public string TenNhaCungCap
        {
            get => tenNhaCungCap;
            set => tenNhaCungCap = value;
        }

        public string DiaChi
        {
            get => diaChi;
            set => diaChi = value;
        }
    }
}