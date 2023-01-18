using AutoFilterer.Attributes;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryFilter : GenericFilter {
    [CompareTo(nameof(CategoryEntity.Name), nameof(CategoryEntity.Description))]
    [ToLowerContainsComparison]
    public virtual string? Search { get; set; }
}