using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.PaymentModule;

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