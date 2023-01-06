using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record EventDto {
    public EventDto(EventType type, ClaimDto? claim, PaymentDto? payment, string? description) {
        Type = type;
        Claim = claim;
        Payment = payment;
        Description = description;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public EventType Type { get; set; } = EventType.Claim;
    public ClaimDto? Claim { get; set; }
    public PaymentDto? Payment { get; set; }
    public string? Description { get; set; }
}