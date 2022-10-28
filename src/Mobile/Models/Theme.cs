namespace XClaim.Mobile.Models;

public sealed class Theme {
    public static readonly Theme Dark = new Theme(AppTheme.Dark, "Night Mode");
    public static readonly Theme Light = new Theme(AppTheme.Light, "Day Mode");
    public static readonly Theme System = new Theme(AppTheme.Unspecified, "Follow System");

    public static List<Theme> AvailableThemes { get; } = new List<Theme> {
        Dark,
        Light,
        System
    };

    public AppTheme AppTheme { get; }
    public string DisplayName { get; }

    Theme(AppTheme theme, string displayName) {
        AppTheme = theme;
        DisplayName = displayName;
    }
}
