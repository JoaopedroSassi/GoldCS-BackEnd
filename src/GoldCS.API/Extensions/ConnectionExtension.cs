using Npgsql;

namespace src.Extensions
{
	public static class ConnectionExtension
    {
		public static string GetConnectionString(string connectionString)
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
			
			if (Environment.GetEnvironmentVariable("HOST") == "RAILWAY")
			{
				return BuildConnectionStringRailway(databaseUrl);
			}
			else if (Environment.GetEnvironmentVariable("HOST") == "RENDER")
			{
				return BuildConnectionStringRender(databaseUrl);
			}
			else
			{
				return BuildConnectionStringLocal(connectionString);
			}
        }

        public static string BuildConnectionStringRailway(string connectionString)
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
			System.Console.WriteLine("CONNECTED - RAILWAY");
            return builder.ToString();
        }    

		public static string BuildConnectionStringRender(string connectionString)
        {
            var databaseUri = new Uri(connectionString);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
			System.Console.WriteLine("CONNECTED - RENDER");
            return builder.ToString();
        }

		public static string BuildConnectionStringLocal(string connectionString)
		{
			System.Console.WriteLine("CONNECTED - LOCAL");
            return connectionString;
		}     
    }
}