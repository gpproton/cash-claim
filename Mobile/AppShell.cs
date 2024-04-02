using CashClaim.Mobile.Views.Profile;
using CashClaim.Mobile.Views.Review;
using CashClaim.Mobile.Views.Startup;
using CashClaim.Mobile.Views.Claim;
using CashClaim.Mobile.Views.Home;
using CashClaim.Mobile.Views.Payment;

namespace CashClaim.Mobile;

public class AppShell : Shell
{
    public AppShell(AppShellViewModel vm)
    {
        FlyoutBehavior = FlyoutBehavior.Disabled;
        BindingContext = vm;

        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(LoadingView),
            ContentTemplate = new DataTemplate(typeof(LoadingView))
        });

        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(AuthView),
            ContentTemplate = new DataTemplate(typeof(AuthView))
        });

        var tabItems = new TabBar
        {
            Items = {
                new Tab {
                    Title = "Home",
                    Icon = Icons.Home,
                    Items = {
                        new ShellContent {
                            Route = nameof(HomeView),
                            ContentTemplate = new DataTemplate(typeof(HomeView))
                        }
                    }
                },
                new Tab {
                    Title = "Claims",
                    Icon = Icons.Claim,
                    Items = {
                        new ShellContent {
                            Route = nameof(ClaimView),
                            ContentTemplate = new DataTemplate(typeof(ClaimView))
                        }
                    }
                },
                new Tab {
                    Title = "Payments",
                    Icon = Icons.Payment,
                    Items = {
                        new ShellContent {
                            Route = nameof(PaymentView),
                            ContentTemplate = new DataTemplate(typeof(PaymentView))
                        }
                    }
                }
            }
        };
        if (tabItems == null) throw new ArgumentNullException(nameof(tabItems));

        tabItems.Items.Add(new Tab
        {
            Title = "Review",
            Icon = Icons.Review,
            Items = {
                new ShellContent {
                    Route = nameof(ReviewView),
                    ContentTemplate = new DataTemplate(typeof(ReviewView))
                }
            }
        });

        Items.Add(tabItems);

        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = $"{nameof(HomeView)}/{nameof(NotificationView)}",
            ContentTemplate = new DataTemplate(typeof(NotificationView))
        });

        Items.Add(new ShellContent
        {
            FlyoutItemIsVisible = false,
            Route = nameof(ProfileView),
            ContentTemplate = new DataTemplate(typeof(ProfileView))
        });
    }

    private void MobileShell() { }

    private void DesktopShell() { }
}

public partial class AppShellViewModel : BaseViewModel
{
    [RelayCommand]
    private void SignOut() { }
}