using XClaim.Mobile.Pages.Home;
using XClaim.Mobile.Views;
using static Microsoft.Maui.Controls.Button;

namespace XClaim.Mobile.Pages.Startup;

public class AuthPage : BasePage<AuthViewModel> {
    enum PageRow { First, Second }
    public AuthPage(AuthViewModel authViewModel) : base(authViewModel) {
        Background = Gradients.AppGradient;
        Content = new Grid {
            RowDefinitions = Rows.Define(
                (PageRow.First, Stars(2)),
                (PageRow.Second, Star)
            ),
            Children = {
                new Image() {
                    HeightRequest = 320,
                    MaximumHeightRequest = 768,
                    Aspect = Aspect.AspectFill
                }
                .Source(Icons.AuthBanner)
                .CenterHorizontal()
                .Row(PageRow.First),
                new VerticalStackLayout() {
                    Children = {
                        new Button() {
                            ImageSource = Icons.Google,
                            ContentLayout = new ButtonContentLayout(ButtonContentLayout.ImagePosition.Left, 32)
                        }
                        .Text("Sign in with Google")
                        .DynamicResource(StyleProperty, "ButtonAuth")
                        .CenterVertical()
                        .BindCommand(nameof(AuthViewModel.NavigateToHomeCommand))
                    }
                }
                .Paddings(16, 16, 16, 16)
                .Row(PageRow.Second)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
    }
}

public partial class AuthViewModel : BaseViewModel {
    [RelayCommand]
    async void NavigateToHome() => await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
}
