using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UFMT.SIGED.Infra.CrossCuting
{
    public class CriptografiaSHA256
    {

        public static string GeraHashSHA256(string value)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return value = String.Concat(hash
                              .ComputeHash(Encoding.UTF8.GetBytes(value))
                              .Select(item => item.ToString("x2")));
            }
        }
    }
}
