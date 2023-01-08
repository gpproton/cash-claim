using AutoFilterer.Attributes;
using AutoFilterer.Enums;

namespace XClaim.Web.Server.Modules.TeamModule;

public class TeamFilter : GenericFilter {
    [CompareTo("Name")]
    [StringFilterOptions(StringFilterOption.Contains)]
    public string? Search { get; set; }
}