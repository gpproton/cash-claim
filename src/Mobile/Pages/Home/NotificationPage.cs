using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Home;

public class NotificationPage : BasePage<NotificationViewModel> {
    public NotificationPage(NotificationViewModel vm) : base(vm) => Build();

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
