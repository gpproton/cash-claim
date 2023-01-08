using AutoFilterer.Enums;
using AutoFilterer.Types;

namespace XClaim.Web.Server.Modules;

public class GenericFilter : PaginationFilterBase {
    public override int Page { get; set; } = 1;
    public override string? Sort { get; set; }
    public override int PerPage { get; set; } = 25;
    public override Sorting SortBy { get; set; } = Sorting.Descending;
    public override CombineType CombineWith { get; set; } = CombineType.Or;
}