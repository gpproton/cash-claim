using XClaim.Mobile.Pages;
using XClaim.Mobile.Pages.Claim;
using XClaim.Mobile.Pages.Home;
using XClaim.Mobile.Pages.Payment;
using XClaim.Mobile.Pages.Profile;

namespace XClaim.Mobile;

public class AppShell : Shell
{
	public AppShell() {
        FlyoutBehavior = FlyoutBehavior.Disabled;
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
                Icon = Icons.Home,
                Items = {
                        new ShellContent  {
                            Route = nameof(HomePage),
                            ContentTemplate = new DataTemplate(typeof(HomePage))
                        }
                 }
            },
            new Tab {
                Title = "Claims",
                Icon = Icons.Claim,
                Items = {
                        new ShellContent  {
                            Route = nameof(ClaimPage),
                            ContentTemplate = new DataTemplate(typeof(ClaimPage))
                        }
                 }
            },
            new Tab {
                Title = "Payments",
                Icon = Icons.Payment,
                Items = {
                        new ShellContent {
                            Route = nameof(PaymentPage),
                            ContentTemplate = new DataTemplate(typeof(PaymentPage))
                        }
                 }
            }
         }
        });
        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(ProfilePage),
            ContentTemplate = new DataTemplate(typeof(ProfilePage))
        });
    }
}