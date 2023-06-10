namespace XClaim.Common; 

public static class SharedConst {
    public const string ServiceName = "x-claim";
    public static int RowsPerPage = 25;
    public static readonly DateTime StartDate = DateTime.Now.AddDays(-7);
    public static readonly DateTime EndDate = DateTime.Now.Date;
}