using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.ServerModule;

public class ServerModule : IModule {

    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IServerService, ServerService>();

        return services;
    }
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Server";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);
        
        group.MapGet("/", async (IServerService sv)
        => await sv.GetAsync()).WithName($"Get{name}").WithOpenApi();
        
        group.MapPut("/", async (ServerResponse value, IServerService sv) => {
            var result = await sv.UpdateAsync(value);
            return TypedResults.Ok(result);
        }).WithName($"Update{name}").WithOpenApi();

        return group;
    }
}