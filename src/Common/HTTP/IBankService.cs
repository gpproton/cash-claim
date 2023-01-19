using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IBankService {
    Task<PagedResponse<List<BankResponse>>> GetAllAsync(object? query = null);

    Task<Response<BankResponse>> GetByIdAsync(Guid id);
    
    Task<Response<BankResponse>> CreateAsync(BankResponse bank);
    
    Task<Response<BankResponse>> UpdateAsync(BankResponse bank);
    
    Task<Response<BankResponse>> ArchiveAsync(Guid id);
    
    Task<Response<List<BankResponse>>> ArchiveRangeAsync(List<Guid> ids);
}