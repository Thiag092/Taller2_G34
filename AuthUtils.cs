using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

//esto es para el hash de las contraseñas
namespace Taller2_G34
{
    public static class AuthUtils
    {
        public static string HashSHA256(string plainText)
        {
            if (plainText == null) plainText = "";
            using (var sha = SHA256.Create())
            {
                // ANTES: Encoding.UTF8
                byte[] bytes = Encoding.Unicode.GetBytes(plainText); // UTF-16 LE para matchear SQL
                byte[] hash = sha.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash) sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}