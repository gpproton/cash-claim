using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
using XClaim.Mobile.Pages;
using XClaim.Mobile.Pages.Claim;
using XClaim.Mobile.Pages.Home;
using XClaim.Mobile.Pages.Payment;
using XClaim.Mobile.Pages.Profile;
using XClaim.Mobile.Pages.Review;
using XClaim.Mobile.Pages.Startup;

namespace XClaim.Mobile;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        .UseMauiCommunityToolkitMarkup()
        .ConfigureFonts(fonts => {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");
            fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
            fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
            fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
            fonts.AddFontAwesomeIconFonts();
        });
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransientWithShellRoute<LoadingPage, LoadingViewModel>(nameof(LoadingPage));
        builder.Services.AddTransientWithShellRoute<AuthPage, AuthViewModel>(nameof(AuthPage));
        builder.Services.AddTransientWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
        builder.Services.AddTransientWithShellRoute<NotificationPage, NotificationViewModel>($"{nameof(HomePage)}/{nameof(NotificationPage)}");
        builder.Services.AddTransientWithShellRoute<ClaimPage, ClaimViewModel>(nameof(ClaimPage));
        builder.Services.AddTransientWithShellRoute<ClaimFormPage, ClaimFormViewModel>($"{nameof(HomePage)}/{nameof(ClaimFormPage)}");
        builder.Services.AddTransientWithShellRoute<PaymentPage, PaymentViewModel>(nameof(PaymentPage));
        builder.Services.AddTransientWithShellRoute<ReviewPage, ReviewViewModel>(nameof(ReviewPage));
        builder.Services.AddTransientWithShellRoute<ProfilePage, ProfileViewModel>(nameof(ProfilePage));
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
