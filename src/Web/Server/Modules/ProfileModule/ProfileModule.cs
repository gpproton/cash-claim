using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;
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

        group.MapGet("/account", async (HttpRequest request, UserService user) => {
            var userContext = request.HttpContext.User;
            bool isAuth = userContext.Identity?.IsAuthenticated ?? false;
            if (!isAuth) return TypedResults.Unauthorized();
            
            var auth = await request.HttpContext.AuthenticateAsync("Microsoft");
            var email = userContext.FindFirst(ClaimTypes.Email)?.Value ?? "";
            var fullName = userContext.FindFirst(ClaimTypes.Name)?.Value ?? "";
            var phone = userContext.FindFirst(ClaimTypes.HomePhone)?.Value ?? "";
            var names = fullName.Split(" ");
            var token = auth?.Properties?.GetTokenValue("access_token");
            var expiry = (auth?.Properties?.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToDateTimeFromEpoch();
            var expireIn = (int)expiry.Subtract(DateTime.Now).TotalSeconds;

            UserResponse? profile = new UserResponse();
            var account = (await user.GetByEmailAsync(email)).Data;
            if (account == null) {
                profile.Email = email;
                profile.FirstName = names[0];
                profile.LastName = names[^1];
                profile.Phone = phone;
            } else {
                profile = account;
            }
            
            var role = account?.Permission != null ?
                       account.Permission.ToString() : userContext.FindFirst(ClaimTypes.Role)?.Value ?? UserPermission.Standard.ToString();

            return Results.Ok(new Response<AuthResponse?>(new AuthResponse {
                Confirmed = account != null,
                ExpiryTimeStamp = expiry,
                ExpiresIn = expireIn,
                Token = token,
                Role = role,
                Message = "Success",
                Data = profile,
                UserName = fullName
            }) { Succeeded = expireIn > 0 });
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}