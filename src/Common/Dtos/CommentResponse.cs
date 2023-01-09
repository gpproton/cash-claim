using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class CommentResponse : BaseResponse {
    public CommentResponse(ClaimResponse? claim, PaymentResponse? payment, UserResponse? owner, string? content) {
        Claim = claim;
        Payment = payment;
        Owner = owner;
        Content = content;
    }

    public ClaimResponse? Claim { get; set; }
    public PaymentResponse? Payment { get; set; }
    public UserResponse? Owner { get; set; }
    public string? Content { get; set; }
}