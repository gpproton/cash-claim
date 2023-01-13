using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using XClaim.Common.Service;
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
        services.AddScoped<AuthenticationHandler>();

        // HTTP Services
        services.AddScoped<IProfileService, ProfileService>();

        return services;
    }
}