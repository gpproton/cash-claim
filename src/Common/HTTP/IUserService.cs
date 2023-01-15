using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IUserService {
    Task<List<UserResponse>>  GetAllAsync();
}