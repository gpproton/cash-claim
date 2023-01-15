using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class DomainService : IDomainService {
    private readonly IHttpService _http;
    public DomainService(IHttpService http) {
        _http = http;
    }
}