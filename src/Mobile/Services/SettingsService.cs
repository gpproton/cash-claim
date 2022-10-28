﻿namespace XClaim.Mobile.Services;

[INotifyPropertyChanged]
public partial class SettingsService {
    private static SettingsService _instance;
    public static SettingsService Instance => _instance ??= new SettingsService();

    SettingsService() => Theme = Theme.System;

    [ObservableProperty]
    private Theme _theme;
}
