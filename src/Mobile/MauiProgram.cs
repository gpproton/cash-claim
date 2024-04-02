using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
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
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFontAwesomeIconFonts();
            })
            .ConfigureMauiHandlers(handlers => { handlers.AddUraniumUIHandlers(); });
        builder.Services.AddSingleton<HttpsClientHandlerService>()
        .AddSingleton<HttpClient>(provider => {
            var handler = provider.GetService<HttpsClientHandlerService>();
            if (handler != null) return new HttpClient();
            else return new HttpClient(handler.GetPlatformMessageHandler());
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
        // Startup section
        s.AddTransientWithShellRoute<LoadingView, LoadingViewModel>(nameof(LoadingView));
        s.AddTransientWithShellRoute<AuthView, AuthViewModel>(nameof(AuthView));
        s.AddTransientWithShellRoute<ConfigView, ConfigViewModel>($"{nameof(AuthView)}/{nameof(ConfigView)}");
        // Home views
        s.AddScopedWithShellRoute<HomeView, HomeViewModel>(nameof(HomeView));
        // Home relateds
        s.AddTransientWithShellRoute<ClaimFormView, ClaimFormViewModel>($"{nameof(HomeView)}/{nameof(ClaimFormView)}");
        s.AddTransientWithShellRoute<NotificationView, NotificationViewModel>(
            $"{nameof(HomeView)}/{nameof(NotificationView)}");
        // Profile section
        s.AddTransientWithShellRoute<ProfileView, ProfileViewModel>(nameof(ProfileView));
        s.AddTransientWithShellRoute<BankView, BankViewModel>($"{nameof(ProfileView)}/{nameof(BankView)}");
        s.AddTransientWithShellRoute<AlertsView, AlertsViewModel>($"{nameof(ProfileView)}/{nameof(AlertsView)}");
        s.AddTransientWithShellRoute<LogView, LogViewModel>($"{nameof(ProfileView)}/{nameof(LogView)}");
        s.AddTransientWithShellRoute<SettingView, SettingViewModel>($"{nameof(ProfileView)}/{nameof(SettingView)}");
        s.AddTransientWithShellRoute<ThemeView, ThemeViewModel>($"{nameof(ProfileView)}/{nameof(ThemeView)}");
        s.AddTransientWithShellRoute<HelpView, HelpViewModel>($"{nameof(ProfileView)}/{nameof(HelpView)}");
        // Claim views
        s.AddTransientWithShellRoute<ClaimView, ClaimViewModel>(nameof(ClaimView));
        s.AddTransientWithShellRoute<ClaimDetailView, ClaimDetailViewModel>(
            $"{nameof(ClaimView)}/{nameof(ClaimDetailView)}");
        // Payment views
        s.AddTransientWithShellRoute<PaymentView, PaymentViewModel>(nameof(PaymentView));
        // Review views
        s.AddTransientWithShellRoute<ReviewView, ReviewViewModel>(nameof(ReviewView));
        s.AddTransientWithShellRoute<ReviewActionView, ReviewActionViewModel>(
            $"{nameof(ReviewView)}/{nameof(ReviewActionView)}");
    }
}