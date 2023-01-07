namespace XClaim.Common.Dtos;

public record Comment {
    public Comment(Claim? claim, Payment? payment, User? owner, string? content) {
        Claim = claim;
        Payment = payment;
        Owner = owner;
        Content = content;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Claim? Claim { get; set; }
    public Payment? Payment { get; set; }
    public User? Owner { get; set; }
    public string? Content { get; set; }
}