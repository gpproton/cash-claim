// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.EntityFrameworkCore;
using XClaim.Common.Context;
using static XClaim.Service.Data.Provider;

namespace XClaim.Service.Data;

public static class DatabaseExtensions {
    public static IServiceCollection RegisterDataContext(this IServiceCollection services) {
        ServiceProvider sp = services.BuildServiceProvider();
        IConfiguration? config = sp.GetService<IConfiguration>();
        string provider = (config!.GetValue<string>("provider") ?? Sqlite.Name).ToLower();
        string? defaultConfig = config!.GetConnectionString("Default");

        services.AddDbContext<ServiceContext>(options => {
            options.UseSnakeCaseNamingConvention();

            if (provider.Contains(Sqlite.Name, StringComparison.CurrentCultureIgnoreCase)) {
                string? sqliteString = defaultConfig ?? config!.GetConnectionString(Sqlite.Name);
                options.UseSqlite(sqliteString,
                    x => x.MigrationsAssembly(Sqlite.Assembly).UseRelationalNulls());
            }

            if (provider.Contains(Postgres.Name, StringComparison.CurrentCultureIgnoreCase)) {
                string? postgresString = defaultConfig ?? config!.GetConnectionString(Postgres.Name);
                options.UseNpgsql(postgresString,
                    x => x.MigrationsAssembly(Postgres.Assembly).UseRelationalNulls());
            }
        });

        return services;
    }
}