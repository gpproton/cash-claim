using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Startup;

public class LoadingPage : BasePage<LoadingViewModel> {
    public LoadingPage(LoadingViewModel vm) : base(vm) => Build();
    void Build() {
        Background = Gradients.AppGradient;
        var layout = new ColumnLayout();
        var activity = new ActivityIndicator {
            IsRunning = true,
            Color = Colors.White
        }
        .CenterHorizontal()
        .CenterVertical()
        .Size(72, 72);
        layout.Add(activity);
        layout.SetFill(activity, true);
        Content = layout;
    }
}

public class LoadingViewModel : BaseViewModel {

    public LoadingViewModel() => VerifyAuth();
    async void VerifyAuth() {
        await Task.Delay(2500);
        await Shell.Current.GoToAsync($"//{nameof(AuthPage)}");
    }
}
