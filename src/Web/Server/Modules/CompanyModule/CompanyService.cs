using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyService : GenericService<ServerContext, CompanyEntity, Company> {
    public CompanyService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}