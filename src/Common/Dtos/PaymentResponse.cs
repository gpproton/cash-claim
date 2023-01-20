using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class PaymentResponse : BaseResponse {
    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; }
    public UserResponse? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public DateTime? CompletedAt { get; set; }

    public UserResponse? CompletedBy { get; set; }

    public bool Completed {
        get {
            return CompletedAt != null;
        }
    }

    public string Notes { get; set; }  = string.Empty;
    public ICollection<ClaimResponse> Claims { get; set; } = default!;
}