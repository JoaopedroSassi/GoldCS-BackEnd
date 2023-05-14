using Npgsql;

namespace src.Extensions
{
	public static class ConnectionExtension
    {
        public static string GetConnectionString(string connectionString)
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
			if (string.IsNullOrEmpty(databaseUrl))
				Console.WriteLine("NÃO TÁ PEGANDO A STRING DE CONEX");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
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