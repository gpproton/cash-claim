using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public class EventEntity : BaseEntity {
    public EventType Type { get; set; } = EventType.Claim;
    public ClaimEntity? Claim { get; set; }
    public PaymentEntity? Payment { get; set; }
    public string Description { get; set; } = string.Empty;
}