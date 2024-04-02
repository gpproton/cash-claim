using AutoFilterer.Enums;
using AutoFilterer.Types;

namespace CashClaim.Service.Modules;

public class GenericFilter : PaginationFilterBase {
    public sealed override int Page { get; set; }
    public override string? Sort { get; set; }
    public sealed override int PerPage { get; set; }
    public sealed override Sorting SortBy { get; set; }
    public sealed override CombineType CombineWith { get; set; }
}