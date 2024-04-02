namespace CashClaim.Mobile.Views.Profile;

internal class AlertsView : BaseView<AlertsViewModel> {
    public AlertsView(AlertsViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Title = "Notification Setting";
        Content = new VerticalStackLayout {
            new Label().Text("Alerts!!")
        };
    }
}

public partial class AlertsViewModel : BaseViewModel { }