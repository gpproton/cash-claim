using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class ClaimResponse : BaseResponse {
    public string Description { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public CategoryResponse? Category { get; set; }
    public CompanyResponse? Company { get; set; }
    public ClaimStatus Status { get; set; }
    public UserResponse? Owner { get; set; }
    public UserResponse? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public UserResponse? ConfirmedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserResponse? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<FileResponse> Files { get; set; } = default!;
}