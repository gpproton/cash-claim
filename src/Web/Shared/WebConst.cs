using MudBlazor;

namespace XClaim.Web.Shared;

public static class WebConst {
    public const string RootApi = "/api/v1";
    public const string RootUri = "https://localhost:7001";
    public const string ApiAuth = "auth/sign-in";
    public const string AppHome = "app/overview";
    public const string AppAuth = "app/auth";
    public const string AppRegister = "app/registration";
    public const string SessionKey = "UserSession";
    public static readonly DateRange AppDateRange = new DateRange(DateTime.Now.AddDays(-7), DateTime.Now);
    public static readonly int[] AppPaged = { 25, 100, 250, 2000 };
    public const string TableHeight = "calc(100vh - 305px)";
}