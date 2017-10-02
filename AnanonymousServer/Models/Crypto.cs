using System.Security.Cryptography;
using System.Text;

namespace AnanonymousServer.Models
{
    public static class Crypto
    {
        public static string GetMd5Hash(string input)
        {
            var sBuilder = new StringBuilder();
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }
    }
}
