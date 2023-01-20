using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class CategoryService : ICategoryService {
    private const string RootApi = "api/v1/category";
    private readonly IHttpService _http;
    
    public CategoryService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<CategoryResponse>>> GetAllAsync(object? query = null) =>
        await _http.Get<PagedResponse<List<CategoryResponse>>>(RootApi, query);
    
    public async Task<Response<CategoryResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<CategoryResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<CategoryResponse>> CreateAsync(CategoryResponse bank) {
        return await _http.Post<Response<CategoryResponse>>(RootApi, bank);
    }
    public async Task<Response<CategoryResponse>> UpdateAsync(CategoryResponse bank) {
        return await _http.Put<Response<CategoryResponse>>(RootApi, bank);
    }
    public async Task<Response<CategoryResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<CategoryResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<CategoryResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<CategoryResponse>>>(RootApi, ids);
    }
}