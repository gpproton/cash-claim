using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public class TeamService : ITeamService {
    private const string RootApi = "api/v1/team";
    private readonly IHttpService _http;

    public TeamService(IHttpService http) {
        _http = http;
    }

    public async Task<PagedResponse<List<TeamResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<TeamResponse>>>(RootApi, query);
    }
    public async Task<Response<TeamResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<TeamResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<TeamResponse>> CreateAsync(TeamResponse bank) {
        return await _http.Post<Response<TeamResponse>>(RootApi, bank);
    }
    public async Task<Response<TeamResponse>> UpdateAsync(TeamResponse bank) {
        return await _http.Put<Response<TeamResponse>>(RootApi, bank);
    }
    public async Task<Response<TeamResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<TeamResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<TeamResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<TeamResponse>>>(RootApi, ids);
    }
}