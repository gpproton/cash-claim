namespace XClaim.Mobile.Pages.Profile;

public class ProfilePage : BasePage<ProfileViewModel> {
    public ProfilePage(ProfileViewModel profileVm) : base(profileVm) => Build();

    protected override void Build() {
        Title = "Profile";
        Content = new VerticalStackLayout {
            Children = {
                new Label {
                    Text = "Profile view!"
                }
                .TextCenterHorizontal()
                .TextCenterVertical()
            }
        };
    }
}

public class ProfileViewModel : BaseViewModel { }
