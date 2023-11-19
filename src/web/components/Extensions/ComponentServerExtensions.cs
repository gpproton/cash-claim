using Microsoft.Extensions.DependencyInjection;
using XClaim.Web.Components.States;

namespace XClaim.Web.Components.Extensions;

public static class ComponentServerExtensions {
    public static IServiceCollection RegisterServerRazorExtensions(this IServiceCollection services) {
        services.AddScoped<Navigation>();

        return services;
    }

    public static IServiceCollection RegisterServerBlazorState(this IServiceCollection services) {
        services.AddScoped<AppState>();
        // services.AddScoped<AuthState>();
        // services.AddScoped<ThemeState>();

        return services;
    }
}