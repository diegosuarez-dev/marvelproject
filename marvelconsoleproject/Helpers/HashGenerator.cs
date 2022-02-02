using System;
using System.Security.Cryptography;
using System.Text;

namespace marvelconsoleproject.Helpers
{
    class HashGenerator
    {
        public HashGenerator()
        {
            timeStamp = DateTime.Now.ToString();
            toHash = timeStamp + PRIVATEKEY + APIKEY;
        }

        public string GetHash()
        {
            var sBuilder = new StringBuilder();
            using(MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(toHash));

                foreach (var el in data)
                {
                    sBuilder.Append(el.ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }

        private const string PRIVATEKEY = "beda6a3247b264c3d7153e152717963a145a1af1";
        public const string APIKEY = "d3f40772ae90a6c7c883554580b72df4";
        public string timeStamp;
        private string toHash;
    }
}
