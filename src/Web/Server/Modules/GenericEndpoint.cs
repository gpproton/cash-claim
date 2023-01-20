using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Modules;

// TODO: Fix service injection issues later
public class GenericEndpoint {
    public static RouteGroupBuilder GenerateEndpoints<TService, TResponse>(RouteGroupBuilder group)
        where TResponse : BaseResponse
        where TService : GenericService<DbContext, IBaseEntity, BaseResponse> {
        const string name = nameof(TResponse);

        group.MapGet("/", async (TService sv, [FromBody] GenericFilter filter) => await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, TService sv) => {
            var result = await sv.GetByIdAsync(id);
            return TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        group.MapPost("/", async (TResponse value, TService sv) => {
            await sv.CreateAsync(value);
            return TypedResults.Created($"/api/v1/bank/{value.Id}", value);
        }).WithName($"Create{name}").WithOpenApi();

        group.MapPut("/", async (TResponse value, TService sv) => {
            var result = await sv.UpdateAsync(value);
            return result is null ? Results.NotFound() : TypedResults.Ok(value);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, TService sv) => {
            var item = await sv.DeleteAsync(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(item);
        }).WithName("ArchiveBank").WithOpenApi();

        return group;
    }
}