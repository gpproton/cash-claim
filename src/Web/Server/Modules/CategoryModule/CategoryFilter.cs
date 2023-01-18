using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryFilter : GenericFilter {
    [CompareTo("Name")]
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}