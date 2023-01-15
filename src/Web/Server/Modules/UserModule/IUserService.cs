using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.UserModule;

public interface IUserService {
    public Task<UserResponse?> GetByEmailAsync(string email);
    public Task<List<UserResponse>> GetAllAsync(UserFilter? filter);
}