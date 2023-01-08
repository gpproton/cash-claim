using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class EventResponse : BaseResponse {
    public EventResponse(Claim? claim, Payment? payment, string? description, EventType type = EventType.Claim) {
        Type = type;
        Claim = claim;
        Payment = payment;
        Description = description;
    }

    public EventType Type { get; set; }
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
    public string? Description { get; set; }
}