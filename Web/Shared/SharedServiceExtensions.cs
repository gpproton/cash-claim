using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using CashClaim.Common.Service;
using CashClaim.Web.Shared.States;

namespace CashClaim.Web.Shared;

public static class SharedServiceExtensions {
    public static IServiceCollection UseSharedExtensions(this IServiceCollection services) {
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