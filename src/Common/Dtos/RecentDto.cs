namespace XClaim.Common.Dtos;

public record RecentDto {
    public RecentDto(EventDto? alert, ClaimDto? claim, PaymentDto? payment) {
        Alert = alert;
        Claim = claim;
        Payment = payment;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public EventDto? Alert { get; set; }
    public ClaimDto? Claim { get; set; }
    public PaymentDto? Payment { get; set; }
}