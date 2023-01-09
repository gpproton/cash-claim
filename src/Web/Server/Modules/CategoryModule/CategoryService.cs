using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryService : GenericService<ServerContext, CategoryEntity, CategoryResponse> {
    public CategoryService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}