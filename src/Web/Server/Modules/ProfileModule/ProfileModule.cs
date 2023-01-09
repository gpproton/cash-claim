using System.Security.Claims;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Profile";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/account", (context) => {
        bool isAuth = context.User.Identity?.IsAuthenticated ?? false;
        if (!isAuth) return context.Response.WriteAsync("None");
            
        var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
        var fullName = context.User.FindFirst(ClaimTypes.Name)?.Value;
        var phone = context.User.FindFirst(ClaimTypes.MobilePhone)?.Value;

        if (email is null) {
            context.Response.Redirect("/");
        }
        
        return context.Response.WriteAsJsonAsync(new Profile(email!, fullName, phone, UserPermission.Standard));
        
        }).WithName("AccountProfile").WithOpenApi();

        return group;
    }
}