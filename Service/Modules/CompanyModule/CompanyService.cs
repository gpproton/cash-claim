using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CashClaim.Common.Dtos;
using CashClaim.Common.Helpers;
using CashClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public sealed class CompanyService : GenericService<ServerContext, CompanyEntity, CompanyResponse> {
    public CompanyService(ServerContext ctx, IMapper mapper, ILogger<CompanyService> logger) : base(ctx, mapper, logger) { }

    new public async Task<PagedResponse<List<CompanyResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<CompanyResponse>>();
        var query = _ctx.Companies
        .Include(x => x.Manager);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<CompanyResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<CompanyResponse>>(response, count, filter) {
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

    new public async Task<Response<CompanyResponse?>> GetByIdAsync(Guid id) {
        var item = await _ctx.Companies.Include(m => m.Manager)
                   .FirstOrDefaultAsync(m => m.Id == id);
        var data = _mapper.Map<CompanyResponse>(item);

        return new Response<CompanyResponse?>(data) {
            Succeeded = data != null
        };
    }

    new public async Task<Response<CompanyResponse?>> DeleteAsync(Guid id) {
        var result = new Response<CompanyResponse?>();
        var item = await _ctx.Set<CompanyEntity>().FindAsync(id);
        if (item == null) return result;
        item.ManagerId = null;
        _ctx.Set<CompanyEntity>().Remove(item);
        await _ctx.SaveChangesAsync();
        var data = _mapper.Map<CompanyResponse>(item);
        result.Data = data;
        result.Succeeded = data != null;

        return result;
    }
}