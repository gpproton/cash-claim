using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserModule : IModule {
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup("/api/v1/user").WithTags("Users");

        group.MapGet("/", async (IUserRepository sv) => await sv.GetAll())
            .WithName("GetAllUsers")
            .WithOpenApi();

        return group;
    }

    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}