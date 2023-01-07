using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record EventResponse : BaseResponse {
    public EventResponse(EventType type, Claim? claim, Payment? payment, string? description) {
        Type = type;
        Claim = claim;
        Payment = payment;
        Description = description;
    }

    public EventType Type { get; set; } = EventType.Claim;
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
    public string? Description { get; set; }
}