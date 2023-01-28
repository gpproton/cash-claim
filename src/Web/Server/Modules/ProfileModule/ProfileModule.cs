using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Helpers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {

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
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}