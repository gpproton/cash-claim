using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Modules;

public class SharedModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        endpoints.MapHealthChecks("/health", new HealthCheckOptions() {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        endpoints.MapHealthChecksUI(setup => {
            setup.UIPath = "/health";
            setup.ApiPath = "/health/api";
        });

        return endpoints;
    }
}