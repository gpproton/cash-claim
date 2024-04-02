using Microsoft.AspNetCore.Mvc;
using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using CashClaim.Service.Helpers;
using CashClaim.Service.Modules.UserModule;

namespace CashClaim.Service.Modules.ClaimModule;

public class ClaimModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddTransient<ClaimStateResolver>();
        services.AddScoped<ClaimService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Claim";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name)
        .RequireAuthorization();

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

        group.MapPost("/upload/{id:guid}", async (Guid id, ClaimService sv, FileUploadService upload, IFormFile[] files) => {
            var result = (await sv.GetByIdAsync(id));
            if (result.Data == null) return Results.NotFound(result);
            var uploads = await upload.UploadFiles(files);
            var data = result.Data;
            data.Files = uploads;
            var update = await sv.UpdateAsync(data);

            return !update.Succeeded ? Results.BadRequest(update) : TypedResults.Ok(update);
        }).Accepts<IFormFile[]>("multipart/form-data")
        .Produces<List<FileResponse>>()
        .WithName($"Upload{name}Files").WithOpenApi();

        group.MapPut("/", async (ClaimResponse value, ClaimService sv) => {
            var result = await sv.UpdateAsync(value);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Update{name}").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, ClaimService sv) => {
            var item = await sv.DeleteAsync(id);
            return !item.Succeeded ? Results.NotFound(item) : TypedResults.Ok(item);
        }).WithName($"Archive{name}").WithOpenApi();

        group.MapDelete("/", async ([FromBody] List<Guid> ids, ClaimService sv) => {
            var items = await sv.DeleteRangeAsync(ids);
            return !items.Succeeded ? Results.NotFound(items) : TypedResults.Ok(items);
        }).WithName($"RangeArchive{name}").WithOpenApi();
        
        group.MapGet("/review", async (ClaimService sv, [AsParameters] ClaimFilter filter) =>
            await sv.GetReviewAllAsync(filter)).WithName($"Review{name}List").WithOpenApi();

        group.MapGet("/review/{id:guid}", async (Guid id, ClaimService sv) => {
            var result = await sv.GetReviewByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Review{name}ById").WithOpenApi();
        
        group.MapPut("/review/reject/{id:guid}", async (Guid id, CommentResponse comment, ClaimService sv) => {
            var result = await sv.ReviewValidateAsync(id, ClaimStatus.Rejected, comment);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"ReviewReject{name}").WithOpenApi();

        group.MapPut("/review/validate/{id:guid}", async (Guid id, CommentResponse comment, ClaimService sv) => {
            var result = await sv.ReviewValidateAsync(id, ClaimStatus.None, comment);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"ReviewValidate{name}").WithOpenApi();
        
        group.MapPut("/review/cancel/{id:guid}", async (Guid id, ClaimService sv) => {
            var result = await sv.ReviewValidateAsync(id, ClaimStatus.Cancelled, null);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"ReviewCancel{name}").WithOpenApi();
        
        group.MapGet("/pending-users", async (ClaimService sv, [AsParameters] UserFilter filter) =>
        await sv.GetPendingUserAsync(filter))
        .WithName($"GetAllPending{name}Users")
        .WithOpenApi();
        
        group.MapGet("/file/{id:guid}", async (Guid id, ClaimService sv, [AsParameters] GenericFilter filter) => {
            var result = await sv.GetFileAsync(id, filter);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Review{name}Files").WithOpenApi();
        
        group.MapGet("/comment/{id:guid}", async (Guid id, ClaimService sv, [AsParameters] GenericFilter filter) => {
            var result = await sv.GetCommentAsync(id, filter);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Review{name}Comments").WithOpenApi();

        return group;
    }
}