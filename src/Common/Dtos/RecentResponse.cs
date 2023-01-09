using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class RecentResponse : BaseResponse {
    public RecentResponse(EventResponse? alert, ClaimResponse? claim, PaymentResponse? payment) {
        Alert = alert;
        Claim = claim;
        Payment = payment;
    }

    public EventResponse? Alert { get; set; }
    public ClaimResponse? Claim { get; set; }
    public PaymentResponse? Payment { get; set; }
}