using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IClaimService {
    Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(object? query = null);

    Task<PagedResponse<List<ClaimResponse>>> GetReviewsAsync(object? query = null);

    Task<Response<ClaimResponse>> GetByIdAsync(Guid id);

    Task<Response<ClaimResponse>> CreateAsync(ClaimResponse claim);

    Task<Response<ClaimResponse>> UpdateAsync(ClaimResponse claim);

    Task<Response<ClaimResponse>> ArchiveAsync(Guid id);
    
    Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(object? query = null);

    Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id);
    Task<Response<ClaimStateResponse>> CancelReviewAsync(Guid id);
    
    Task<Response<ClaimStateResponse>> RejectReviewAsync(Guid id, string comment);
    
    Task<Response<ClaimStateResponse>> ValidateReviewAsync(Guid id, string comment);
    
    Task<PagedResponse<List<UserResponse>>> GetPendingUserAsync(object? query = null);

    Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid claimId, object? query = null);
    
    Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid claimId, object? query = null);
}