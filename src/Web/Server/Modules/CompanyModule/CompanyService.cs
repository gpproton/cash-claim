using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyService : GenericService<ServerContext, CompanyEntity, CompanyResponse> {
    public CompanyService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }

    public async Task<List<CompanyResponse>> GetAllAsync(CompanyFilter? filter) {
        var query = _ctx.Companies
        .Include(x => x.Manager);
        var values = filter is null ? query.ToListAsync() : query.ApplyFilter(filter).ToListAsync();
        
        return _mapper.Map<List<CompanyResponse>>(await values);
    }
}