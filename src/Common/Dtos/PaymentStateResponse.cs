using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class PaymentStateResponse : BaseResponse {
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public bool Confirmed => ConfirmedAt != null;
    public int Count { get; set; }
    public ICollection<ClaimResponse> Claims { get; set; } = default!;
    public ICollection<FileResponse> Files { get; set; } = default!;
}