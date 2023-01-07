namespace XClaim.Common.Dtos;

public record Payment {
    public Payment(decimal? amount, User? owner, DateTime? completedAt, ICollection<Claim>? claims) {
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal? Amount { get; set; }
    public User? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<Claim>? Claims { get; set; }
}