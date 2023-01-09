using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    public UserService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}