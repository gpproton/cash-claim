using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CurrencyService : ICurrencyService {
    private readonly IHttpService _http;
    public CurrencyService(IHttpService http) {
        _http = http;
    }
}