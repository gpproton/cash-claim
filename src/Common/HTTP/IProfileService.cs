using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IProfileService {
    Task<Response<AuthResponse?>> GetAsync();
    Task<bool> SignOutAsync();
}