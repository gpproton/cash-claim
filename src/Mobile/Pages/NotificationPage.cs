using Android.OS;
using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages;

public class NotificationPage : BasePage<NotificationViewModel>
{
    public NotificationPage(NotificationViewModel notificationVm) : base(notificationVm) => Build();

    void Build()
    {
        Title = "Notifications";
        Content = new VerticalStackLayout
        {
            Children = {
                new Label().Text("Notification!!").CenterHorizontal()
            }
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
    }
}

public class NotificationViewModel : BaseViewModel { }
