using Microsoft.Extensions.DependencyInjection;
using XClaim.Common.Extensions;

namespace XClaim.Common.HTTP;

public static class HttpServiceExtensions {
    public static IServiceCollection UseHttpServices(this IServiceCollection services) {
        services.AddLazyResolution();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<IDomainService, DomainService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IServerService, ServerService>();
        services.AddScoped<IProfileService, ProfileService>();

        return services;
    }
}