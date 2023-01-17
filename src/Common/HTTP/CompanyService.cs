using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class CompanyService : ICompanyService {
    private const string RootApi = "api/v1/company";
    private readonly IHttpService _http;
    
    public CompanyService(IHttpService http) {
        _http = http;
    }
    public async Task<List<CompanyResponse>> GetAllAsync() {
        return await _http.Get<List<CompanyResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    
    public async Task<CompanyResponse> GetByIdAsync(Guid id) {
        return await _http.Get<CompanyResponse>($"{RootApi}/{id}");
    }
    public async Task<CompanyResponse> CreateAsync(CompanyResponse company) {
        return await _http.Post<CompanyResponse>(RootApi, company);
    }
    public async Task<CompanyResponse> UpdateAsync(CompanyResponse company) {
        return await _http.Put<CompanyResponse>(RootApi, company);
    }
    public async Task<CompanyResponse> ArchiveAsync(Guid id) {
        return await _http.Delete<CompanyResponse>($"{RootApi}/{id}");
    }
    public async Task<List<CompanyResponse>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<List<CompanyResponse>>(RootApi, ids);
    }
}