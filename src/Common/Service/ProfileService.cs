using System.Net;
using System.Net.Http.Json;
using XClaim.Common.Dtos;

namespace XClaim.Common.Service;

public class ProfileService : IProfileService {
    private readonly HttpClient _client;

    public ProfileService(HttpClient client) {
        _client = client;
    }

    public async Task<AuthResponse?> GetProfileAsync() {
        var response = await _client.GetAsync("/api/v1/profile/account");
        if (response.StatusCode == HttpStatusCode.Unauthorized) return null;
        
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }

    public async Task<string> SignOutAsync() {
        var response = await _client.PostAsync("/auth/sign-out", null);

        return await response.Content.ReadAsStringAsync();
    }
}