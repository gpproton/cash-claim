namespace XClaim.Mobile.Services;

[INotifyPropertyChanged]
public partial class SettingsService {
    static SettingsService _instance;
    public static SettingsService Instance => _instance ??= new SettingsService();

    SettingsService() => Theme = Theme.System;

    [ObservableProperty]
    Theme _theme;
}
