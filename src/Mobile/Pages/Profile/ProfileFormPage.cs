namespace XClaim.Mobile.Pages.Profile;

public class ProfileFormPage : ContentPage
{
	public ProfileFormPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Profile form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}