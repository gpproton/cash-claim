using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class PaymentService : IPaymentService {
    private readonly IHttpService _http;
    public PaymentService(IHttpService http) {
        _http = http;
    }
}