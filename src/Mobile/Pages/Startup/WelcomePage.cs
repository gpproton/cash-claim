using XClaim.Mobile.ViewModel;
using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Startup;

public class WelcomePage : BasePage<WelcomeViewModel>
{
    enum PageRow { First, Second }
    public WelcomePage(WelcomeViewModel welcomeViewModel) : base(welcomeViewModel)
    {
        Background = Gradients.AppGradient;
        Content = new Grid()
        {
            RowDefinitions = Rows.Define(
                        (PageRow.First, Star),
                        (PageRow.Second, 140)
                    ),
            Children = {
                        new Image() {
                            HeightRequest = 320,
                            MaximumHeightRequest = 768,
                            Aspect = Aspect.AspectFill
                        }
                        .Source(Icons.WelcomeBanner)
                        .CenterHorizontal()
                        .Row(PageRow.First),
                        new VerticalStackLayout() {
                            Children = {
                                new Button()
                                .Text("Get Started")
                                .DynamicResource(StyleProperty, "ButtonLargeLight")
                                .CenterVertical()
                                .Invoke (l => l.Clicked += async (sender, args) =>
                                    await Shell.Current.GoToAsync($"//{nameof(AuthPage)}")
                                )
                            }
                        }
                        .Row(PageRow.Second)
                    }
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

public partial class WelcomeViewModel : BaseViewModel { }
