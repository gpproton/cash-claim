using XClaim.Mobile.Pages.Claim;
using XClaim.Mobile.Pages.Home;
using XClaim.Mobile.Pages.Payment;
using XClaim.Mobile.Pages.Profile;
using XClaim.Mobile.Pages.Review;
using XClaim.Mobile.Pages.Startup;

namespace XClaim.Mobile;

public class AppShell : Shell {
    public AppShell() {
        FlyoutBehavior = FlyoutBehavior.Disabled;
        BindingContext = new AppShellViewModel();

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(LoadingPage),
            ContentTemplate = new DataTemplate(typeof(LoadingPage))
        });

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(AuthPage),
            ContentTemplate = new DataTemplate(typeof(AuthPage))
        });

        var tabItems = new TabBar {
            Items = {
                new Tab {
                    Title = "Home",
                    Icon = Icons.Home,
                    Items = {
                        new ShellContent {
                            Route = nameof(HomePage),
                            ContentTemplate = new DataTemplate(typeof(HomePage))
                        }
                    }
                },
                new Tab {
                    Title = "Claims",
                    Icon = Icons.Claim,
                    Items = {
                        new ShellContent {
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
        };
        if (tabItems == null) throw new ArgumentNullException(nameof(tabItems));

        tabItems.Items.Add(new Tab {
            Title = "Review",
            Icon = Icons.Review,
            Items = {
                new ShellContent {
                    Route = nameof(ReviewPage),
                    ContentTemplate = new DataTemplate(typeof(ReviewPage))
                }
            }
        });

        Items.Add(tabItems);

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(NotificationPage),
            ContentTemplate = new DataTemplate(typeof(NotificationPage))
        });

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(ProfilePage),
            ContentTemplate = new DataTemplate(typeof(ProfilePage))
        });
    }
}

public partial class AppShellViewModel : BaseViewModel {
    [RelayCommand]
    private async void SignOut() { }
}
