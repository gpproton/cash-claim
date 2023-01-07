using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record EventDto {
    public EventDto(EventType type, Claim? claim, Payment? payment, string? description) {
        Type = type;
        Claim = claim;
        Payment = payment;
        Description = description;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public EventType Type { get; set; } = EventType.Claim;
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
    public string? Description { get; set; }
}