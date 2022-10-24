namespace XClaim.Mobile;

public partial class App : Application
{
    public App(AppShell shell) {
		InitializeComponent();
		MainPage = shell;
        //Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
    }
}
