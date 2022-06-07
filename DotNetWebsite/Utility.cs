using System.Security.Cryptography;
using System.Text;

namespace DotNetWebsite
{
    public static class Utility
    {

        public static string ComputeSha256Hash(string input)
        {
            using SHA256 hash = SHA256.Create();

            byte[] buffer = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(buffer).Replace("-", string.Empty);
        }

    }
}
