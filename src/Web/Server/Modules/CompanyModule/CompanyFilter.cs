using AutoFilterer.Attributes;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyFilter : GenericFilter {
    [CompareTo(nameof(CompanyEntity.ShortName), nameof(CompanyEntity.FullName))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}