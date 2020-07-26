namespace Web2020Project.Models.MODEL
{
    public class TinTuc
    {
        private int maTinTuc;
        private string tieuDe;
        private string anhMoTa;
        private string moTa;
        private string ngayViet;
        private string noiDung;
        private int loai;

        public TinTuc()
        {
        }

        public TinTuc(int maTinTuc, string tieuDe, string anhMoTa, string moTa, string ngayViet, string noiDung, int loai)
        {
            this.maTinTuc = maTinTuc;
            this.tieuDe = tieuDe;
            this.anhMoTa = anhMoTa;
            this.moTa = moTa;
            this.ngayViet = ngayViet;
            this.noiDung = noiDung;
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

        public override string ToString()
        {
            return "TinTuc{" +
                   "maTinTuc=" + maTinTuc +
                   ", tieuDe='" + tieuDe + '\'' +
                   ", moTa='" + moTa + '\'' +
                   ", anhMoTa='" + anhMoTa + '\'' +
                   ", noiDung='" + noiDung + '\'' +
                   ", ngayViet='" + ngayViet + '\'' +
                   ", loai=" + loai +
                   '}';
        }
    }
}