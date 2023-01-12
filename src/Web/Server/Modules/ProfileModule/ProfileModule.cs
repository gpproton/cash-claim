using System.Net;
using System.Security.Claims;
using Newtonsoft.Json;
using Nextended.Core.Extensions;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Profile";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/account", async (context) => {
            bool isAuth = context.User.Identity?.IsAuthenticated ?? false;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            if (!isAuth || email.IsNullOrEmpty()) {
                await context.Response.WriteAsJsonAsync(
                    new AuthResponse(false, null, 0)
                );
                return;
            }

            var fullName = context.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
            var phone = context.User.FindFirst(ClaimTypes.MobilePhone)?.Value ?? "";

            var names = fullName.Split(" ");
            var profile = new Common.Dtos.ProfileResponse(email!, names[0], names[^1], phone);

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var expiry = DateTime.Now.AddHours(24);
            await context.Response.WriteAsJsonAsync(
                new AuthResponse(false, expiry, 0, null, "Success", Data: profile)
                );
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}