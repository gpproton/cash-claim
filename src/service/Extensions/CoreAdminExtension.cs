// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using DotNetEd.CoreAdmin;

namespace XClaim.Service.Extensions;

public static class CoreAdminExtension {
    public static IServiceCollection RegisterCoreAdmin(this IServiceCollection services) {
        #if DEBUG
        services.AddCoreAdmin(new CoreAdminOptions {
            Title = "x-claim",
            ShowPageSizes = true,
            PageSizes = new Dictionary<int, string>() {
                { 25, "25" },
                { 100, "100" },
                { 0, "All" }
            },
            IgnoreEntityTypes = new List<Type> ()
        });
        #endif

        return services;
    }

    public static WebApplication RegisterCoreAdmin(this WebApplication app) {
        #if DEBUG
        app.UseCoreAdminCustomUrl("admin");
        app.UseCoreAdminCustomAuth((_) => Task.FromResult(true));
        #endif

        return app;
    }
}