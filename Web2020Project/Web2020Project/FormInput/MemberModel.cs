namespace Web2020Project.Model
{
    public class MemberModel
    {
        private string userName;
        private string password;
        private string c_password;
        private string name;
        private string gender;
        private string email;
        private string phone;
        private string address;
        private int level;

        public string UserName
        {
            get => userName;
            set => userName = value;
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

        public string Name
        {
            get => name;
            set => name = value;
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

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }
    }

}