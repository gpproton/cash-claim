using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.TeamModule;

public class TeamService : GenericService<ServerContext, TeamEntity, TeamResponse> {
    public TeamService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}