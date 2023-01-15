using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ICategoryService {
    Task<List<CategoryResponse>> GetAllAsync();
}