using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ITeamService {
    Task<List<TeamResponse>> GetAllAsync();
}