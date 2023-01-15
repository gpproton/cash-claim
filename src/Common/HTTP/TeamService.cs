using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class TeamService : ITeamService {
    private readonly IHttpService _http;
    public TeamService(IHttpService http) {
        _http = http;
    }
}