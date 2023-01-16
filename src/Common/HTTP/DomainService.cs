using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class DomainService : IDomainService {
    private const string RootApi = "api/v1/domain";
    private readonly IHttpService _http;
    
    public DomainService(IHttpService http) {
        _http = http;
    }
    public async Task<List<DomainResponse>> GetAllAsync() {
        return await _http.Get<List<DomainResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    public async Task<DomainResponse> GetByIdAsync(Guid id) {
        return await _http.Get<DomainResponse>($"{RootApi}/{id}");
    }
    public async Task<DomainResponse> CreateAsync(DomainResponse domain) {
        return await _http.Post<DomainResponse>(RootApi, domain);
    }
    public async Task<DomainResponse> UpdateAsync(DomainResponse domain) {
        return await _http.Put<DomainResponse>(RootApi, domain);
    }
    public async Task<DomainResponse> ArchiveAsync(Guid id) {
        return await _http.Delete<DomainResponse>($"{RootApi}/{id}");
    }
    public async Task<List<DomainResponse>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<List<DomainResponse>>(RootApi, ids);
    }
}