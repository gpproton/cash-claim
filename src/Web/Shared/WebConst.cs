using MudBlazor;

namespace XClaim.Web.Shared;

public static class WebConst {
    public const string RootApi = "/api/v1";
    public const string RootUri = "https://localhost:7001";
    public const string ApiAuth = "auth/sign-in";
    public const string AppHome = "app/overview";
    public const string AppAuth = "app/auth";
    public const string AppRegister = "app/registration";
    public static readonly DateRange AppDateRange = new DateRange(DateTime.Now.AddDays(-7).Date, DateTime.Now.Date);
    public static readonly int[] AppPaged = new [] { 25, 100, 250, 2000 };
}