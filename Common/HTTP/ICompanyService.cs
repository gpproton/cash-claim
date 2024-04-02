using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface ICompanyService {
    Task<PagedResponse<List<CompanyResponse>>> GetAllAsync(object? query = null);

    Task<Response<CompanyResponse>> GetByIdAsync(Guid id);

    Task<Response<CompanyResponse>> CreateAsync(CompanyResponse company);

    Task<Response<CompanyResponse>> UpdateAsync(CompanyResponse company);

    Task<Response<CompanyResponse>> ArchiveAsync(Guid id);

    Task<Response<List<CompanyResponse>>> ArchiveRangeAsync(List<Guid> ids);
}