namespace XClaim.Common.Dtos;

public record CommentDto {
    public CommentDto( ClaimDto? claim, PaymentDto? payment, UserDto? owner, string? content) {
        Claim = claim;
        Payment = payment;
        Owner = owner;
        Content = content;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public ClaimDto? Claim { get; set; }
    public PaymentDto? Payment { get; set; }
    public UserDto? Owner { get; set; }
    public string? Content { get; set; }
}