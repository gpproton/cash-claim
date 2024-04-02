using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public class ProfileService : IProfileService {
    private const string RootApi = "api/v1/profile";
    private readonly IHttpService _http;

    public ProfileService(IHttpService http) {
        _http = http;
    }

    public async Task<Response<AuthResponse?>> GetAccountAsync() {
        return await _http.Get<Response<AuthResponse?>>($"{RootApi}/account");
    }
    public async Task<Response<BankAccountResponse?>> GetBankAccountAsync() {
        return await _http.Get<Response<BankAccountResponse?>>($"{RootApi}/bank-account");
    }
    public async Task<Response<BankAccountResponse?>> UpdateBankAccountAsync(BankAccountResponse account) {
        return await _http.Put<Response<BankAccountResponse?>>($"{RootApi}/bank-account", account);
    }
    public async Task<Response<SettingResponse?>> GetSettingAsync() {
        return await _http.Get<Response<SettingResponse?>>($"{RootApi}/setting");
    }
    public async Task<Response<SettingResponse?>> UpdateSettingAsync(SettingResponse setting) {
        return await _http.Put<Response<SettingResponse?>>($"{RootApi}/setting", setting);
    }
    public async Task<Response<NotificationResponse?>> GetNotificationAsync() {
        return await _http.Get<Response<NotificationResponse?>>($"{RootApi}/notification");
    }
    public async Task<Response<NotificationResponse?>> UpdateNotificationAsync(NotificationResponse notification) {
        return await _http.Put<Response<NotificationResponse?>>($"{RootApi}/notification", notification);
    }

    public async Task<bool> SignOutAsync() {
        return await _http.Post<bool>("/auth/sign-out", null);
    }
}