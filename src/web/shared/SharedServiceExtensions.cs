using Axolotl.Http;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace XClaim.Web.Shared;

public static class SharedServiceExtensions {
    public static IServiceCollection RegisterSharedBlazorServices(this IServiceCollection services) {
        services.AddBlazoredSessionStorage();
        services.AddScoped<IHttpService, HttpService>();
        services.AddScoped<AuthenticationStateProvider, AuthProvider>();
        services.AddAuthorizationCore();

        return services;
    }
}