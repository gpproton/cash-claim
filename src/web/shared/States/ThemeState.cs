using MudBlazor;

namespace XClaim.Web.Shared.States;

public class ThemeState : RootState {
    public bool IsLightMode { get; private set; } = true;

    public MudTheme CurrentTheme { get; private set; } = new MudTheme();

    public void ToggleTheme() {
        IsLightMode = !IsLightMode;
        CurrentTheme = IsLightMode ? new MudTheme() : GenerateDarkTheme();
        NotifyStateChanged();
    }

    public void SetLightMode(bool value) {
        IsLightMode = value;
        CurrentTheme = IsLightMode ? new MudTheme() : GenerateDarkTheme();
        NotifyStateChanged();
    }

    private static MudTheme GenerateDarkTheme() => new MudTheme {
            Palette = new Palette {
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                TextPrimary = "#ffffffb3",
                TextSecondary = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "#ffffffb3",
                DrawerBackground = "#27272f",
                DrawerText = "#ffffffb3",
                DrawerIcon = "#ffffffb3"
            }
        };
}