using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyFilter : GenericFilter {
    [CompareTo(nameof(CompanyResponse.ShortName), nameof(CompanyResponse.FullName))]
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
    
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? ShortName { get; set; }
    
    [StringFilterOptions(StringFilterOption.Contains)]
    [ToLowerContainsComparison]
    public string? FullName { get; set; }
}