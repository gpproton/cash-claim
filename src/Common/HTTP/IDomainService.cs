using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IDomainService {
    Task<List<DomainResponse>> GetAllAsync();
}