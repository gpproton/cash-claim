using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public class EventFilter : GenericFilter {
    [CompareTo(nameof(EventEntity.CreatedAt))]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo(nameof(EventEntity.CreatedAt))]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}