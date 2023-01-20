using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IUserService {
    Task<PagedResponse<List<UserResponse>>> GetAllAsync(object? query = null);
    
    Task<PagedResponse<List<UserResponse>>> GetManagersAsync(object? query = null);
    
    Task<Response<UserResponse>> GetByIdAsync(Guid id);
    
    Task<Response<UserResponse>> RegistrationAsync(UserResponse user);
    
    Task<Response<UserResponse>> UpdateAsync(UserResponse user);
    
    Task<Response<UserResponse>> ArchiveAsync(Guid id);
    
    Task<Response<List<UserResponse>>> ArchiveRangeAsync(List<Guid> ids);
}