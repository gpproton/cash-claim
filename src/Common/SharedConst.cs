namespace XClaim.Common;

public class SharedConst {
    public static int RowsPerPage = 25;
    public static readonly DateTime StartDate = DateTime.Now.AddDays(-7);
    public static readonly DateTime EndDate = DateTime.Now.Date;
}