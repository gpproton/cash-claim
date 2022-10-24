using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages;

public class NotificationPage : BasePage<NotificationViewModel>
{
	public NotificationPage(NotificationViewModel notificationVm) : base(notificationVm) => Content = new VerticalStackLayout
    {
        Children = {
                new Label().Text("Notification!!").CenterHorizontal()
            }
    };
}

public class NotificationViewModel : BaseViewModel { }
