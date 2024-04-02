using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Common.Dtos;

public class ClaimStateResponse : BaseResponse {
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? Currency { get; set; } = "$";
    public decimal Amount { get; set; }
    public string? Category { get; set; }
    public ClaimStatus Status { get; set; }
    public string? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public bool Approved { get; set; }
    public bool Completed { get; set; }

    public bool Payed { get; set; }
}