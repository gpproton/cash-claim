using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    public UserService(ServerContext ctx, IMapper mapper, ILogger<UserService> logger) : base(ctx, mapper, logger) { }
    public async Task<Response<UserResponse?>> GetByEmailAsync(string email) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .FirstOrDefaultAsync(u => u.Email == email);
        var data = _mapper.Map<UserResponse>(item);

        return new Response<UserResponse?> {
            Data = data,
            Succeeded = data != null
        };
    }
    
    public async Task<PagedResponse<List<UserResponse>>> GetAllAsync(UserFilter responseFilter) {
        var result = new PagedResponse<List<UserResponse>>();
        var query = _ctx.Users
        .Where(x => x.DeletedAt == null)
        .Include(x => x.Company)
        .Include(x => x.Team);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<UserResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<UserResponse>>(response, count, filter){
                Succeeded = true
            };
        }
        catch (Exception e) {
            result.Errors = new[] {
                e.ToString()
            };
            _logger.LogError(e.ToString());
        }
        
        return result;
    }
}