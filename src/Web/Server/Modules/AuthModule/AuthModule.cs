using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;
using Nextended.Core.Extensions;

namespace XClaim.Web.Server.Modules.AuthModule;

public class AuthModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Authentication";
        var url = $"{Constants.RootApi}/auth";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/sign-in", ([FromQuery] string? redirect) => {
            // TODO: use config or default host URL
            const string redirectConfig = "http://localhost:7001/api/v1/profile/account";
            var redirectValue = redirect.IsNullOrEmpty() ? redirectConfig : redirect;
            var props = new AuthenticationProperties {
                IsPersistent = true,
                RedirectUri = redirectValue
            };

            return Results.Challenge(props, new[] { MicrosoftAccountDefaults.AuthenticationScheme });
        }).WithName("SignIn")
            .WithOpenApi();

        group.MapGet("/sign-out", async context => {
            await context.SignOutAsync();

            Results.Redirect("/");
        }).WithName("SignOut")
            .WithOpenApi();

        return group;
    }
}