using Microsoft.Maui.Platform;
using XClaim.Mobile.Handlers;

namespace XClaim.Mobile;

public partial class App : Application
{
    public App(AppShell shell) {
		InitializeComponent();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
        {
            if (view is CustomEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomTimePicker), (handler, view) =>
        {
            if (view is CustomTimePicker)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomDatePicker), (handler, view) =>
        {
            if (view is CustomDatePicker)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        MainPage = shell;
        //Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
    }
}
