using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.BankModule {

    public class BankModule : IModule {
        public IServiceCollection RegisterApiModule(IServiceCollection services) {
            services.AddScoped<BankService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
            const string name = nameof(Bank);
            var url = $"{Constants.RootApi}/{name.ToLower()}";
            var group = endpoints.MapGroup(url).WithTags(name);

            group.MapGet("/", async (BankService sv, [AsParameters] GenericFilter filter) =>
                    await sv.GetAllAsync(filter))
                .WithName($"GetAll{name}")
                .WithOpenApi();

            group.MapGet("/{id:guid}", async (Guid id, BankService sv) => {
                var result = await sv.GetByIdAsync(id);
                return TypedResults.Ok(result);
            }).WithName($"Get{name}ById").WithOpenApi();

            group.MapPost("/", async (Bank value, BankService sv) => {
                await sv.CreateAsync(value);
                return TypedResults.Created($"{url}/{value.Id}", value);
            }).WithName($"Create{name}").WithOpenApi();

            group.MapPut("/", async (Bank value, BankService sv) => {
                var result = await sv.UpdateAsync(value);
                return result is null ? Results.NotFound() : TypedResults.Ok(value);
            }).WithName($"Update{name}").WithOpenApi();

            group.MapDelete("/{id:guid}", async (Guid id, BankService sv) => {
                var item = await sv.DeleteAsync(id);
                return item is null ? Results.NotFound() : TypedResults.Ok(item);
            }).WithName($"Archive{name}").WithOpenApi();

            return group;
        }
    }
}