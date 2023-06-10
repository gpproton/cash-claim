using Axolotl.Http;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using XClaim.Web.Shared.States;

namespace XClaim.Web.Shared;

public static class SharedServiceExtensions {
    public static IServiceCollection RegisterSharedBlazorServices(this IServiceCollection services) {
        services.AddMudServices();
        services.AddBlazoredSessionStorage();
        services.AddScoped<IHttpService, HttpService>();
        services.AddScoped<AuthenticationStateProvider, AuthProvider>();
        services.AddAuthorizationCore();

        // App States
        services.AddSingleton<AppState>();
        services.AddSingleton<ThemeState>();
        services.AddScoped<AuthState>();

        return services;
    }
}