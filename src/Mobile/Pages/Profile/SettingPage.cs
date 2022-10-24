namespace XClaim.Mobile.Pages.Profile;

public class SettingPage : ContentPage
{
	public SettingPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Settings view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}