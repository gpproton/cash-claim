using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
using XClaim.Mobile.Views.Profile;
using XClaim.Mobile.Views.Review;
using XClaim.Mobile.Views.Startup;
using XClaim.Mobile.Views.Claim;
using XClaim.Mobile.Views.Home;
using XClaim.Mobile.Views.Payment;

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
        builder.Services.AddTransientWithShellRoute<LoadingView, LoadingViewModel>(nameof(LoadingView));
        builder.Services.AddTransientWithShellRoute<AuthView, AuthViewModel>(nameof(AuthView));
        builder.Services.AddTransientWithShellRoute<ConfigView, ConfigViewModel>($"{nameof(AuthView)}/{nameof(ConfigView)}");
        builder.Services.AddTransientWithShellRoute<HomeView, HomeViewModel>(nameof(HomeView));
        builder.Services.AddTransientWithShellRoute<NotificationView, NotificationViewModel>($"{nameof(HomeView)}/{nameof(NotificationView)}");
        builder.Services.AddTransientWithShellRoute<ClaimView, ClaimViewModel>(nameof(ClaimView));
        builder.Services.AddTransientWithShellRoute<ClaimFormView, ClaimFormViewModel>($"{nameof(HomeView)}/{nameof(ClaimFormView)}");
        builder.Services.AddTransientWithShellRoute<PaymentView, PaymentViewModel>(nameof(PaymentView));
        builder.Services.AddTransientWithShellRoute<ReviewView, ReviewViewModel>(nameof(ReviewView));
        builder.Services.AddTransientWithShellRoute<ProfileView, ProfileViewModel>(nameof(ProfileView));
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
