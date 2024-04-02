using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface IPaymentService {
    Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(object? query = null);

    Task<Response<PaymentResponse?>> GetByIdAsync(Guid id);

    Task<PagedResponse<List<PaymentResponse>>> GetAllTransactionAsync(object? query = null);

    Task<PagedResponse<PaymentResponse?>> GetTransactionByIdAsync(Guid id);

    Task<PagedResponse<PaymentResponse>> CreateTransactionAsync(Guid id, List<Guid> claims);

    Task<PagedResponse<PaymentResponse>> UpdateTransactionAsync(Guid id, List<Guid> claims);

    Task<Response<PaymentResponse>> ConfirmAsync(Guid id);

    Task<Response<List<PaymentResponse>>> RangedConfirmAsync(List<Guid> ids);

    Task<Response<PaymentResponse?>> CancelAsync(Guid id);
}