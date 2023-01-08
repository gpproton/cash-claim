using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class Recent : BaseResponse {
    public Recent(EventResponse? alert, Claim? claim, Payment? payment) {
        Alert = alert;
        Claim = claim;
        Payment = payment;
    }

    public EventResponse? Alert { get; set; }
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
}