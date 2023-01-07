using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimService : IClaimRepository {
    public Task<List<ClaimEntity>> GetAll() {
        throw new NotImplementedException();
    }

    public Task Create(ClaimEntity claim) {
        throw new NotImplementedException();
    }

    public Task Modify(ClaimEntity claim) {
        throw new NotImplementedException();
    }

    public Task Review(ClaimEntity claim, UserEntity by) {
        throw new NotImplementedException();
    }

    public Task<bool> Archive(Guid id) {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id) {
        throw new NotImplementedException();
    }

    public Task<ClaimEntity?> Update(Guid id) {
        throw new NotImplementedException();
    }

    public Task<ClaimEntity?> GetById(Guid id) {
        throw new NotImplementedException();
    }

    public Task<ClaimEntity?> Review(Guid id) {
        throw new NotImplementedException();
    }
}