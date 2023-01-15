using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IBankService {
    Task<List<BankResponse>> GetBanksAsync();
}