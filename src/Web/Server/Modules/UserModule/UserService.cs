using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    public UserService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
    public async Task<UserResponse?> GetByEmailAsync(string email) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .FirstOrDefaultAsync(u => u.Email == email);
        return _mapper.Map<UserResponse>(item);
    }
    
    public async Task<List<UserResponse>> GetAllAsync(UserFilter? filter) {
        var query = _ctx.Users
        .Where(x => x.DeletedAt == null)
        .Include(x => x.Company)
        .Include(x => x.Team);
        var values = filter is null ?
                     await query .ToListAsync() :
                     await query.ApplyFilter(filter).ToListAsync();
        return _mapper.Map<List<UserResponse>>(values);
    }
}