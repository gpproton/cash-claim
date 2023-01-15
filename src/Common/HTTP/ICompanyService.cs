using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ICompanyService {
    Task<List<CompanyResponse>> GetAllAsync();
}