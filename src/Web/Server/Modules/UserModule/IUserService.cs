using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.UserModule;

public interface IUserService {
    public Task<UserResponse?> GetByEmailAsync(string email);
}