using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.AnalysisModule;

public class AnalysisRepository : IAnalysisRepository {
    public Task<List<ClaimEntity>> GetClaimPayments() {
        throw new NotImplementedException();
    }

    public Task<List<PaymentEntity>> GetRecentPayments() {
        throw new NotImplementedException();
    }

    public Task<List<PaymentEntity>> GetPendingPayments() {
        throw new NotImplementedException();
    }
}