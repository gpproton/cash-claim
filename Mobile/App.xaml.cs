﻿using System.ComponentModel;
using Microsoft.Maui.Platform;
using CashClaim.Mobile.Services;

namespace CashClaim.Mobile;

public partial class App : Application {
    public App(AppShell shell) {
        InitializeComponent();
        BuildNativeControls();

        MainPage = shell;
        SetTheme();
        SettingsService.Instance.PropertyChanged += OnSettingsPropertyChanged;
        // Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
    }

    private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(SettingsService.Theme)) SetTheme();
    }

    private void SetTheme() {
        UserAppTheme = SettingsService.Instance?.Theme != null
            ? SettingsService.Instance.Theme.AppTheme
            : AppTheme.Unspecified;
    }

    private void BuildNativeControls() {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) => {
            if (view is CustomEntry) {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });
    }

    protected override Window CreateWindow(IActivationState activationState) {
        var window = base.CreateWindow(activationState);
        const int defaultWidth = 800;
        const int defaultHeight = 600;

        window.MinimumHeight = defaultHeight;
        window.MaximumHeight = defaultHeight;
        window.MinimumWidth = defaultWidth;
        window.MaximumWidth = defaultWidth;

        return window;
    }
}