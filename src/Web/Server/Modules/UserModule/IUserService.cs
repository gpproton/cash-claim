using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.UserModule;

public interface IUserService {
    public Task<Response<UserResponse?>> GetByEmailAsync(string email);
    public Task<PagedResponse<List<UserResponse>>> GetAllAsync(UserFilter responseFilter);
}