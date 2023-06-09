using System.Net.Http.Headers;
using Axolotl.Http;
using XClaim.Web.Shared.States;

namespace XClaim.Web.Shared;

public class HttpService : AbstractHttpService {
    private readonly Lazy<AuthState>  _state;

    public HttpService(HttpClient http, Lazy<AuthState> state) : base(http) {
        _state = state;
    }

    protected override async Task AddJwtHeader(HttpRequestMessage request) {
        var user = await _state.Value.GetSession();
        var isApiUrl = !request!.RequestUri!.IsAbsoluteUri;
        if (user != null && isApiUrl)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
    }
    protected override async Task SignOut() {
        await _state.Value.TriggerSignOut();
    }
}