using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CompanyService : ICompanyService {
    private readonly IHttpService _http;
    public CompanyService(IHttpService http) {
        _http = http;
    }
    public async Task<List<CompanyResponse>> GetAllAsync() {
        return await _http.Get<List<CompanyResponse>>("api/v1/company" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}