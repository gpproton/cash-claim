using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.UserModule;
public interface IUserRepository {
    public Task<List<UserEntity>> GetAll();
    Task Create(UserEntity user);
    Task<bool> Delete(Guid id);
    Task<UserEntity?> GetById(Guid id);
    // TODO: Get Account summary
}