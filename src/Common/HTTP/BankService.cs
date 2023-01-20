using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class BankService : IBankService {
    private const string RootApi = "api/v1/bank";
    private readonly IHttpService _http;

    public BankService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<BankResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<BankResponse>>>(RootApi, query);
    }
    public async Task<Response<BankResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<BankResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<BankResponse>> CreateAsync(BankResponse bank) {
        return await _http.Post<Response<BankResponse>>(RootApi, bank);
    }
    public async Task<Response<BankResponse>> UpdateAsync(BankResponse bank) {
        return await _http.Put<Response<BankResponse>>(RootApi, bank);
    }
    public async Task<Response<BankResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<BankResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<BankResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<BankResponse>>>(RootApi, ids);
    }
}