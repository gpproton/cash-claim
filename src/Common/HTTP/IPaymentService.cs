using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public interface IPaymentService {
    Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(object? query = null);

    Task<PagedResponse<List<PaymentResponse>>> GetTransactionsAsync(object? query = null);

    Task<Response<PaymentResponse>> GetByIdAsync(Guid id);

    Task<Response<PaymentResponse>> CompleteAsync(Guid id);
}