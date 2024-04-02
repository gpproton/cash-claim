using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class CurrencyService : ICurrencyService {
    private const string RootApi = "api/v1/currency";
    private readonly IHttpService _http;

    public CurrencyService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<CurrencyResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<CurrencyResponse>>>(RootApi, query);
    }
    public async Task<Response<CurrencyResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<CurrencyResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<CurrencyResponse>> CreateAsync(CurrencyResponse bank) {
        return await _http.Post<Response<CurrencyResponse>>(RootApi, bank);
    }
    public async Task<Response<CurrencyResponse>> UpdateAsync(CurrencyResponse bank) {
        return await _http.Put<Response<CurrencyResponse>>(RootApi, bank);
    }
    public async Task<Response<CurrencyResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<CurrencyResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<CurrencyResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<CurrencyResponse>>>(RootApi, ids);
    }
}