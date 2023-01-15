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
}