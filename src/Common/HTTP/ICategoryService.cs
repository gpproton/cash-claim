using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface ICategoryService {
    Task<PagedResponse<List<CategoryResponse>>> GetAllAsync(object? query = null);
    
    Task<Response<CategoryResponse>> GetByIdAsync(Guid id);
    
    Task<Response<CategoryResponse>> CreateAsync(CategoryResponse bank);
    
    Task<Response<CategoryResponse>> UpdateAsync(CategoryResponse bank);
    
    Task<Response<CategoryResponse>> ArchiveAsync(Guid id);
    
    Task<Response<List<CategoryResponse>>> ArchiveRangeAsync(List<Guid> ids);
}