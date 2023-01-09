using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class EventResponse : BaseResponse {
    public EventResponse(ClaimResponse? claim, PaymentResponse? payment, string? description, EventType type = EventType.Claim) {
        Type = type;
        Claim = claim;
        Payment = payment;
        Description = description;
    }

    public EventType Type { get; set; }
    public ClaimResponse? Claim { get; set; }
    public PaymentResponse? Payment { get; set; }
    public string? Description { get; set; }
}