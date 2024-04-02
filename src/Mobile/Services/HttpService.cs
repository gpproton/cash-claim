using XClaim.Common.Service;

namespace XClaim.Mobile.Services;

public class HttpService : AbstractHttpService {

    public HttpService(HttpClient http) : base(http) { }
    protected override Task AddJwtHeader(HttpRequestMessage request) {
        throw new NotImplementedException();
    }
    protected override async Task SignOut() {
        // await Shell.Current.GoToAsync("");
        // Call other logic
        await Task.CompletedTask;
    }
}