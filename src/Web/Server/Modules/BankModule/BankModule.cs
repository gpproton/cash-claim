using Microsoft.AspNetCore.Mvc;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Filters;

namespace XClaim.Web.Server.Modules.BankModule {

    public class BankModule : IModule {
        public IServiceCollection RegisterApiModule(IServiceCollection services) {
            services.AddScoped<BankService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
            const string name = "Bank";
            var url = $"{Constants.RootApi}/{name.ToLower()}";
            var group = endpoints.MapGroup(url).WithTags(name);

            group.MapGet("/", async (BankService sv, [AsParameters] BankFilter filter) =>
                    await sv.GetAllAsync(filter))
                .WithName($"GetAll{name}")
                .WithOpenApi();

            group.MapGet("/{id:guid}", async (Guid id, BankService sv) => {
                var result = await sv.GetByIdAsync(id);
                return TypedResults.Ok(result);
            }).WithName($"Get{name}ById").WithOpenApi();

            group.MapPost("/", async (BankResponse value, BankService sv) => {
                await sv.CreateAsync(value);
                return TypedResults.Created($"{url}/{value.Id}", value);
            }).WithName($"Create{name}").WithOpenApi();

            group.MapPut("/", async (BankResponse value, BankService sv) => {
                var result = await sv.UpdateAsync(value);
                return result is null ? Results.NotFound() : TypedResults.Ok(value);
            }).WithName($"Update{name}").WithOpenApi();

            group.MapDelete("/{id:guid}", async (Guid id, BankService sv) => {
                var item = await sv.DeleteAsync(id);
                return item is null ? Results.NotFound() : TypedResults.Ok(item);
            }).WithName($"Archive{name}").WithOpenApi();
            
            group.MapDelete("/", async ([FromBody] List<Guid> ids, BankService sv) => {
                var items = await sv.DeleteRangeAsync(ids);
                return items is null ? Results.NotFound() : TypedResults.Ok(items);
            }).WithName($"RangeArchive{name}").WithOpenApi();

            return group;
        }
    }
}