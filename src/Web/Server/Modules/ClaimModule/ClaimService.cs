using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimService : GenericService<ServerContext, ClaimEntity, ClaimResponse>, IClaimService {
    public ClaimService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}