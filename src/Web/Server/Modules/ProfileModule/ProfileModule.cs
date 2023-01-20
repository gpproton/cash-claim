using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using XClaim.Common.Dtos;
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
            bool isAuth = request.HttpContext.User.Identity?.IsAuthenticated ?? false;
            
            if (!isAuth) return Results.Unauthorized();
            var auth = await request.HttpContext.AuthenticateAsync("Microsoft");
            var email = request.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "";
            var role = request.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value ?? "";
            var fullName = request.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
            var phone = request.HttpContext.User.FindFirst(ClaimTypes.MobilePhone)?.Value ?? "";
            var names = fullName.Split(" ");
            var token = auth?.Properties?.GetTokenValue("access_token");
            var expiry = (auth?.Properties?.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToDateTimeFromEpoch();
            var expireIn = (int)expiry.Subtract(DateTime.Now).TotalSeconds;

            ProfileResponse? profile;
            var account = (await user.GetByEmailAsync(email)).Data;

            if (account is null) {
                profile = new ProfileResponse {
                    Email = email,
                    FirstName = names[0],
                    LastName = names[^1],
                    Phone = phone
                };
            } else {
                profile = new ProfileResponse {
                    Email = account.Email,
                    FirstName = account.FirstName,
                    LastName = account.LastName ,
                    Phone = account.LastName,
                    Permission = account.Permission,
                    Balance = account.Balance,
                    Team = account.Team
                };
            }

            var response = new AuthResponse {
                Confirmed = false,
                ExpiryTimeStamp = expiry,
                ExpiresIn = expireIn,
                Token = token,
                Role = role,
                Message = "Success",
                Data = profile,
                UserName = fullName
            };
            
             return Results.Ok(response);
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}