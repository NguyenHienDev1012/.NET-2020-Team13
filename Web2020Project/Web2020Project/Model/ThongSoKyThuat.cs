namespace Web2020Project.Models.MODEL
{
    public class ThongSoKyThuat
    {
        private string manHinh;
        private string heDieuHanh;
        private string CPU;
        private string RAM;
        private string CAMERA;
        private string PIN;

        public ThongSoKyThuat()
        {
        }

        public ThongSoKyThuat(string manHinh, string heDieuHanh, string cpu, string ram, string camera, string pin)
        {
            this.manHinh = manHinh;
            this.heDieuHanh = heDieuHanh;
            CPU = cpu;
            RAM = ram;
            CAMERA = camera;
            PIN = pin;
        }

        public string ManHinh
        {
            get => manHinh;
            set => manHinh = value;
        }

        public string HeDieuHanh
        {
            get => heDieuHanh;
            set => heDieuHanh = value;
        }

        public string Cpu
        {
            get => CPU;
            set => CPU = value;
        }

        public string Ram
        {
            get => RAM;
            set => RAM = value;
        }

        public string Camera
        {
            get => CAMERA;
            set => CAMERA = value;
        }

        public string Pin
        {
            get => PIN;
            set => PIN = value;
        }
    }
}