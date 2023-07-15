using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class Security
    {
        public static string SHA256(string clearText)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.UTF8.GetBytes(clearText);
            var algo = HashAlgorithm.Create(nameof(SHA256));
            var hash = algo!.ComputeHash(bytes);
            foreach (var byt in hash)
                sb.Append(byt.ToString("x2"));
            return sb.ToString();
        }
    }
}
