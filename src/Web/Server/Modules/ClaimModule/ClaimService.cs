using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimService : GenericService<ServerContext, ClaimEntity, ClaimResponse>, IClaimService {
    public ClaimService(ServerContext ctx, IMapper mapper, ILogger<ClaimService> logger) : base(ctx, mapper, logger) { }
}