using ShopChain.Application.Commons;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace ShopChain.Infrastructure.Security
{
    public class Sha256PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                var shaHash = Convert.ToBase64String(hash);

                return BCrypt.Net.BCrypt.HashPassword(shaHash);
            }
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            using(var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                var shaHash = Convert.ToBase64String(hash);

                return BCrypt.Net.BCrypt.Verify(shaHash, passwordHash);
            }
        }
    }
}
