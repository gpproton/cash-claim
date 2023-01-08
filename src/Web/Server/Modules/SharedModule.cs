using XClaim.Common.Base;

namespace XClaim.Web.Server.Modules;

public class SharedModule : IModule{
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}