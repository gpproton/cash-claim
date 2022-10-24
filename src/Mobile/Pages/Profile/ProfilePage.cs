using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Profile;

public class ProfilePage : BasePage <ProfileViewModel>
{
	public ProfilePage(ProfileViewModel profileVm) : base(profileVm) => Content = new VerticalStackLayout
    {
        Children = {
                new Label { Text = "Profile view!" }
                .TextCenterHorizontal()
                .TextCenterVertical()
            }
    };
}

public class ProfileViewModel : BaseViewModel { }
