using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using XClaim.Common.HTTP;
using XClaim.Common.Service;

namespace XClaim.Web.Shared.States;

public class AuthState : RootState {
    public AuthState(AuthenticationStateProvider authProvider, NavigationManager nav, IProfileService userService) {
        _authProvider = authProvider;
        Nav = nav;
        UserService = userService;
    }

    private NavigationManager Nav { get; set;  }

    private IProfileService UserService { get; set; }

    private readonly AuthenticationStateProvider _authProvider;
    
    public bool Register { get; set; }
    
    public async Task BootstrapAuth() {
        var auth = (AuthProvider)_authProvider;
        var authState = await auth.GetAuthenticationStateAsync();
        var user  = authState.User;
        var isAuth = user.Identity?.IsAuthenticated ?? false;
        
        if (!isAuth) {
            var profile = await UserService.GetAsync()!;
            if (profile is not null) {
                await auth.UpdateAuthenticationState(profile);
                if (!profile.Confirmed) Register = true;
            }
        }

        Nav.NavigateTo(Register ? $"/{WebConst.AppHome}" : $"/{WebConst.AppRegister}");
    }
}