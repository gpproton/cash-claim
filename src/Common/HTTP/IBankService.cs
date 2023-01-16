using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IBankService {
    Task<List<BankResponse>> GetAllAsync();

    Task<BankResponse> GetByIdAsync(Guid id);
    
    Task<BankResponse> CreateAsync(BankResponse bank);
    
    Task<BankResponse> UpdateAsync(BankResponse bank);
    
    Task<BankResponse> ArchiveAsync(Guid id);
    
}