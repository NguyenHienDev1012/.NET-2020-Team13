using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class Technical
    {
        private String screen;
        private String operatingSystem;
        private String CPU;
        private String RAM;
        private String CAMERA;
        private String PIN;

        public Technical()
        {
        }

        public Technical(string screen, string operatingSystem, string cpu, string ram, string camera, string pin)
        {
            this.screen = screen;
            this.operatingSystem = operatingSystem;
            CPU = cpu;
            RAM = ram;
            CAMERA = camera;
            PIN = pin;
        }

        public string Screen
        {
            get => screen;
            set => screen = value;
        }

        public string OperatingSystem
        {
            get => operatingSystem;
            set => operatingSystem = value;
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

        public Technical GetTechnical(MySqlDataReader reader)
        {
            Screen = reader.GetString("manhinh");
            OperatingSystem = reader.GetString("hedieuhanh");
            CPU = reader.GetString("cpu");
            RAM = reader.GetString("ram");
            CAMERA = reader.GetString("camera");
            PIN = reader.GetString("pin");
            return this;
        }
    }
}