namespace XClaim.Web.Server.Modules.EventModule;

public class EventModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<EventService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Event";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async (EventService sv, [AsParameters] EventFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, EventService sv) => {
            var result = await sv.GetByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        return group;
    }
}