using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using XClaim.Common.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.ClaimModule;

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