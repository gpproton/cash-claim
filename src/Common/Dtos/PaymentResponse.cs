using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class PaymentResponse : BaseResponse {
    public PaymentResponse(decimal? amount, UserResponse? owner, DateTime? completedAt, ICollection<ClaimResponse>? claims) {
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public decimal? Amount { get; set; }
    public UserResponse? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<ClaimResponse>? Claims { get; set; }
}