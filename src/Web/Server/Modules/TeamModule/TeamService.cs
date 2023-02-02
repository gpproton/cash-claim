using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.TeamModule;

public sealed class TeamService : GenericService<ServerContext, TeamEntity, TeamResponse> {
    private readonly IdentityHelper _identity;
    
    public TeamService(ServerContext ctx, IMapper mapper, ILogger<TeamService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }

    new public async Task<PagedResponse<List<TeamResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<TeamResponse>>();
        try {
            var current = await _identity.GetUser();
            var isSystemUser = current!.Permission == UserPermission.System;
            var query = _ctx.Teams
            .Where(e => isSystemUser || e.CompanyId == current.CompanyId)
            .Include(e => e.Company)
            .Include(e => e.Manager)
            .Where(x => x.DeletedAt == null);
            
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<TeamResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<TeamResponse>>(response, count, filter) {
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

    new public async Task<Response<TeamResponse?>> GetByIdAsync(Guid id) {
        var result = new Response<TeamResponse?>();
        try {
            var item = await _ctx.Teams
                       .Include(e => e.Company)
                       .Include(e => e.Manager)
                       .FirstOrDefaultAsync(e => e.Id == id);
            var data = _mapper.Map<TeamResponse>(item);
            result.Succeeded = data != null;
            result.Data = data;
        }
        catch (Exception e) {
            result.Errors = new[] {
                e.ToString()
            };
        }

        return result;
    }
}