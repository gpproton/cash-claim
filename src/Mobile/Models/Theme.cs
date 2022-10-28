namespace XClaim.Mobile.Models;

public sealed class Theme {
    public static Theme Dark = new Theme(AppTheme.Dark, "Night Mode");
    public static Theme Light = new Theme(AppTheme.Light, "Day Mode");
    public static Theme System = new Theme(AppTheme.Unspecified, "Follow System");

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
