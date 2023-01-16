using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class ClaimService : IClaimService {
    private readonly IHttpService _http;
    public ClaimService(IHttpService http) {
        _http = http;
    }
    public async Task<List<ClaimResponse>> GetAllAsync() {
        return await _http.Get<List<ClaimResponse>>("api/v1/claim" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    
    public async Task<List<ClaimResponse>> GetReviewsAsync() {
        return await _http.Get<List<ClaimResponse>>("api/v1/claim" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}