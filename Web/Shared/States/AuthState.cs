using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using CashClaim.Common.HTTP;

namespace CashClaim.Web.Shared.States;

public class AuthState : RootState {
    private readonly NavigationManager _nav;
    private readonly IProfileService _profileService;
    private readonly AuthenticationStateProvider _authProvider;
    private readonly ISessionStorageService _sessionStorage;
    
    public AuthState(AuthenticationStateProvider authProvider, NavigationManager nav, IProfileService profileService, ISessionStorageService sessionStorage) {
        _authProvider = authProvider;
        _nav = nav;
        _profileService = profileService;
        _sessionStorage = sessionStorage;
    }

    public async Task<AuthResponse?> GetSession() => await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);

    private AuthProvider Profile { get {
        return (AuthProvider)_authProvider;
        }
    }

    private async Task<AuthenticationState> GetState() => await Profile.GetAuthenticationStateAsync();

    private async Task<ClaimsPrincipal> GetUser() => (await GetState()).User;

    public async Task Refresh() {
        var auth = (await _profileService.GetAccountAsync()).Data;
        if (auth != null) {
            await Profile.RefreshAuthenticationState(auth);
        }
    }

    public async Task<UserPermission> GetPermission() => (await this.GetSession())!.Data?.Permission ?? UserPermission.Anonymous;
    public async Task<UserResponse?> GetAccount() => (await this.GetSession())!.Data;

    public async Task<bool> IsAuth() => (await GetUser()).Identity!.IsAuthenticated;
    
    public async Task TriggerAuthentication() {
        var response = await _profileService.GetAccountAsync();
        if (response is { Data: { }, Succeeded: true })
            await Profile.UpdateAuthenticationState(response.Data);
        else
            await Profile.ClearAuthInfo();
    }
    
    public void TriggerApiAuth() => _nav.NavigateTo($"{_nav.BaseUri}{WebConst.ApiAuth}", true);

    public async Task TriggerSignOut() {
        await _profileService.SignOutAsync();
        await Profile.ClearAuthInfo();
        _nav.NavigateTo(WebConst.AppAuth, true);
    }
}