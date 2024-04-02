using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Common.Dtos;

public class ClaimResponse : BaseResponse {
    public string Description { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal Amount { get; set; } = 100;
    public ClaimPriority Priority { get; set; } = ClaimPriority.Normal;
    public CategoryResponse? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public CompanyResponse? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public CurrencyResponse? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public UserResponse? Owner { get; set; }
    public UserResponse? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public UserResponse? ConfirmedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserResponse? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<FileResponse> Files { get; set; } = default!;
}