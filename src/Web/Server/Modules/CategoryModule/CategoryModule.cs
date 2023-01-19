using Microsoft.AspNetCore.Mvc;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<CategoryService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Category";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async ([FromServices] CategoryService sv, [AsParameters] CategoryFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, CategoryService sv) => {
            var result = await sv.GetByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        group.MapPost("/", async (CategoryResponse value, CategoryService sv) => {
            var response = await sv.CreateAsync(value);
            return TypedResults.Created($"{url}/{value.Id}", response);
        }).WithName($"Create{name}").WithOpenApi();

        group.MapPut("/", async (CategoryResponse value, CategoryService sv) => {
            var result = await sv.UpdateAsync(value);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, CategoryService sv) => {
            var item = await sv.DeleteAsync(id);
            return !item.Succeeded ? Results.NotFound(item) : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();
        
        group.MapDelete("/", async ([FromBody] List<Guid> ids, CategoryService sv) => {
            var items = await sv.DeleteRangeAsync(ids);
            return !items.Succeeded ? Results.NotFound(items) : TypedResults.Ok(items);
        }).WithName($"RangeArchive{name}").WithOpenApi();

        return group;
    }
}