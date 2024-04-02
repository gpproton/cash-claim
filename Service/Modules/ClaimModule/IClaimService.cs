using AutoFilterer.Types;
using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using CashClaim.Common.Wrappers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ClaimModule;

public interface IClaimService {
    public Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(ClaimFilter filter);

    public Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id);

    Task<Response<ClaimStateResponse?>> ReviewValidateAsync(Guid id, ClaimStatus action, CommentResponse comment);
    
    Task<PagedResponse<List<UserResponse>>> GetPendingUserAsync(UserFilter requestFilter);
    
    Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid claimId, PaginationFilterBase requestFilter);
    
    Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid claimId, PaginationFilterBase requestFilter);
}