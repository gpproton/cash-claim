namespace CashClaim.Common.Helpers;

public class PaginationFilter {
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 25;
    public string SortBy { get; set; } = "Ascending";
    public string CombineWith { get; set; } = "Or";
}