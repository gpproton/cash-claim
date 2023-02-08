using AutoFilterer.Types;
using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.ClaimModule;

public interface IClaimService {
    public Task<PagedResponse<List<ClaimResponse>>> GetReviewsAsync(PaginationFilterBase responseFilter);

    public Task<Response<ClaimResponse?>> ReviewAsync(Guid id);
}