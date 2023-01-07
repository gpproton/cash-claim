using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IUserRepository, UserService>();

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup($"{Constants.RootApi}/user").WithTags(nameof(User));

        group.MapGet("/", async (IUserRepository sv, IMapper mapper) => {
            var result = await sv.GetAll();
            return mapper.Map<List<User>>(result);
        })
            .WithName("GetAllUsers").WithOpenApi();

        group.MapGet("/{id:guid}", async (Guid id, IUserRepository sv, IMapper mapper) => {
            var result = await sv.GetById(id);
            return result is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<User>(result));
        })
            .WithName("GetUserById").WithOpenApi();

        group.MapPost("/", async (User user, IUserRepository sv, IMapper mapper) => {
            var value = mapper.Map<UserEntity>(user);
            await sv.Create(value);
            return TypedResults.Created($"/api/v1/user/{value.Id}", user);
        })
            .WithName("CreateUser").WithOpenApi();

        group.MapPut("/{id:guid}", async (Guid id, User user, IUserRepository sv, IMapper mapper) => {
            var value = mapper.Map<UserEntity>(user);
            var result = await sv.Modify(id, value);
            return result is null ? Results.NotFound() : TypedResults.Ok(user);
        }).WithName("UpdateUser").WithOpenApi();

        group.MapDelete("/{id:guid}", async (Guid id, IUserRepository sv, IMapper mapper) => {
            var item = await sv.Delete(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<User>(item));
        }).WithName("ArchiveUser").WithOpenApi();

        return group;
    }
}