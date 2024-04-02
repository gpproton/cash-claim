using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface IDomainService {
    Task<PagedResponse<List<DomainResponse>>> GetAllAsync(object? query = null);

    Task<Response<DomainResponse>> GetByIdAsync(Guid id);

    Task<Response<DomainResponse>> CreateAsync(DomainResponse bank);

    Task<Response<DomainResponse>> UpdateAsync(DomainResponse bank);

    Task<Response<DomainResponse>> ArchiveAsync(Guid id);

    Task<Response<List<DomainResponse>>> ArchiveRangeAsync(List<Guid> ids);
}