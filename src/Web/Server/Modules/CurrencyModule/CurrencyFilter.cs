using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.CurrencyModule;

public class CurrencyFilter : GenericFilter {
    [CompareTo("Name")]
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}