using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface ICurrencyService {
    Task<List<CurrencyResponse>> GetAllAsync();
}