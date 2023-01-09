using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.PaymentModule;

public class PaymentFilter : GenericFilter {
    [CompareTo("CreatedAt")]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }

    [CompareTo("CreatedAt")]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
}