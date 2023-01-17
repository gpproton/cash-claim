using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class BankService : IBankService {
    private const string RootApi = "api/v1/bank";
    private readonly IHttpService _http;

    public BankService(IHttpService http) {
        _http = http;
    }
    public async Task<List<BankResponse>> GetAllAsync() {
        return await _http.Get<List<BankResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    public async Task<BankResponse> GetByIdAsync(Guid id) {
        return await _http.Get<BankResponse>($"{RootApi}/{id}");
    }
    public async Task<BankResponse> CreateAsync(BankResponse bank) {
        return await _http.Post<BankResponse>(RootApi, bank);
    }
    public async Task<BankResponse> UpdateAsync(BankResponse bank) {
        return await _http.Put<BankResponse>(RootApi, bank);
    }
    public async Task<BankResponse> ArchiveAsync(Guid id) {
        return await _http.Delete<BankResponse>($"{RootApi}/{id}");
    }
    public async Task<List<BankResponse>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<List<BankResponse>>(RootApi, ids);
    }
}