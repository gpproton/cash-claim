using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IDomainService {
    Task<List<DomainResponse>> GetAllAsync();
    
    Task<DomainResponse> GetByIdAsync(Guid id);
    
    Task<DomainResponse> CreateAsync(DomainResponse domain);
    
    Task<DomainResponse> UpdateAsync(DomainResponse domain);
    
    Task<DomainResponse> ArchiveAsync(Guid id);
    
    Task<List<DomainResponse>> ArchiveRangeAsync(List<Guid> ids);
}