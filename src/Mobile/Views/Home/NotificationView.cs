namespace XClaim.Mobile.Views.Home;

public class NotificationView : BaseView<NotificationViewModel> {
    public NotificationView(NotificationViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Title = "Notifications";
        Content = new VerticalStackLayout {
            Children = {
                new Label().Text("Notification!!").CenterHorizontal()
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
    }
}

public class NotificationViewModel : BaseViewModel { }