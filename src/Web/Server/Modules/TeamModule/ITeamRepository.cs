using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.TeamModule;

public interface ITeamRepository {
    public Task<List<TeamEntity>> GetAll();
    Task Create(TeamEntity team);
    Task Modify(TeamEntity team);
    Task<bool> Delete(Guid id);
    Task<TeamEntity?> GetById(Guid id);
}