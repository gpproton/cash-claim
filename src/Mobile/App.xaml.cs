using Microsoft.Maui.Platform;
using System.ComponentModel;
using XClaim.Mobile.Services;

namespace XClaim.Mobile;

public partial class App : Application {
    public App(AppShell shell) {
        InitializeComponent();
        BuildNativeControls();

        MainPage = shell;
        SetTheme();
        SettingsService.Instance.PropertyChanged += OnSettingsPropertyChanged;
        //Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
    }

    void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(SettingsService.Theme)) SetTheme();
    }

    void SetTheme() => UserAppTheme = SettingsService.Instance?.Theme != null
                                      ? SettingsService.Instance.Theme.AppTheme
                                      : AppTheme.Unspecified;

    void BuildNativeControls() {
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
}
