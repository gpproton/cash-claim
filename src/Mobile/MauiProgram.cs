using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;
using XClaim.Mobile.Views;

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
        builder.Services.AddTransientWithShellRoute<WelcomeView, WelcomeViewModel>(nameof(WelcomeView));
        builder.Services.AddTransientWithShellRoute<AuthView, AuthViewModel>(nameof(AuthView));
        builder.Services.AddTransientWithShellRoute<HomeView, HomeViewModel>(nameof(HomeView));

        // Demo
        builder.Services.AddTransientWithShellRoute<DemoLinkView, DemoLinkViewModel>(nameof(DemoLinkView));
        builder.Services.AddTransientWithShellRoute<DemoOneView, DemoOneViewModel>(nameof(DemoOneView));
#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
