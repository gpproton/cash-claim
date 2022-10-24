namespace XClaim.Mobile.Pages.Profile;

public class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Profile view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}