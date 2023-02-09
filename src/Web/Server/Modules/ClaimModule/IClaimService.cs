using AutoFilterer.Types;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.ClaimModule;

public interface IClaimService {
    public Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(ClaimFilter filter);

    public Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id);

    Task<Response<ClaimStateResponse?>> ReviewValidateAsync(Guid id, ClaimStatus action, CommentResponse comment);
}