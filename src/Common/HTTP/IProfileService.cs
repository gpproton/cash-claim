using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IProfileService {
    Task<AuthResponse?> GetAsync();
    Task<bool> SignOutAsync();
}