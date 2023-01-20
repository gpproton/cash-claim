using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class UserService : IUserService {
    private const string RootApi = "api/v1/user";
    private readonly IHttpService _http;

    public UserService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<UserResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<UserResponse>>>(RootApi, query);
    }
    public async Task<PagedResponse<List<UserResponse>>> GetManagersAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<UserResponse>>>(RootApi, query);
    }
}