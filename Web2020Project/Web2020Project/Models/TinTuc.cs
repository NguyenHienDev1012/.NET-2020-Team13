using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class TinTuc
    {
        private int maTinTuc;
        private String tieuDe;
        private String moTa;
        private String anhMoTa;
        private String noiDung;
        private String ngayViet;
        private int loai;

        public TinTuc()
        {
        }

        public TinTuc(int maTinTuc, string tieuDe, string moTa, string anhMoTa, string noiDung, string ngayViet,
            int loai)
        {
            this.maTinTuc = maTinTuc;
            this.tieuDe = tieuDe;
            this.moTa = moTa;
            this.anhMoTa = anhMoTa;
            this.noiDung = noiDung;
            this.ngayViet = ngayViet;
            this.loai = loai;
        }

        public int MaTinTuc
        {
            get => maTinTuc;
            set => maTinTuc = value;
        }

        public string TieuDe
        {
            get => tieuDe;
            set => tieuDe = value;
        }

        public string MoTa
        {
            get => moTa;
            set => moTa = value;
        }

        public string AnhMoTa
        {
            get => anhMoTa;
            set => anhMoTa = value;
        }

        public string NoiDung
        {
            get => noiDung;
            set => noiDung = value;
        }

        public string NgayViet
        {
            get => ngayViet;
            set => ngayViet = value;
        }

        public int Loai
        {
            get => loai;
            set => loai = value;
        }

        public TinTuc GetTinTuc(MySqlDataReader reader)
        {
            TinTuc tinTuc = new TinTuc();
            tinTuc.MaTinTuc = reader.GetInt16("id");
            tinTuc.TieuDe = reader.GetString("tieude");
            tinTuc.AnhMoTa = reader.GetString("anhmota");
            tinTuc.MoTa = reader.GetString("mota");
            tinTuc.NoiDung = reader.GetString("noidung");
            tinTuc.NgayViet = reader.GetString("ngayviet");
            tinTuc.Loai = reader.GetInt16("loai");
            return tinTuc;
        }
    }
}