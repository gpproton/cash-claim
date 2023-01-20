using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class ClaimService : IClaimService {
    private const string RootApi = "api/v1/claim";
    private readonly IHttpService _http;

    public ClaimService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<ClaimResponse>>>(RootApi, query);
    }
    public async Task<PagedResponse<List<ClaimResponse>>> GetReviewsAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<ClaimResponse>>>(RootApi, query);
    }
    public async Task<Response<ClaimResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<ClaimResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<ClaimResponse>> CreateAsync(ClaimResponse claim) {
        return await _http.Post<Response<ClaimResponse>>(RootApi, claim);
    }
    public async Task<Response<ClaimResponse>> UpdateAsync(ClaimResponse claim) {
        return await _http.Put<Response<ClaimResponse>>(RootApi, claim);
    }
    public async Task<Response<ClaimResponse>> ReviewAsync(ClaimResponse claim) {
        return await _http.Put<Response<ClaimResponse>>(RootApi, claim);
    }
    public async Task<Response<ClaimResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<ClaimResponse>>($"{RootApi}/{id}");
    }
}