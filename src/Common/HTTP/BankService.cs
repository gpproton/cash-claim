using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class BankService : IBankService {
    private readonly IHttpService _http;

    public BankService(IHttpService http) {
        _http = http;
    }
    public async Task<List<BankResponse>> GetAllAsync() {
        return await _http.Get<List<BankResponse>>("api/v1/bank" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    public async Task<BankResponse> GetByIdAsync(Guid id) {
        return await _http.Get<BankResponse>($"api/v1/bank/{id}");
    }
    public async Task<BankResponse> CreateAsync(BankResponse bank) {
        return await _http.Post<BankResponse>($"api/v1/bank", bank);
    }
    public async Task<BankResponse> UpdateAsync(BankResponse bank) {
        return await _http.Put<BankResponse>($"api/v1/bank", bank);
    }
    public async Task<BankResponse> ArchiveAsync(Guid id) {
        return await _http.Delete<BankResponse>($"api/v1/bank/{id}");
    }
}