using Npgsql;

namespace Collections.Web.Configuration.Connection;

public class DbConnectionHelper
{
    public static string GetConnectionString(IConfiguration configuration)
    {
#if DEBUG
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                               throw new ApplicationException("Connection string is not defined!");
        return connectionString;
#else
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        return BuildConnectionString(databaseUrl);
#endif
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