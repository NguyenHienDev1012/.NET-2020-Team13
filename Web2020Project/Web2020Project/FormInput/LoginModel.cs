namespace Web2020Project.FormInteract
{
    public class LoginModel
    {
        private string usrname;
        private string password;

        public string Usrname
        {
            get => usrname;
            set => usrname = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}