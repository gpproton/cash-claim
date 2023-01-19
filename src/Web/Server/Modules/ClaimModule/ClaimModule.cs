using Microsoft.AspNetCore.Mvc;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<ClaimService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Claim";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async (ClaimService sv, [AsParameters] ClaimFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, ClaimService sv) => {
            var result = await sv.GetByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();

        group.MapPost("/", async (ClaimResponse value, ClaimService sv) => {
            var response = await sv.CreateAsync(value);
            return TypedResults.Created($"{url}/{value.Id}", response);
        }).WithName($"Create{name}").WithOpenApi();

        group.MapPost("/upload/{id:guid}", async (Guid id, ClaimService sv, IFormFileCollection files, FileUploadService upload) => {
            
            // TODO: Get claim and save in upload service
            var result = (await sv.GetByIdAsync(id));
            if (result.Data == null) return Results.NotFound(result);
            var uploads = await upload.UploadFiles(files);
            var data = result.Data;
            data.Files = uploads;
            var update = await sv.UpdateAsync(data);
            
            return !update.Succeeded ? Results.BadRequest(update) : TypedResults.Ok(update);
        })
            .Accepts<IFormFileCollection>("multipart/form-data")
            .Produces<List<FileResponse>>()
            .WithName($"Upload{name}Files").WithOpenApi();

        group.MapPut("/", async (ClaimResponse value, ClaimService sv) => {
            var result = await sv.UpdateAsync(value);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapPost("/review/{id:guid}", () => {
            // TODO: new claim review service
            Results.Ok();
        }).WithName($"Review{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, ClaimService sv) => {
            var item = await sv.DeleteAsync(id);
            return !item.Succeeded ? Results.NotFound(item) : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();
        
        group.MapDelete("/", async ([FromBody] List<Guid> ids, ClaimService sv) => {
            var items = await sv.DeleteRangeAsync(ids);
            return !items.Succeeded ? Results.NotFound(items) : TypedResults.Ok(items);
        }).WithName($"RangeArchive{name}").WithOpenApi();

        return group;
    }
}