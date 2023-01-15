using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class ClaimService : IClaimService {
    private readonly IHttpService _http;
    public ClaimService(IHttpService http) {
        _http = http;
    }
}