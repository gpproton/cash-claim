using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public class DomainService : IDomainService {
    private const string RootApi = "api/v1/domain";
    private readonly IHttpService _http;

    public DomainService(IHttpService http) {
        _http = http;
    }

    public async Task<PagedResponse<List<DomainResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<DomainResponse>>>(RootApi, query);
    }
    public async Task<Response<DomainResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<DomainResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<DomainResponse>> CreateAsync(DomainResponse bank) {
        return await _http.Post<Response<DomainResponse>>(RootApi, bank);
    }
    public async Task<Response<DomainResponse>> UpdateAsync(DomainResponse bank) {
        return await _http.Put<Response<DomainResponse>>(RootApi, bank);
    }
    public async Task<Response<DomainResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<DomainResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<DomainResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<DomainResponse>>>(RootApi, ids);
    }
}