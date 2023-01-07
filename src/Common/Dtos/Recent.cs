namespace XClaim.Common.Dtos;

public record Recent {
    public Recent(EventDto? alert, Claim? claim, Payment? payment) {
        Alert = alert;
        Claim = claim;
        Payment = payment;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public EventDto? Alert { get; set; }
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
}