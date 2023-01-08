using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using XClaim.Common.Enums;

namespace XClaim.Web.Server.Modules.ClaimModule;

public class ClaimFilter : GenericFilter {
    [CompareTo("Description","Notes", CombineWith = CombineType.And)]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Search { get; set; }
    
    public ClaimStatus[]? Status { get; set; }
    
    [CompareTo("CreatedAt")]
    [OperatorComparison(OperatorType.GreaterThanOrEqual)]
    public DateTime? StartDate { get; set; }
    
    [CompareTo("CreatedAt")]
    [OperatorComparison(OperatorType.LessThanOrEqual)]
    public DateTime? EndDate { get; set; }
    
    
}