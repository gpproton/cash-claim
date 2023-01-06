using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.ClaimModule;

public interface IClaimRepository {
    public Task<List<ClaimEntity>> GetAll();
    Task Create(ClaimEntity claim);
    Task Modify(ClaimEntity claim);
    Task Review(ClaimEntity claim, UserEntity by);
    Task<bool> Archive(Guid id);
    Task<bool> Delete(Guid id);
    Task<ClaimEntity?> Update(Guid id);
    Task<ClaimEntity?> GetById(Guid id);
    Task<ClaimEntity?> Review(Guid id);
}