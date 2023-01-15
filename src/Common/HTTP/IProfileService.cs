using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IProfileService {
    Task<AuthResponse?> GetProfileAsync();
    Task<string> SignOutAsync();
}