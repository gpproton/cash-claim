using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface ICompanyService {
    Task<PagedResponse<List<CompanyResponse>>> GetAllAsync(object? query = null);

    Task<Response<CompanyResponse>> GetByIdAsync(Guid id);

    Task<Response<CompanyResponse>> CreateAsync(CompanyResponse company);

    Task<Response<CompanyResponse>> UpdateAsync(CompanyResponse company);

    Task<Response<CompanyResponse>> ArchiveAsync(Guid id);

    Task<Response<List<CompanyResponse>>> ArchiveRangeAsync(List<Guid> ids);
}