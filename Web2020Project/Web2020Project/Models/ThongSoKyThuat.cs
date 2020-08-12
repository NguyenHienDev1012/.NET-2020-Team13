using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class ThongSoKyThuat
    {
        private String manHinh;
        private String heDieuHanh;
        private String CPU;
        private String RAM;
        private String CAMERA;
        private String PIN;

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

        public ThongSoKyThuat ThemTSKT(MySqlDataReader reader)
        {
            ThongSoKyThuat tskt = new ThongSoKyThuat();
            tskt.ManHinh = reader.GetString("manhinh");
            tskt.HeDieuHanh = reader.GetString("hedieuhanh");
            tskt.CPU = reader.GetString("cpu");
            tskt.RAM = reader.GetString("ram");
            tskt.CAMERA = reader.GetString("camera");
            tskt.PIN = reader.GetString("pin");
            return tskt;
        }
    }
}