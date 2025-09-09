using static BCrypt.Net.BCrypt;

namespace src.Extensions
{
	public static class CryptoExtension
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