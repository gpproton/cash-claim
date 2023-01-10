namespace XClaim.Mobile.Views.Startup;

public class LoadingView : BaseView<LoadingViewModel> {
    public LoadingView(LoadingViewModel vm) : base(vm) => Build();

    protected override void Build() {
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
    public LoadingViewModel() {
        VerifyAuth();
    }

    private async void VerifyAuth() {
        await Task.Delay(1500);
        await Shell.Current.GoToAsync($"//{nameof(AuthView)}");
    }
}