using XClaim.Mobile.Templates;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Views;

public class WelcomeView : BaseView<WelcomeViewModel>
{
    enum PageRow { First, Second }
    public WelcomeView(WelcomeViewModel welcomeViewModel) : base(welcomeViewModel) {
        Background = Gradients.GetAppGradient();
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
                        .Source("welcome_vector.svg")
                        .CenterHorizontal()
                        .Row(PageRow.First),
                        new VerticalStackLayout() {
                            Children = {
                                new Button()
                                .Text("Get Started")
                                .DynamicResource(StyleProperty, "ButtonLargeLight")
                                .CenterVertical()
                                .BindCommand(nameof(WelcomeViewModel.NavigateToAuthCommand))
                            }
                        }
                        .Row(PageRow.Second)
                    }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
    }
}

public partial class WelcomeViewModel : BaseViewModel
{
    [RelayCommand]
    private async void NavigateToAuth() => await Shell.Current.GoToAsync($"//{nameof(AuthView)}");
}
