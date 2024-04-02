namespace CashClaim.Common.Helpers;

public class DateSearchFilter : SearchFilter {
    public DateTime? StartDate { get; set; } = SharedConst.StartDate;
    public DateTime? EndDate { get; set; } = SharedConst.EndDate;
}