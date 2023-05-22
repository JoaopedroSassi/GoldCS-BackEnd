using Npgsql;

namespace src.Extensions
{
	public static class ConnectionExtension
    {
		public static string GetConnectionString(string connectionString)
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
			System.Console.WriteLine("DATABASE_URL");
			System.Console.WriteLine(databaseUrl);
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        public static string BuildConnectionString(string connectionString)
        {
            var databaseUri = new Uri(connectionString);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }       
    }
}