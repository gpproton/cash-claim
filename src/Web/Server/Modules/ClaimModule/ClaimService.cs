using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimService : GenericService<ServerContext, ClaimEntity, ClaimResponse>, IClaimService {
    public ClaimService(ServerContext ctx, IMapper mapper, ILogger<ClaimService> logger) : base(ctx, mapper, logger) { }
    
    new public virtual async Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<ClaimResponse>>();
        var query = _ctx.Claims.Where(x => x.DeletedAt == null)
        .Include(x => x.Owner)
        .Include(x => x.Category);
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
    
    new public virtual async Task<Response<ClaimResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<ClaimResponse?>();
        try {
            var item = await _ctx.Claims.Where(x => x.Id == id)
                       .Include(x => x.Owner)
                       .Include(x => x.Category)
                       .FirstOrDefaultAsync();
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