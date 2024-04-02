using AutoFilterer.Attributes;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.CategoryModule;

public class CategoryFilter : GenericFilter {
    [CompareTo(nameof(CategoryEntity.Name), nameof(CategoryEntity.Description))]
    [ToLowerContainsComparison]
    public virtual string? Search { get; set; }
}