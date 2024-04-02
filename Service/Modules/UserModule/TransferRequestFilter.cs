using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using CashClaim.Service.Entities;
using CashClaim.Service.Modules;

public sealed class TransferRequestFilter : GenericFilter {
    [CompareTo(nameof(TransferRequestEntity.CreatedAt))]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo(nameof(TransferRequestEntity.CreatedAt))]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}