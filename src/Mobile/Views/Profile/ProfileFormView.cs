using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class ProfileFormView : ContentPage
{
	public ProfileFormView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Profile form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}