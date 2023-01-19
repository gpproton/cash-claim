using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyService : GenericService<ServerContext, CompanyEntity, CompanyResponse> {
    public CompanyService(ServerContext ctx, IMapper mapper, ILogger<CompanyService> logger) : base(ctx, mapper, logger) { }

    public async Task<PagedResponse<List<CompanyResponse>>> GetAllAsync(CompanyFilter responseFilter) {
        var result = new PagedResponse<List<CompanyResponse>>();
        var query = _ctx.Companies.Include(x => x.Manager);
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
}