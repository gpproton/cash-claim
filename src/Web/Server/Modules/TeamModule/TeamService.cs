using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.TeamModule;

public class TeamService : GenericService<ServerContext, TeamEntity, TeamResponse> {
    public TeamService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}