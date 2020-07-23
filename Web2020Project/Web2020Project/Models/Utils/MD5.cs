namespace Web2020Project.Models.Utils
{
    public class MD5
    {
        private string MD5(string txt)
        {
            string str = "";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (byte b in buffer)
            {
                str += b.ToString("X2");
            }

            return str;
        }
    }
}