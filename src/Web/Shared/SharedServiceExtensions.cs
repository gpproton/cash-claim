using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using XClaim.Web.Shared.States;

namespace XClaim.Web.Shared;

public static class SharedServiceExtensions {
    public static IServiceCollection UseSharedExtensions(this IServiceCollection services) {
        services.AddMudServices();
        services.AddBlazoredSessionStorage();
        services.AddSingleton<AppState>();
        services.AddSingleton<ThemeState>();
        services.AddScoped<AuthenticationStateProvider, AuthProvider>();
        services.AddAuthorizationCore();

        return services;
    }
}