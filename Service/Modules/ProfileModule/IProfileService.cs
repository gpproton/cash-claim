using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.ProfileModule;

public interface IProfileService {
    Task<Response<AuthResponse?>> GetAccountAsync();
    Task<Response<BankAccountResponse?>> GetBankAccountAsync();
    Task<Response<BankAccountResponse?>> UpdateBankAccountAsync(BankAccountResponse account);
    Task<Response<SettingResponse?>> GetSettingAsync();
    Task<Response<SettingResponse?>> UpdateSettingAsync(SettingResponse setting);
    
    Task<Response<NotificationResponse?>> GetNotificationAsync();
    Task<Response<NotificationResponse?>> UpdateNotificationAsync(NotificationResponse notification);
}