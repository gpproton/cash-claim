using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserModule : IModule {
    public IServiceCollection RegisterApiModule(IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
    
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup("/api/v1/user").WithTags(nameof(User));

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

        group.MapPost("/", async (UserEntity  user, IUserRepository sv, IMapper mapper) => {
                await sv.Create(user);
                return TypedResults.Created($"/api/v1/user/{user.Id}", mapper.Map<User>(user));
            })
            .WithName("CreateUser").WithOpenApi();

        group.MapPut("/{id:guid}", async (Guid id, UserEntity  user, IUserRepository sv, IMapper mapper) => {
            var result = await sv.Modify(id, user);
            return result is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<User>(result));
        }).WithName("UpdateUser").WithOpenApi();
        
        group.MapDelete("/{id:guid}", async (Guid id, IUserRepository sv, IMapper mapper) => {
            var item = await sv.Delete(id);
            return item is null ? Results.NotFound() : TypedResults.Ok(mapper.Map<User>(item));
        }).WithName("ArchiveUser").WithOpenApi();
        
        return group;
    }
}