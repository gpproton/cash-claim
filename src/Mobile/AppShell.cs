using XClaim.Mobile.Pages;
using XClaim.Mobile.Pages.Claim;
using XClaim.Mobile.Pages.Payment;

namespace XClaim.Mobile;

public class AppShell : Shell
{
	public AppShell() {
        FlyoutBehavior = FlyoutBehavior.Disabled;
        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(WelcomePage),
            ContentTemplate = new DataTemplate(typeof(WelcomePage))
        });
        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(AuthPage),
            ContentTemplate = new DataTemplate(typeof(AuthPage))
        });
        Items.Add(new TabBar {
            Items = {
            new Tab {
                Title = "Home",
                Icon = "icon_home.svg",
                Items = {
                        new ShellContent  {
                            Route = nameof(HomePage),
                            ContentTemplate = new DataTemplate(typeof(HomePage))
                        }
                 }
            },
            new Tab {
                Title = "Claims",
                Icon = "icon_claim.svg",
                Items = {
                        new ShellContent  {
                            Route = nameof(ClaimPage),
                            ContentTemplate = new DataTemplate(typeof(ClaimPage))
                        }
                 }
            },
            new Tab {
                Title = "Payments",
                Icon = "icon_payment.svg",
                Items = {
                        new ShellContent {
                            Route = nameof(PaymentPage),
                            ContentTemplate = new DataTemplate(typeof(PaymentPage))
                        }
                 }
            }
         }
        });
    }
}