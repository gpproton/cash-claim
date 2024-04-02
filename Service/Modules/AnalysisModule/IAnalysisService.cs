using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.AnalysisModule;

public interface IAnalysisService {
    public Task<List<ClaimEntity>> GetClaimPayments();
    public Task<List<PaymentEntity>> GetRecentPayments();
    public Task<List<PaymentEntity>> GetPendingPayments();
}