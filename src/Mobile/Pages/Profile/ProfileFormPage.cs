namespace XClaim.Mobile.Pages.Profile;

public class ProfileFormPage : BasePage
{
	public ProfileFormPage() => Content = new VerticalStackLayout
    {
        Children = {
                new Label { Text = "Profile form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
    };
}