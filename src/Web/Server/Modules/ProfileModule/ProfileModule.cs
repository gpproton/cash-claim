using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Helpers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IProfileService, ProfileService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Profile";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/account", async (IdentityHelper identity, UserService user) => {
            var authProfile = await identity.GetAuthProfile();
            if (!identity.IsAuthenticated) return TypedResults.Unauthorized();
            
            var account = (await user.GetByIdentifierAsync(authProfile!.Data!.Identifier)).Data;
            if (account != null) {
                authProfile!.Data = account;
                authProfile.Confirmed = true;
            }
            var role = account?.Permission != null ? Enum.GetName(account.Permission)! : Enum.GetName(UserPermission.Standard)!;
            authProfile.Role = role;

            return Results.Ok(new Response<AuthResponse?>(authProfile) { Succeeded = authProfile.ExpiresIn > 0 });
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