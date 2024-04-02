using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.DomainModule;

public sealed class DomainService : GenericService<ServerContext, DomainEntity, DomainResponse> {
    public DomainService(ServerContext ctx, IMapper mapper, ILogger<DomainService> logger) : base(ctx, mapper, logger) { }
}