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

namespace XClaim.Web.Server.Modules.CategoryModule;

public sealed class CategoryService : GenericService<ServerContext, CategoryEntity, CategoryResponse> {
    
    private readonly IdentityHelper _identity;
    
    public CategoryService(ServerContext ctx, IMapper mapper, ILogger<CategoryService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }

    new public async Task<PagedResponse<List<CategoryResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<CategoryResponse>>();
        try {
            var current = await _identity.GetUser();
            var isSystemUser = current!.Permission == UserPermission.System;
            var query = _ctx.Categories
            .Where(e => isSystemUser || e.CompanyId == current.CompanyId)
            .Include(x => x.Company);
            
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

    new public async Task<Response<CategoryResponse?>> GetByIdAsync(Guid id) {
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