using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<ICategoryRepository, CategoryService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup($"{Constants.RootApi}/category").WithTags(nameof(Category));

        group.MapGet("/", async (ICategoryRepository sv) => await sv.GetAll())
            .WithName("GetAllCategories")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, ICategoryRepository sv) => {
            var result = await sv.GetById(id);
            return result is null ? Results.NotFound() : TypedResults.Ok(result);
        })
            .WithName("GetCategoryById").WithOpenApi();

        group.MapPost("/", async (Category category, ICategoryRepository sv) => {
            await sv.Create(category);
            return TypedResults.Created($"/api/v1/category/{category.Id}", category);
        })
            .WithName("CreateCategory").WithOpenApi();

        group.MapPut("/", async (Category category, ICategoryRepository sv) => {
            var result = await sv.Modify(category);
            return result is null ? Results.NotFound() : TypedResults.Ok(category);
        }).WithName("UpdateCategory").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, ICategoryRepository sv) => {
            var item = await sv.Delete(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(item);
        }).WithName("ArchiveCategory").WithOpenApi();

        return group;
    }
}