using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IUserService {
    Task<PagedResponse<List<UserResponse>>> GetAllAsync(object? query = null);
    
    Task<PagedResponse<List<UserResponse>>> GetManagersAsync(object? query = null);
}