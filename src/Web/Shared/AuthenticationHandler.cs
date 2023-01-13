using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using XClaim.Common.Service;

namespace XClaim.Web.Shared;

public class AuthenticationHandler {
    public AuthenticationHandler(AuthenticationStateProvider authProvider, NavigationManager nav, IProfileService userService) {
        _authProvider = authProvider;
        _nav = nav;
        _userService = userService;
    }

    private NavigationManager _nav { get; set;  }

    private IProfileService _userService { get; set; }

    private AuthenticationStateProvider _authProvider;
    
    private bool Register { get; set; }
    
    public async Task BootstrapAuth() {
        var auth = (AuthProvider)_authProvider;
        var authState = await auth.GetAuthenticationStateAsync();
        var user  = authState.User;
        var isAuth = user.Identity?.IsAuthenticated ?? false;
        
        if (!isAuth) {
            var profile = await _userService.GetProfileAsync()!;
            if (profile is not null) {
                await auth.UpdateAuthenticationState(profile);
                if (!profile.Confirmed) Register = true;
            }
        }

        _nav.NavigateTo(Register ? $"/{WebConst.AppHome}" : $"/{WebConst.AppRegister}");
    }
}