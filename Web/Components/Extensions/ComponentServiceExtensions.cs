using Microsoft.Extensions.DependencyInjection;

namespace CashClaim.Web.Components.Extensions;

public static class ComponentServiceExtensions {
    public static IServiceCollection UseComponentsExtensions(this IServiceCollection services) {
        services.AddSingleton<Navigation>();

        return services;
    }
}