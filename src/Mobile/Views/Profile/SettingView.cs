using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class SettingView : ContentPage
{
	public SettingView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Settings view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}