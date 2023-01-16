using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IPaymentService {
    Task<List<PaymentResponse>> GetAllAsync();
    
    Task<List<PaymentResponse>> GetTransactionsAsync();
}