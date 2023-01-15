using Microsoft.Extensions.DependencyInjection;

namespace XClaim.Common.HTTP;

public static class HttpServiceExtensions {
    public static IServiceCollection UseHttpServices(this IServiceCollection services) {
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IBankService, BankService>();
        
        return services;
    }
}