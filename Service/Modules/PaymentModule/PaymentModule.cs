using Microsoft.AspNetCore.Mvc;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.PaymentModule;

public class PaymentModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<PaymentService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Payment";
        var url = $"{Constants.RootApi}/{name.ToLower()}";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/", async (PaymentService sv, [AsParameters] PaymentFilter filter) =>
                await sv.GetAllAsync(filter))
            .WithName($"GetAll{name}")
            .WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, PaymentService sv) => {
            var result = await sv.GetByIdAsync(id);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Get{name}ById").WithOpenApi();
        
        group.MapPost("/transaction/create/{id:guid}", (Guid id, PaymentService sv) => 1
        ).WithName($"Create{name}Transaction").WithOpenApi();

        group.MapPut("/transaction/confirm/{id:guid}", (Guid id, PaymentService sv) => 1
        ).WithName($"Confirm{name}Transaction").WithOpenApi();

        group.MapDelete("/transaction/cancel/{id:guid}", (Guid id, PaymentService sv) => 1
        ).WithName($"Cancel{name}Transaction").WithOpenApi();

        group.MapDelete("/", ([FromBody] List<Guid> ids, PaymentService sv) => 1
        ).WithName($"RangedCancel{name}Transaction").WithOpenApi();
        
        group.MapGet("/file/{id:guid}", async (Guid id, PaymentService sv, [AsParameters] GenericFilter filter) => {
            var result = await sv.GetFileAsync(id, filter);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Review{name}Files").WithOpenApi();
        
        group.MapGet("/comment/{id:guid}", async (Guid id, PaymentService sv, [AsParameters] GenericFilter filter) => {
            var result = await sv.GetCommentAsync(id, filter);
            return !result.Succeeded ? Results.NotFound(result) : TypedResults.Ok(result);
        }).WithName($"Review{name}Comments").WithOpenApi();

        return group;
    }
}