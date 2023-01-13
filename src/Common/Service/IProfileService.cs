using XClaim.Common.Dtos;

namespace XClaim.Common.Service;

public interface IProfileService {
    Task<AuthResponse?> GetProfileAsync();
    Task<string> SignOutAsync();
}