namespace Web2020Project.Model
{
    public class ThanhVienModel
    {
        private string usr_name;
        private string password;
        private string c_password;
        private string full_name;
        private string gender;
        private string email;
        private string sdt;
        private string address;

        public string UsrName
        {
            get => usr_name;
            set => usr_name = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string CPassword
        {
            get => c_password;
            set => c_password = value;
        }

        public string FullName
        {
            get => full_name;
            set => full_name = value;
        }

        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Sdt
        {
            get => sdt;
            set => sdt = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }
    }

}