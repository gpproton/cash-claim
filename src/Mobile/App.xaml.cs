using XClaim.Mobile.Pages.Claim;
using XClaim.Mobile.Pages.Payment;

namespace XClaim.Mobile;

public partial class App : Application
{
    public App(AppShell shell) {
		InitializeComponent();
		MainPage = shell;

        Routing.RegisterRoute(nameof(ClaimPage), typeof(ClaimPage));
        Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
    }
}
