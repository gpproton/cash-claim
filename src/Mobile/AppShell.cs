using XClaim.Mobile.Views.Profile;
using XClaim.Mobile.Views.Review;
using XClaim.Mobile.Views.Startup;
using XClaim.Mobile.Views.Claim;
using XClaim.Mobile.Views.Home;
using XClaim.Mobile.Views.Payment;

namespace XClaim.Mobile;

public class AppShell : Shell {
    public AppShell(AppShellViewModel vm) {
        FlyoutBehavior = FlyoutBehavior.Disabled;
        BindingContext = vm;

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(LoadingView),
            ContentTemplate = new DataTemplate(typeof(LoadingView))
        });

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(AuthView),
            ContentTemplate = new DataTemplate(typeof(AuthView))
        });

        var tabItems = new TabBar {
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

        tabItems.Items.Add(new Tab {
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

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(NotificationView),
            ContentTemplate = new DataTemplate(typeof(NotificationView))
        });

        Items.Add(new ShellContent {
            FlyoutItemIsVisible = false,
            Route = nameof(ProfileView),
            ContentTemplate = new DataTemplate(typeof(ProfileView))
        });
    }
}

public partial class AppShellViewModel : BaseViewModel {
    [RelayCommand]
    private void SignOut() { }
}
