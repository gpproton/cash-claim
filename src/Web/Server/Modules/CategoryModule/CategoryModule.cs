using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<ICategoryRepository, CategoryService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup("/api/v1/category").WithTags("Category");
        
        group.MapGet("/", async (ICategoryRepository sv, IMapper mapper) => {
                var result = await sv.GetAll();
                return mapper.Map<List<Category>>(result);
            })
            .WithName("GetAllCategories")
            .WithOpenApi();
        
        group.MapGet("/{id:guid}", async (Guid id, ICategoryRepository sv, IMapper mapper) => {
                var result = await sv.GetById(id);
                return result is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<Category>(result));
            })
            .WithName("GetCategoryById").WithOpenApi();

        group.MapPost("/", async (Category category, ICategoryRepository sv, IMapper mapper) => {
                var value = mapper.Map<CategoryEntity>(category);
                await sv.Create(value);
                return TypedResults.Created($"/api/v1/category/{category.Id}", category);
            })
            .WithName("CreateCategory").WithOpenApi();

        group.MapPut("/{id:guid}", async (Guid id, Category category, ICategoryRepository sv, IMapper mapper) => {
            var value = mapper.Map<CategoryEntity>(category);
            var result = await sv.Modify(id, value);
            return result is null ? Results.NotFound() : TypedResults.Ok(category);
        }).WithName("UpdateCategory").WithOpenApi();
        
        group.MapDelete("/{id:guid}", async (Guid id, ICategoryRepository sv, IMapper mapper) => {
            var item = await sv.Delete(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<Category>(item));
        }).WithName("ArchiveCategory").WithOpenApi();

        return group;
    }
}