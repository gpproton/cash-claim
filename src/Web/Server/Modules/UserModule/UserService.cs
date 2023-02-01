using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.UserModule;

public sealed class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    private readonly IdentityHelper _identity;
    public UserService(ServerContext ctx, IMapper mapper, ILogger<UserService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }
    public async Task<Response<UserResponse?>> GetByEmailAsync(string email) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .Where(x => x.Email == email)
                   .Include(x => x.Company)
                   .Include(x => x.Team)
                   .Include(x => x.Currency)
                   .FirstOrDefaultAsync();
        var data = _mapper.Map<UserResponse>(item);

        return new Response<UserResponse?> {
            Data = data,
            Succeeded = data != null
        };
    }
    
    public async Task<Response<UserResponse?>> GetByIdentifierAsync(string? identifier) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .Where(x => x.Identifier == identifier)
                   .Include(x => x.Company)
                   .Include(x => x.Team)
                   .Include(x => x.Currency)
                   .FirstOrDefaultAsync();
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
            result = new PagedResponse<List<UserResponse>>(response, count, filter) {
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

    new public async Task<Response<UserResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<UserResponse?>();
        try {
            var item = await _ctx.Users
                       .Where(x => x.Id == id)
                       .Include(x => x.Company)
                       .Include(x => x.Team)
                       .Include(x => x.Currency)
                       .FirstOrDefaultAsync();
            var data = _mapper.Map<UserResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    new public async Task<Response<UserResponse>> CreateAsync(UserResponse value) {
        var response = new Response<UserResponse>();
        try {
            var item = _mapper.Map<UserEntity>(value);
            item.Identifier = _identity!.NameIdentifier!;
            item.Active = true;
            var isAdmin = (await _ctx.Users.CountAsync(x => x.Permission == UserPermission.System)) < 1;
            if (isAdmin) item.Permission = UserPermission.System;
            await _ctx.Users.AddAsync(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<UserResponse>(item);
            response = new Response<UserResponse>(data!) {
                Succeeded = data != null
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
}