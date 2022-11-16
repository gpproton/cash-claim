using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
using UraniumUI.Handlers;
using InputKit.Handlers;
using XClaim.Mobile.Views.Profile;
using XClaim.Mobile.Views.Review;
using XClaim.Mobile.Views.Startup;
using XClaim.Mobile.Views.Claim;
using XClaim.Mobile.Views.Home;
using XClaim.Mobile.Views.Payment;
using XClaim.Mobile.Services;

namespace XClaim.Mobile;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        .UseMauiCommunityToolkitMarkup()
        .UseUraniumUI()
        .ConfigureFonts(fonts => {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");
            fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
            fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
            fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
            fonts.AddFontAwesomeIconFonts();
        })
        .ConfigureMauiHandlers(handlers =>
        {
            handlers.AddUraniumUIHandlers();
        });

        RegisterServices(builder.Services);
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }

    private static void RegisterServices(IServiceCollection s) {
        s.AddTransient<AppShell>();
        s.AddTransient<AppShellViewModel>();
        s.AddSingleton<SettingsService>();
        // Startup views
        s.AddTransientWithShellRoute<LoadingView, LoadingViewModel>(nameof(LoadingView));
        s.AddTransientWithShellRoute<AuthView, AuthViewModel>(nameof(AuthView));
        s.AddTransientWithShellRoute<ConfigView, ConfigViewModel>($"{nameof(AuthView)}/{nameof(ConfigView)}");
        // Home views
        s.AddTransientWithShellRoute<HomeView, HomeViewModel>(nameof(HomeView));
        s.AddTransientWithShellRoute<NotificationView, NotificationViewModel>($"{nameof(HomeView)}/{nameof(NotificationView)}");
        // Profile views
        s.AddTransientWithShellRoute<ProfileView, ProfileViewModel>(nameof(ProfileView));
        // Claim views
        s.AddTransientWithShellRoute<ClaimView, ClaimViewModel>(nameof(ClaimView));
        s.AddTransientWithShellRoute<ClaimFormView, ClaimFormViewModel>($"{nameof(HomeView)}/{nameof(ClaimFormView)}");
        // Payment views
        s.AddTransientWithShellRoute<PaymentView, PaymentViewModel>(nameof(PaymentView));
        // Review views
        s.AddTransientWithShellRoute<ReviewView, ReviewViewModel>(nameof(ReviewView));
        
    }
}
