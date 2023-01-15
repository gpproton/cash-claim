using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CurrencyService : ICurrencyService {
    private readonly IHttpService _http;
    public CurrencyService(IHttpService http) {
        _http = http;
    }
    public async Task<List<CurrencyResponse>> GetAllAsync() {
        return await _http.Get<List<CurrencyResponse>>("api/v1/currency" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}