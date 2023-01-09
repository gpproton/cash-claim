using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Recent : BaseResponse {
    public Recent(EventResponse? alert, ClaimResponse? claim, Payment? payment) {
        Alert = alert;
        Claim = claim;
        Payment = payment;
    }

    public EventResponse? Alert { get; set; }
    public ClaimResponse? Claim { get; set; }
    public Payment? Payment { get; set; }
}