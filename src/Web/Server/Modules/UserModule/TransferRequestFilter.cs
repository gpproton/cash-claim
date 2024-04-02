using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Modules;

public sealed class TransferRequestFilter : GenericFilter {
    [CompareTo(nameof(TransferRequestEntity.CreatedAt))]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo(nameof(TransferRequestEntity.CreatedAt))]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}