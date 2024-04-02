using CashClaim.Service.Data;
using CashClaim.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CashClaim.Service.Extensions;

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