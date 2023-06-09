using System.Security.Claims;
using Axolotl.Response;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using XClaim.Common.Responses;
using XClaim.Common.Enums;
using XClaim.Common.Http.Account;

namespace XClaim.Web.Shared.States {
    public class AuthState : RootState {
        private readonly NavigationManager _nav;
        private readonly IProfileService _profileService;
        private readonly AuthenticationStateProvider _authProvider;
        private readonly ISessionStorageService _sessionStorage;

        public AuthState(AuthenticationStateProvider authProvider, NavigationManager nav, IProfileService profile,
            ISessionStorageService sessionStorage) {
            _authProvider = authProvider;
            _nav = nav;
            _profileService = profile;
            _sessionStorage = sessionStorage;
        }

        public async Task<AuthResponse?> GetSession() {
            return await _sessionStorage.GetAsync<AuthResponse>(WebConst.SessionKey);
        }

        private AuthProvider Profile => (AuthProvider)_authProvider;

        private async Task<AuthenticationState> GetState() {
            return await Profile.GetAuthenticationStateAsync();
        }

        private async Task<ClaimsPrincipal> GetUser() {
            return (await GetState()).User;
        }

        public async Task Refresh() {
            AuthResponse? auth = (await _profileService.GetAccountAsync()).Data;
            if (auth != null) {
                await Profile.RefreshAuthenticationState(auth);
            }
        }

        public async Task<UserPermission> GetPermission() {
            return (await GetSession())!.Data?.Permission ?? UserPermission.Anonymous;
        }

        public async Task<User?> GetAccount() {
            return (await GetSession())!.Data;
        }

        public async Task<bool> IsAuth() {
            return (await GetUser()).Identity!.IsAuthenticated;
        }

        public async Task TriggerAuthentication() {
            Response<AuthResponse?>? response = await _profileService.GetAccountAsync();
            if (response is { Data: not null, Success: true }) {
                await Profile.UpdateAuthenticationState(response.Data);
            }
            else {
                await Profile.ClearAuthInfo();
            }
        }

        public void TriggerApiAuth() {
            _nav.NavigateTo($"{_nav.BaseUri}{WebConst.ApiAuth}", true);
        }

        public async Task TriggerSignOut() {
            await _profileService.SignOutAsync();
            await Profile.ClearAuthInfo();
            _nav.NavigateTo(WebConst.AppAuth, true);
        }
    }
}