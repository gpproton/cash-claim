using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryService : GenericService<ServerContext, CategoryEntity, CategoryResponse> {
    public CategoryService(ServerContext ctx, IMapper mapper, ILogger<CategoryService> logger) : base(ctx, mapper, logger) { }

    new public async Task<PagedResponse<List<CategoryResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<CategoryResponse>>();
        var query = _ctx.Categories.Include(x => x.Company);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<CategoryResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<CategoryResponse>>(response, count, filter) {
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

    new public virtual async Task<Response<CategoryResponse?>> GetByIdAsync(Guid id) {
        var result = new Response<CategoryResponse?>();
        try {
            var item = await _ctx.Categories
                       .Include(e => e.Company)
                       .FirstOrDefaultAsync(e => e.Id == id);
            var data = _mapper.Map<CategoryResponse>(item);
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