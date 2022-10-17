using XClaim.Mobile.Views.Claim;
using XClaim.Mobile.Views.Payment;

namespace XClaim.Mobile;

public partial class App : Application
{
	public App(AppShell shell) {
		InitializeComponent();
		MainPage = shell;

        Routing.RegisterRoute(nameof(ClaimView), typeof(ClaimView));
        Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));
    }
}
