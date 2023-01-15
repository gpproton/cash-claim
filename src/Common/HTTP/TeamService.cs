using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class TeamService : ITeamService {
    private readonly IHttpService _http;
    public TeamService(IHttpService http) {
        _http = http;
    }
    public async Task<List<TeamResponse>> GetAllAsync() {
        return await _http.Get<List<TeamResponse>>("api/v1/team" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}