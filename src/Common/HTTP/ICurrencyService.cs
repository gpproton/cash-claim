using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ICurrencyService {
    Task<List<CurrencyResponse>> GetAllAsync();
    
    Task<CurrencyResponse> GetByIdAsync(Guid id);
    
    Task<CurrencyResponse> CreateAsync(CurrencyResponse currency);
    
    Task<CurrencyResponse> UpdateAsync(CurrencyResponse currency);
    
    Task<CurrencyResponse> ArchiveAsync(Guid id);
    
    Task<List<CurrencyResponse>> ArchiveRangeAsync(List<Guid> ids);
}