using Microsoft.Extensions.DependencyInjection;

namespace CashClaim.Common.Extensions;

public static class LazyResolutionExtension {
    public static IServiceCollection AddLazyResolution(this IServiceCollection services)
    {
        return services.AddTransient(
            typeof(Lazy<>),
            typeof(LazilyResolved<>));
    }

    private class LazilyResolved<T> : Lazy<T> where T : notnull {
        public LazilyResolved(IServiceProvider serviceProvider)
        : base(serviceProvider.GetRequiredService<T>)
        {
        }
    }
}