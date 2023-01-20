using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IClaimService {
    Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(object? query = null);

    Task<PagedResponse<List<ClaimResponse>>> GetReviewsAsync(object? query = null);
    
    Task<Response<ClaimResponse>> GetByIdAsync(Guid id);
    
    Task<Response<ClaimResponse>> CreateAsync(ClaimResponse claim);
    
    Task<Response<ClaimResponse>> UpdateAsync(ClaimResponse claim);
    
    Task<Response<ClaimResponse>> ReviewAsync(ClaimResponse claim);
    
    Task<Response<ClaimResponse>> ArchiveAsync(Guid id);
}