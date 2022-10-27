using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Startup;

public class LoadingPage : BasePage<LoadingViewModel>
{
    public LoadingPage(LoadingViewModel vm): base(vm) => Build();
    void Build()
    {
        Background = Gradients.AppGradient;
        Content = new VerticalStackLayout {
            HorizontalOptions = LayoutOptions.Fill,
            Children = {
                new ActivityIndicator { IsRunning = true, Color = Colors.White }
                .CenterHorizontal()
                .CenterVertical()
                .Margins(0, 96, 0, 0)
                .Size(72, 72)
            }
        };
    }
}

public class LoadingViewModel : BaseViewModel {

    public LoadingViewModel() => VerifyAuth();
    private async void VerifyAuth()
    {
        await Task.Delay(1000);
        await Shell.Current.GoToAsync($"//{nameof(AuthPage)}");
    }
}