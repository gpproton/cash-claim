using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CompanyService : ICompanyService {
    private readonly IHttpService _http;
    public CompanyService(IHttpService http) {
        _http = http;
    }
}