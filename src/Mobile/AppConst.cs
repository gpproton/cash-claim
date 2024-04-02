namespace XClaim.Mobile;

public static class AppConst {
    // Auth details
    public const string AppId = "xclaim";
    public const string AppUId = "dev.gpproton.xclaim";
    public static readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
        ? "https://10.0.2.2:7001" : "https://localhost:7001";
    public static readonly string AuthUri = $"{BaseAddress}/auth/sign-in/mobile";

    // Shared constants
    public const string Naira = "₦";
    public const string WelcomeGreeting = "Get Started";
    public const string EmptyListText = "No item to display";
    public const string DateTitleText = "Select date range";
    public const string DateStartText = "Start Date";
    public const string DateEndText = "End Date";

    // Home view constants
    public const string HomeGreeting = "Hello";
    public const string HomeCardText = "Pending Claims";
    public const string HomeRecentTitle = "Recents";
    public const string HomeRecentLink = "See all";
    public const string HomeActionText = "New Claim";
}