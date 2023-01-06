using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.ProfileModule;

public interface ITeamRepository {
    Task Create(TeamEntity team);
    Task<BankAccountEntity?> GetBankAccount(UserEntity user);
    Task<EventEntity?> GetAccountHistory(UserEntity user);
    Task<EventEntity?> GetRecentNotifications(UserEntity user);
}