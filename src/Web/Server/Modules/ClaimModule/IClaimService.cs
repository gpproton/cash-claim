using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ClaimModule;

public interface IClaimService {
    public Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(ClaimFilter filter);

    public Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id);

    Task<Response<ClaimStateResponse?>> ReviewValidateAsync(Guid id, ClaimStatus action, CommentResponse comment);
    
    Task<PagedResponse<List<UserResponse>>> GetPendingClaimUserListAsync(UserFilter requestFilter);
    
    Task<Response<List<FileResponse>>> GetFileAsync(Guid claimId);
    
    Task<Response<List<CommentResponse>>> GetCommentAsync(Guid claimId);
}