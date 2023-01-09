using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<ClaimService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = nameof(Claim);
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);
            
        group.MapGet("/", async (ClaimService sv, [AsParameters] ClaimFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();
            
        group.MapGet("/{id:guid}", async (Guid id, ClaimService sv) => {
            var result = await sv.GetByIdAsync(id);
            return TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();
            
        group.MapPost("/", async (Claim value, ClaimService sv) => {
            await sv.CreateAsync(value);
            return TypedResults.Created($"{url}/{value.Id}", value);
        }).WithName($"Create{name}").WithOpenApi();
            
        group.MapPut("/", async (Claim value, ClaimService sv) => {
            var result = await sv.UpdateAsync(value);
            return result is null ? Results.NotFound() : TypedResults.Ok(value);
        }).WithName($"Update{name}").WithOpenApi();
        
        group.MapDelete("/{id:guid}", async (Guid id, ClaimService sv) => {
            var item = await sv.DeleteAsync(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();

        return group;
    }
}