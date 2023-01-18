using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.BankModule;

public class BankFilter : GenericFilter {
    [CompareTo("Name")]
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}