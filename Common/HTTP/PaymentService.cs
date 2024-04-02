using XClaim.Common.Dtos;
using XClaim.Common.Service;
using XClaim.Common.Wrappers;

namespace XClaim.Common.HTTP;

public class PaymentService : IPaymentService {
    private const string RootApi = "api/v1/payment";
    private readonly IHttpService _http;

    public PaymentService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<PaymentResponse>>>(RootApi, query);
    }
    
    public async Task<Response<PaymentResponse?>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<PaymentResponse?>>($"{RootApi}/{id}");
    }
    
    public async Task<PagedResponse<List<PaymentResponse>>> GetAllTransactionAsync(object? query = null) {
        throw new NotImplementedException();
    }
    
    public async Task<PagedResponse<PaymentResponse?>> GetTransactionByIdAsync(Guid id) {
        throw new NotImplementedException();
    }
    
    public async Task<PagedResponse<PaymentResponse>> CreateTransactionAsync(Guid id, List<Guid> claims) {
        throw new NotImplementedException();
    }
    
    public async Task<PagedResponse<PaymentResponse>> UpdateTransactionAsync(Guid id, List<Guid> claims) {
        throw new NotImplementedException();
    }
    
    public async Task<Response<PaymentResponse>> ConfirmAsync(Guid id) {
        throw new NotImplementedException();
    }
    
    public async Task<Response<List<PaymentResponse>>> RangedConfirmAsync(List<Guid> ids) {
        throw new NotImplementedException();
    }
    
    public async Task<Response<PaymentResponse?>> CancelAsync(Guid id) {
        throw new NotImplementedException();
    }
}