using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.AnalysisModule;

public class AnalysisService : IAnalysisService {
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