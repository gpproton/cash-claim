using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface IProfileService {
    Task<Response<AuthResponse?>> GetAccountAsync();
    Task<Response<BankAccountResponse?>> GetBankAccountAsync();
    Task<Response<BankAccountResponse?>> UpdateBankAccountAsync(BankAccountResponse account);

    Task<Response<SettingResponse?>> GetSettingAsync();
    Task<Response<SettingResponse?>> UpdateSettingAsync(SettingResponse setting);

    Task<Response<NotificationResponse?>> GetNotificationAsync();
    Task<Response<NotificationResponse?>> UpdateNotificationAsync(NotificationResponse notification);
    Task<bool> SignOutAsync();
}