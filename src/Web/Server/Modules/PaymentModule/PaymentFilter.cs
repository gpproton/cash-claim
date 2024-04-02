using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.PaymentModule;

public sealed class PaymentFilter : GenericFilter {
    [CompareTo(nameof(PaymentEntity.Description), nameof(PaymentEntity.Notes), CombineWith = CombineType.Or)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }

    [CompareTo(nameof(PaymentEntity.CreatedAt))]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo(nameof(PaymentEntity.CreatedAt))]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}