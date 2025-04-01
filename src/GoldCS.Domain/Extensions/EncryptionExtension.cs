using static BCrypt.Net.BCrypt;

namespace GoldCS.Domain.Extensions
{
    public static class EncryptionExtension
    {
        private const int WorkFactor = 12;

        public static string CodifyPassword(string password)
        {
            return HashPassword(password, WorkFactor);
        }

        public static bool ComparePassword(string password, string hash)
        {
            return Verify(password, hash);
        }
    }
}
