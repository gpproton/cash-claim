using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.ProfileModule;

public interface IProfileService {
    Task<BankAccountEntity?> GetBankAccount(Guid userId);
    Task<EventEntity?> GetAccountHistory(Guid userId);
    Task<EventEntity?> GetRecentNotifications(Guid userId);
}