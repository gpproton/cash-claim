using Microsoft.AspNetCore.Mvc;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<UserService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "User";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async (UserService sv, [AsParameters] UserFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, UserService sv) => {
            var result = await sv.GetByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        group.MapGet("/{email}", async (string email, UserService sv) => {
            var result = await sv.GetByEmailAsync(email);
            return !result.Succeeded ? Results.NotFound() : TypedResults.Ok(result);
        }).WithName($"Get{name}ByEmail").WithOpenApi();

        group.MapPost("/", async (UserResponse value, UserService sv) => {
            var response = await sv.CreateAsync(value);
            return TypedResults.Created($"{url}/{value.Id}", response);
        }).WithName($"Create{name}").WithOpenApi();

        group.MapPut("/", async (UserResponse value, UserService sv) => {
            var result = await sv.UpdateAsync(value);
            return !result.Succeeded ? Results.NotFound() : TypedResults.Ok(result);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, UserService sv) => {
            var item = await sv.DeleteAsync(id);
            return !item.Succeeded ? Results.NotFound(item) : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();

        group.MapDelete("/", async ([FromBody] List<Guid> ids, UserService sv) => {
            var items = await sv.DeleteRangeAsync(ids);
            return !items.Succeeded ? Results.NotFound(items) : TypedResults.Ok(items);
        }).WithName($"RangeArchive{name}").WithOpenApi();
        
        group.MapGet("/transfer/profile", async (UserService sv) => {
            var result = await sv.GetTransferAsync();
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}Transfer").WithOpenApi();
        
        group.MapGet("/transfer", async (UserService sv, [AsParameters] TransferRequestFilter filter) => {
            var result = await sv.GetAllTransferAsync(filter);
            return !result.Succeeded ? Results.NotFound() : TypedResults.Ok(result);
        }).WithName($"Get{name}TransferList").WithOpenApi();
        
        group.MapPost("/transfer", async (UserService sv) =>
        await sv.CreateTransferAsync())
        .WithName($"Create{name}Transfer").WithOpenApi();
        
        group.MapPut("/transfer", async (TransferRequestResponse value, UserService sv) => {
            var result = await sv.ApproveTransferAsync(value);
            return !result.Succeeded ? Results.NotFound() : TypedResults.Ok(result);
        }).WithName($"Update{name}Transfer").WithOpenApi();
        
        group.MapDelete("/transfer/{id:guid}", async (Guid id, UserService sv) => {
            var item = await sv.ArchiveTransferAsync(id);
            return !item.Succeeded ? Results.NotFound(item) : TypedResults.Ok(item);
        }).WithName($"Archive{name}Transfer").WithOpenApi();

        return group;
    }
}