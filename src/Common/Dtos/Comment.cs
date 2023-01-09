using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Comment : BaseResponse {
    public Comment(ClaimResponse? claim, Payment? payment, User? owner, string? content) {
        Claim = claim;
        Payment = payment;
        Owner = owner;
        Content = content;
    }

    public ClaimResponse? Claim { get; set; }
    public Payment? Payment { get; set; }
    public User? Owner { get; set; }
    public string? Content { get; set; }
}