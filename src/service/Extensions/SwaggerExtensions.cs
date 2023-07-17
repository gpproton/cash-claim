// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.OpenApi.Models;
using XClaim.Service.Helpers;

namespace XClaim.Service.Extensions;

public static class SwaggerExtensions {
    public static IServiceCollection RegisterSwaggerService(this IServiceCollection services) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt => {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = $"x-claim", Version = "v1" });
            opt.OperationFilter<FileUploadOperationFilter>();
        });

        return services;
    }

    public static WebApplication RegisterSwaggerService(this WebApplication app) {
        const string swaggerTittle = "x-claim V1";
        const string swaggerPath = "/swagger/v1/swagger.json";
        app.UseReDoc(c => {
            c.DocumentTitle = swaggerTittle;
            c.SpecUrl(swaggerPath);
        });

        if (!app.Environment.IsDevelopment()) {
            return app;
        }

        app.UseSwagger();
        app.UseSwaggerUI(opt => {
            opt.SwaggerEndpoint(swaggerPath, swaggerTittle);
            opt.DefaultModelExpandDepth(3);
            opt.EnableDeepLinking();
            opt.DisplayRequestDuration();
            opt.ShowExtensions();
        });

        return app;
    }
}