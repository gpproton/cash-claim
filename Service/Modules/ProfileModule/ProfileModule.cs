using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using CashClaim.Common.Wrappers;
using CashClaim.Service.Helpers;
using CashClaim.Service.Modules.UserModule;

namespace CashClaim.Service.Modules.ProfileModule;

public class ProfileModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IProfileService, ProfileService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Profile";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/account", async (IProfileService sv) => {
            var result = await sv.GetAccountAsync();
            return !result.Succeeded ? Results.Unauthorized() : TypedResults.Ok(result);
        }).WithName("GetAccountAuth").WithOpenApi();
        
        group.MapGet("/bank-account", async (IProfileService sv)
            => await sv.GetBankAccountAsync()).WithName("GetBankAccountSetting").WithOpenApi();
        
        group.MapPut("/bank-account", async (BankAccountResponse value, IProfileService sv) => {
            var result = await sv.UpdateBankAccountAsync(value);
            return !result.Succeeded ? Results.BadRequest(result) : TypedResults.Ok(result);
        }).WithName($"UpdateBankAccountSetting").WithOpenApi();
        
        group.MapGet("/setting", async (IProfileService sv)
        => await sv.GetSettingAsync()).WithName("GetUserSetting").WithOpenApi();
        
        group.MapPut("/setting", async (SettingResponse value, IProfileService sv) => {
            var result = await sv.UpdateSettingAsync(value);
            return !result.Succeeded ? Results.BadRequest(result) : TypedResults.Ok(result);
        }).WithName($"UpdateUserSetting").WithOpenApi();
        
        group.MapGet("/notification", async (IProfileService sv)
        => await sv.GetNotificationAsync()).WithName("GetNotificationSetting").WithOpenApi();
        
        group.MapPut("/notification", async (NotificationResponse value, IProfileService sv) => {
            var result = await sv.UpdateNotificationAsync(value);
            return !result.Succeeded ? Results.BadRequest(result) : TypedResults.Ok(result);
        }).WithName($"UpdateNotificationSetting").WithOpenApi();

        return group;
    }
}