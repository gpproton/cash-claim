using System.Text;
using System.Web;
using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

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

    public async Task<Response<ClaimResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<ClaimResponse>>($"{RootApi}/{id}");
    }
    public async Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<ClaimStateResponse>>>($"{RootApi}/review", query);
    }
    public async Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id) {
        return await _http.Get<Response<ClaimStateResponse?>>($"{RootApi}/review/{id}");
    }
    public async Task<Response<ClaimStateResponse>> CancelReviewAsync(Guid id) {
        return await _http.Put<Response<ClaimStateResponse>>($"{RootApi}/review/cancel/{id}");
    }
    public async Task<Response<ClaimStateResponse>> RejectReviewAsync(Guid id, string comment) {
        var uri = $"{RootApi}/review/reject/{id}";
        return await _http.Put<Response<ClaimStateResponse>>(uri, new CommentResponse { Content = comment});
    }
    public async Task<Response<ClaimStateResponse>> ValidateReviewAsync(Guid id, string comment) {
    var uri = $"{RootApi}/review/validate/{id}";
        return await _http.Put<Response<ClaimStateResponse>>(uri, new CommentResponse { Content = comment});
    }
    public async Task<PagedResponse<List<UserResponse>>> GetPendingUserAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<UserResponse>>>($"{RootApi}/pending-users", query);
    }
    public async Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid claimId, object? query = null) {
        return await _http.Get<PagedResponse<List<FileResponse>>>($"{RootApi}/file/{claimId}", query);
    }
    public async Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid claimId, object? query = null) {
        return await _http.Get<PagedResponse<List<CommentResponse>>>($"{RootApi}/file/{claimId}", query);
    }
}