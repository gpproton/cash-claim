using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CurrencyService : ICurrencyService {
    private const string RootApi = "api/v1/currency";
    private readonly IHttpService _http;
    
    public CurrencyService(IHttpService http) {
        _http = http;
    }
    public async Task<List<CurrencyResponse>> GetAllAsync() {
        return await _http.Get<List<CurrencyResponse>>(RootApi + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    public async Task<CurrencyResponse> GetByIdAsync(Guid id) {
        return await _http.Get<CurrencyResponse>($"{RootApi}/{id}");
    }
    public async Task<CurrencyResponse> CreateAsync(CurrencyResponse currency) {
        return await _http.Post<CurrencyResponse>(RootApi, currency);
    }
    public async Task<CurrencyResponse> UpdateAsync(CurrencyResponse currency) {
        return await _http.Put<CurrencyResponse>(RootApi, currency);
    }
    public async Task<CurrencyResponse> ArchiveAsync(Guid id) {
        return await _http.Delete<CurrencyResponse>($"{RootApi}/{id}");
    }
    public async Task<List<CurrencyResponse>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<List<CurrencyResponse>>(RootApi, ids);
    }
}