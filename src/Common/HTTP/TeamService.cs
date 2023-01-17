using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class TeamService : ITeamService {
    private const string RootApi = "api/v1/team";
    private readonly IHttpService _http;
    
    public TeamService(IHttpService http) {
        _http = http;
    }
    public async Task<List<TeamResponse>> GetAllAsync() {
        return await _http.Get<List<TeamResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}