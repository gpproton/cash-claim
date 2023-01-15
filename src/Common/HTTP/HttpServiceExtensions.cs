using Microsoft.Extensions.DependencyInjection;

namespace XClaim.Common.HTTP;

public static class HttpServiceExtensions {
    public static IServiceCollection UseHttpServices(this IServiceCollection services) {
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
        
        return services;
    }
}