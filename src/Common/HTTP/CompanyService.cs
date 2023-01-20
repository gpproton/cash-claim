using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class CompanyService : ICompanyService {
    private const string RootApi = "api/v1/company";
    private readonly IHttpService _http;
    
    public CompanyService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<CompanyResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<CompanyResponse>>>(RootApi, query);
    }
    public async Task<Response<CompanyResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<CompanyResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<CompanyResponse>> CreateAsync(CompanyResponse bank) {
        return await _http.Post<Response<CompanyResponse>>(RootApi, bank);
    }
    public async Task<Response<CompanyResponse>> UpdateAsync(CompanyResponse bank) {
        return await _http.Put<Response<CompanyResponse>>(RootApi, bank);
    }
    public async Task<Response<CompanyResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<CompanyResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<CompanyResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<CompanyResponse>>>(RootApi, ids);
    }
}