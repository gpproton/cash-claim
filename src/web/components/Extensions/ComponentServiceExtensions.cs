using Microsoft.Extensions.DependencyInjection;
using XClaim.Web.Components.States;

namespace XClaim.Web.Components.Extensions;

public static class ComponentServiceExtensions {
    public static IServiceCollection RegisterComponentsExtensions(this IServiceCollection services) {
        services.AddSingleton<Navigation>();

        return services;
    }

    public static IServiceCollection RegisterAppState(this IServiceCollection services) {
        services.AddScoped<AppState>();
        services.AddScoped<ThemeState>();
        services.AddScoped<AuthState>();

        return services;
    }
}