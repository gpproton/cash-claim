using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class DomainService : IDomainService {
    private readonly IHttpService _http;
    public DomainService(IHttpService http) {
        _http = http;
    }
    public async Task<List<DomainResponse>> GetAllAsync() {
        return await _http.Get<List<DomainResponse>>("api/v1/domain" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}