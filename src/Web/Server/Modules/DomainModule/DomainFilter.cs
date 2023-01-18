using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.DomainModule;

public class DomainFilter : GenericFilter {
    [CompareTo("Address")]
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}