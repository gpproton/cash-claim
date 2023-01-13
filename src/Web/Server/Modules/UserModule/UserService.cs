using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    public UserService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
    public async Task<UserResponse?> GetByEmailAsync(string email) {
        var item = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
        return _mapper.Map<UserResponse>(item);
    }
}