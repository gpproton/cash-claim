using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class Payment : BaseResponse {
    public Payment(decimal? amount, User? owner, DateTime? completedAt, ICollection<Claim>? claims) {
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public decimal? Amount { get; set; }
    public User? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<Claim>? Claims { get; set; }
}