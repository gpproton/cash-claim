using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ICompanyService {
    Task<List<CompanyResponse>> GetAllAsync();
    
    Task<CompanyResponse> GetByIdAsync(Guid id);
    
    Task<CompanyResponse> CreateAsync(CompanyResponse company);
    
    Task<CompanyResponse> UpdateAsync(CompanyResponse company);
    
    Task<CompanyResponse> ArchiveAsync(Guid id);
    
    Task<List<CompanyResponse>> ArchiveRangeAsync(List<Guid> ids);
}