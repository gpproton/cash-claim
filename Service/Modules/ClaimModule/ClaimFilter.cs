using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using CashClaim.Common.Enums;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.ClaimModule;

public sealed class ClaimFilter : GenericFilter {
    [CompareTo(nameof(ClaimEntity.Description), nameof(ClaimEntity.Notes), CombineWith = CombineType.Or)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }

    public ClaimStatus[]? Status { get; set; }

    [CompareTo(nameof(ClaimEntity.CreatedAt))]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo(nameof(ClaimEntity.CreatedAt))]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}