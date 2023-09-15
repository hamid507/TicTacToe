using System.Security.Cryptography;

namespace TicTacToeSharedLib.Utility
{
    public static class CryptoHelper
    {

        public static string HashPassword(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes for a 256-bit key
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool ComparePasswords(string enteredPassword, string storedHash, string salt)
        {
            string computedHash = HashPassword(enteredPassword, salt);
            return computedHash == storedHash;
        }

        public static string GenerateSalt(int sizeInBytes = 16)
        {
            byte[] saltBytes = new byte[sizeInBytes];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
