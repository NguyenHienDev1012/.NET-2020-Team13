namespace Web2020Project.Models.MODEL
{
    public class NhaCungCap
    {
        private string maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;

        public NhaCungCap()
        {
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