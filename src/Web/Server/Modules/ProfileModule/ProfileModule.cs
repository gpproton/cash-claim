using System.Net;
using System.Security.Claims;
using Newtonsoft.Json;
using Nextended.Core.Extensions;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileModule : IModule {
    record ProfileResponse(bool Valid = false, string Message = "", Common.Dtos.ProfileResponse? Data = null);

    public IServiceCollection RegisterApiModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Profile";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/account", async (context) => {
            bool isAuth = context.User.Identity?.IsAuthenticated ?? false;
            if (!isAuth) {
                await context.Response.WriteAsJsonAsync(
                    new ProfileResponse(false, "Not Authenticated", null)
                );
                return;
            }

            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            var fullName = context.User.FindFirst(ClaimTypes.Name)?.Value;
            var phone = context.User.FindFirst(ClaimTypes.MobilePhone)?.Value;

            if (email.IsNullOrEmpty() || fullName is null) {
                await context.Response.WriteAsJsonAsync(
                    new ProfileResponse(false, "Email address is invalid", null)
                );
                return;
            }
            
            var names = fullName.Split(" ");
            var profile = new Common.Dtos.ProfileResponse(email!, names[0], names[^1], phone!);
            
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            await context.Response.WriteAsJsonAsync(
                new ProfileResponse(false, "Success", profile)
                );
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}