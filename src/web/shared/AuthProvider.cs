// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using XClaim.Common.Responses;

namespace XClaim.Web.Shared; 

public class AuthProvider : AuthenticationStateProvider {
    private readonly ISessionStorageService _sessionStorage;
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    public AuthProvider(ISessionStorageService sessionStorage) {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        try {
            AuthResponse? userSession = await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);
            if (userSession == null) {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            ClaimsPrincipal? claimsPrincipal = new(new ClaimsIdentity(new List<Claim> {
                new(ClaimTypes.Name, userSession.UserName),
                new(ClaimTypes.Role, userSession.Role)
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
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                new(ClaimTypes.Name, userSession.UserName),
                new(ClaimTypes.Role, userSession.Role)
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

    public async Task ClearAuthInfo() {
        await UpdateAuthenticationState(null);
    }

    public async Task<string?> GetToken() {
        string? result = string.Empty;
        try {
            AuthResponse? userSession = await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);
            if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp) {
                result = userSession.Token;
            }
        }
        catch {
            // ignored
        }

        return result;
    }
}