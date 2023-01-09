using XClaim.Common.Base;
using XClaim.Common.Entities;

namespace XClaim.Common.Dtos;

public class PaymentResponse : BaseResponse {
    public PaymentResponse(string decription, decimal? amount, UserResponse? owner, DateTime? completedAt, ICollection<ClaimResponse>? claims) {
        Description = decription;
        Amount = amount;
        Owner = owner;
        CompletedAt = completedAt;
        Claims = claims;
    }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }
    public UserResponse? Owner { get; set; }
    public DateTime? CompletedAt { get; set; }

    public UserEntity? CompletedBy { get; set; }

    public bool Completed {
        get {
            return CompletedAt != null;
        }
    }

    public string? Notes { get; set; }
    public ICollection<ClaimResponse>? Claims { get; set; }
}