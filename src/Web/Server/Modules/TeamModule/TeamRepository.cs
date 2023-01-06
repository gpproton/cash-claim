using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.TeamModule;

public class TeamRepository : ITeamRepository {
    public Task<List<TeamEntity>> GetAll() {
        throw new NotImplementedException();
    }

    public Task Create(TeamEntity team) {
        throw new NotImplementedException();
    }

    public Task Modify(TeamEntity team) {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id) {
        throw new NotImplementedException();
    }

    public Task<TeamEntity?> GetById(Guid id) {
        throw new NotImplementedException();
    }
}