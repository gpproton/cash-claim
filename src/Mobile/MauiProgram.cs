using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
using XClaim.Mobile.Pages;

namespace XClaim.Mobile;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() {
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
			{
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
        builder.Services.AddTransientWithShellRoute<WelcomePage, WelcomeViewModel>(nameof(WelcomePage));
        builder.Services.AddTransientWithShellRoute<AuthPage, AuthViewModel>(nameof(AuthPage));
        builder.Services.AddTransientWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
