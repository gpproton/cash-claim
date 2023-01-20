using Microsoft.AspNetCore.Components;
using XClaim.Common.Service;

namespace XClaim.Web.Shared;

public class HttpService : AbstractHttpService {
    private readonly NavigationManager _navigation;

    public HttpService(HttpClient http, NavigationManager navigation) : base(http) {
        _navigation = navigation;
    }
    protected override async Task AddJwtHeader(HttpRequestMessage request) {
        // var user = await _localStorageService.GetItem<User>("user");
        // var isApiUrl = !request.RequestUri.IsAbsoluteUri;
        // if (user != null && isApiUrl)
        //     request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
        await Task.CompletedTask;
    }
    protected override async Task SignOut() {
        _navigation.NavigateTo("");
        await Task.CompletedTask;
    }
}