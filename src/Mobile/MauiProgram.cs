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
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddUraniumUIHandlers();
            }).ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFontAwesomeIconFonts();
            });
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransientWithShellRoute<HomeView, HomeViewModel>(nameof(HomeView));
        builder.Services.AddTransientWithShellRoute<DemoOneView, DemoOneViewModel>(nameof(DemoOneView));
#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
