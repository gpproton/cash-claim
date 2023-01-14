using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.CurrencyModule;

public class CurrencyModule : IModule {

    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<CurrencyService>();

        return services;
    }
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "currency";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async (CurrencyService sv, [AsParameters] GenericFilter filter) =>
        await sv.GetAllAsync(filter))
        .WithName($"GetAll{name}")
        .WithOpenApi();
        
        group.MapGet("/{id:guid}", async (Guid id, CurrencyService sv) => {
            var result = await sv.GetByIdAsync(id);
            return TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        group.MapPost("/", async (CurrencyResponse value, CurrencyService sv) => {
            await sv.CreateAsync(value);
            return TypedResults.Created($"{url}/{value.Id}", value);
        }).WithName($"Create{name}").WithOpenApi();

        group.MapPut("/", async (CurrencyResponse value, CurrencyService sv) => {
            var result = await sv.UpdateAsync(value);
            return result is null ? Results.NotFound() : TypedResults.Ok(value);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, CurrencyService sv) => {
            var item = await sv.DeleteAsync(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();

        return group;
    }
}