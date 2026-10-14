using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NT106_GROUP10
{
    public static class DbConfig
    {
        public static string ConnectionString = @"Server=localhost,1433;Database=NT106_GROUP10_DB;User Id=sa;Password=Sonvo2007;Encrypt=True;TrustServerCertificate=True;";
    }

    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
