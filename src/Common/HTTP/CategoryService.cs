using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CategoryService : ICategoryService {
    private readonly IHttpService _http;
    public CategoryService(IHttpService http) {
        _http = http;
    }
}