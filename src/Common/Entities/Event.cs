using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public class Event : BaseEntity {
    public EventType Type { get; set; } = EventType.Claim;
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
    public string? Description { get; set; }
}
