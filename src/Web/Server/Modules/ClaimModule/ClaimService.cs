using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.ClaimModule;

public sealed class ClaimService : GenericService<ServerContext, ClaimEntity, ClaimResponse>, IClaimService {
    private readonly IdentityHelper _identity;
    public ClaimService(ServerContext ctx, IMapper mapper, ILogger<ClaimService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }

    private async Task<IIncludableQueryable<ClaimEntity, CategoryEntity?>> ClaimPersonalQuery(IQueryable<ClaimEntity> queryable) {
        var userId = ((await _identity.GetUser())!).Id;
        return queryable.Where(x => x.DeletedAt == null)
        .Where(x => x.OwnerId == userId)
        .Include(x => x.Owner)
        .Include(x => x.Category);
    }

    new public async Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<ClaimResponse>>();
        var query = await ClaimPersonalQuery(_ctx.Claims);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<ClaimResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<ClaimResponse>>(response, count, filter) {
                Succeeded = true
            };
        } catch (Exception e) {
            result.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return result;
    }

    new public async Task<Response<ClaimResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<ClaimResponse?>();
        try {
            var item = await (await ClaimPersonalQuery(_ctx.Claims))
                       .Where(x => x.Id == id).FirstOrDefaultAsync();
            var data = _mapper.Map<ClaimResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
}