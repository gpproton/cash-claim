using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class PaymentService : IPaymentService {
    private const string RootApi = "api/v1/payment";
    private readonly IHttpService _http;
    
    public PaymentService(IHttpService http) {
        _http = http;
    }
    public async Task<List<PaymentResponse>> GetAllAsync() {
        return await _http.Get<List<PaymentResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    public async Task<List<PaymentResponse>> GetTransactionsAsync() {
        return await _http.Get<List<PaymentResponse>>($"{RootApi}?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
}