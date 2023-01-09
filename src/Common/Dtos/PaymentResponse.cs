using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class PaymentResponse : BaseResponse {
    public PaymentResponse(decimal? amount, User? owner, DateTime? completedAt, ICollection<ClaimResponse>? claims) {
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public decimal? Amount { get; set; }
    public User? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<ClaimResponse>? Claims { get; set; }
}