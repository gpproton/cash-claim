using AutoFilterer.Types;
using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Service.Modules.PaymentModule;

public interface IPaymentService {
    Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(PaginationFilterBase responseFilter);

    Task<Response<PaymentResponse?>> GetByIdAsync(Guid id);
    
    Task<PagedResponse<List<PaymentStateResponse>>> GetAllTransactionAsync(PaymentFilter filter);
    
    Task<Response<PaymentStateResponse?>> GetTransactionByIdAsync(Guid id);
    
    Task<Response<PaymentStateResponse>> CreateTransactionAsync(PaymentResponse value, List<Guid> claims);
    
    Task<Response<PaymentStateResponse>> UpdateTransactionAsync(Guid id, PaymentResponse value, List<Guid> claims);
    
    Task<Response<bool>> ConfirmAsync(Guid id);
    
    Task<Response<List<PaymentStateResponse>>> RangedConfirmAsync(List<Guid> ids);
    
    Task<Response<PaymentStateResponse?>> CancelAsync(Guid id);
    
    Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid paymentId, PaginationFilterBase requestFilter);
    
    Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid paymentId, PaginationFilterBase requestFilter);
}