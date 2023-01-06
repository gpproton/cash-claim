namespace XClaim.Common.Dtos;

public record PaymentDto {
    public PaymentDto(decimal? amount, UserDto? owner, DateTime? completedAt, ICollection<ClaimDto>? claims) {
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal? Amount { get; set; }
    public UserDto? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<ClaimDto>? Claims { get; set; }
}