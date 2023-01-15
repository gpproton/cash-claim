using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryService : GenericService<ServerContext, CategoryEntity, CategoryResponse> {
    public CategoryService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }

    public async Task<List<CategoryResponse>> GetAllAsync(GenericFilter? filter) {
        var query = _ctx.Categories
        .Include(x => x.Company);
        var values = filter is null ? await query.ToListAsync() : await query.ApplyFilter(filter).ToListAsync();

        return _mapper.Map<List<CategoryResponse>>(values);
    }
}