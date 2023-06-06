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
                var provider = config!.GetValue("provider", Sqlite.Name);

                if (provider == Sqlite.Name) {
                    options.UseSqlite(config!.GetConnectionString(Sqlite.Name)!, x => x.MigrationsAssembly(Sqlite.Assembly).UseRelationalNulls());
                }

                if (provider == Postgres.Name) {
                    options.UseNpgsql(config!.GetConnectionString(Postgres.Name)!,  x => x.MigrationsAssembly(Postgres.Assembly).UseRelationalNulls());
                }

                if (provider == Mysql.Name) {
                    var connectionString = config!.GetConnectionString(Postgres.Name)!;
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly(Mysql.Assembly).UseRelationalNulls());
                }
            }
        );

        return services;
    }
}