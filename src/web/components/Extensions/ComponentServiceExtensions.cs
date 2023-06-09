using Microsoft.Extensions.DependencyInjection;

namespace XClaim.Web.Components.Extensions {
    public static class ComponentServiceExtensions {
        public static IServiceCollection UseComponentsExtensions(this IServiceCollection services) {
            services.AddSingleton<Navigation>();

            return services;
        }
    }
}