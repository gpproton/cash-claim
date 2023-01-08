using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileService : IProfileService {
    public Task<BankAccountEntity?> GetBankAccount(Guid userId) {
        throw new NotImplementedException();
    }

    public Task<EventEntity?> GetAccountHistory(Guid userId) {
        throw new NotImplementedException();
    }

    public Task<EventEntity?> GetRecentNotifications(Guid userId) {
        throw new NotImplementedException();
    }
}