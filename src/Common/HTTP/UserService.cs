using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class UserService : IUserService {
    
    private readonly IHttpService _http;

    public UserService(IHttpService http) {
        _http = http;
    }
    public Task<List<UserResponse>> GetAllAsync() {
        return _http.Get<List<UserResponse>>("api/v1/user" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}