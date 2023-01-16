using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IClaimService {
    Task<List<ClaimResponse>> GetAllAsync();
    
    Task<List<ClaimResponse>> GetReviewsAsync();
}