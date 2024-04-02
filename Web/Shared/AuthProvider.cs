using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using CashClaim.Common.Dtos;

namespace XClaim.Web.Shared;

public class AuthProvider : AuthenticationStateProvider {
    private readonly ISessionStorageService _sessionStorage;
    private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public AuthProvider(ISessionStorageService sessionStorage) {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        try {
            var userSession = await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);
            if (userSession == null)
                return await Task.FromResult(new AuthenticationState(_anonymous));
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.Role, userSession.Role)
            }, "SessionAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateAuthenticationState(AuthResponse? userSession) {
        ClaimsPrincipal claimsPrincipal;

        if (userSession != null) {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
            userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
            await _sessionStorage.SaveAsync(WebConst.SessionKey, userSession);
        }
        else {
            claimsPrincipal = _anonymous;
            await _sessionStorage.RemoveItemAsync(WebConst.SessionKey);
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task RefreshAuthenticationState(AuthResponse userSession) {
        await _sessionStorage.SaveAsync(WebConst.SessionKey, userSession);
    }

    public async Task ClearAuthInfo() => await this.UpdateAuthenticationState(null);

    public async Task<string?> GetToken() {
        var result = string.Empty;
        try {
            var userSession = await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);
            if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp)
                result = userSession.Token;
        } catch {
            // ignored
        }
        return result;
    }
}