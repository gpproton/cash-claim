namespace XClaim.Mobile.Views.Profile;

public class LogView : BaseView<LogViewModel> {
    public LogView(LogViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Title = "Account History";
        Content = new VerticalStackLayout {
            new Label().Text("History!!")
        };
    }
}

public partial class LogViewModel : BaseViewModel { }