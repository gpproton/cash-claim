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
        var sp = services.BuildServiceProvider();
        var config = sp.GetService<IConfiguration>();

        services.AddDbContext<ServiceContext>(options => {
                options.UseSnakeCaseNamingConvention();
                var provider = (config!.GetValue<string>("provider") ?? Sqlite.Name).ToLower();
                if (provider == Sqlite.Name.ToLower()) {
                    var mysql = config!.GetConnectionString(Sqlite.Name)!;
                    options.UseSqlite(mysql, x => x.MigrationsAssembly(Sqlite.Assembly).UseRelationalNulls());
                    return;
                }

                if (provider == Postgres.Name.ToLower()) {
                    var postgres = config!.GetConnectionString(Postgres.Name)!;
                    options.UseNpgsql(postgres,  x => x.MigrationsAssembly(Postgres.Assembly).UseRelationalNulls());
                    return;
                }

                if (provider == Mysql.Name.ToLower()) {
                    var connectionString = config!.GetConnectionString(Mysql.Name)!;
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly(Mysql.Assembly).UseRelationalNulls());
                }
            }
        );

        return services;
    }
}