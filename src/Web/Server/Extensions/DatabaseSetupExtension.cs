using Microsoft.EntityFrameworkCore;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Extensions;

public static class DatabaseSetupExtension {
    public static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration config) {
        var configType = Environment.GetEnvironmentVariable("DB_TYPE") ?? config.GetValue<string?>("DbType") ?? "sqlite";
        var configConnection = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? config.GetConnectionString("Default");
        Enum.TryParse(configType, true, out DatabaseType type);

        services.AddDbContext<ServerContext>(options => {
            switch (type) {
                case DatabaseType.Postgres:
                    options.UseNpgsql(configConnection);
                    break;
                case DatabaseType.Mysql:
                    options.UseMySql(configConnection, new MySqlServerVersion(new Version(8, 0, 29)));
                    break;
                case DatabaseType.Sqlite:
                default:
                    options.UseSqlite(configConnection);
                    break;
            }

            options.UseSnakeCaseNamingConvention()
            .LogTo(Console.WriteLine, LogLevel.Information)
            // .EnableSensitiveDataLogging();
            .EnableDetailedErrors();
        });

        return services;
    }
}