using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CategoryService : ICategoryService {
    private readonly IHttpService _http;
    public CategoryService(IHttpService http) {
        _http = http;
    }
    public async Task<List<CategoryResponse>> GetAllAsync() {
        return await _http.Get<List<CategoryResponse>>("api/v1/category" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}