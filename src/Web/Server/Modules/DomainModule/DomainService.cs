using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.DomainModule;

public class DomainService : GenericService<ServerContext, DomainEntity, DomainResponse> {
    public DomainService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}