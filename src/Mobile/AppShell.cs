using XClaim.Mobile.Views;
using XClaim.Mobile.Views.Claim;
using XClaim.Mobile.Views.Payment;

namespace XClaim.Mobile;

public class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        Routing.RegisterRoute(nameof(ClaimView), typeof(ClaimView));
        Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));

        Items.Add(new TabBar {
            Items = {
            new Tab {
                Title = "Home",
                Icon = "icon_home.svg",
                Items = {
                        new ShellContent
                        {
                            Route = nameof(HomeView),
                            ContentTemplate = new DataTemplate(typeof(HomeView))
                        }
                 }
            },
            new Tab {
                Title = "Claims",
                Icon = "icon_claim.svg",
                Items = {
                        new ShellContent
                        {
                            Route = nameof(ClaimView),
                            ContentTemplate = new DataTemplate(typeof(ClaimView))
                        }
                 }
            },
            new Tab {
                Title = "Payments",
                Icon = "icon_payment.svg",
                Items = {
                        new ShellContent
                        {
                            Route = nameof(PaymentView),
                            ContentTemplate = new DataTemplate(typeof(PaymentView))
                        }
                 }
            }
         }
        });
    }
}