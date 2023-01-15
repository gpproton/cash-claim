using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class ProfileService : IProfileService {
    private readonly IHttpService _http;

    public ProfileService(IHttpService http) {
        _http = http;
    }

    public async Task<AuthResponse?> GetAsync() {
        return await _http.Get<AuthResponse?>("/api/v1/profile/account");
    }

    public async Task<bool> SignOutAsync() {
        return await _http.Post<bool>("/auth/sign-out", null);
    }
}