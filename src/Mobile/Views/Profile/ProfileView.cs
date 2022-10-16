using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class ProfileView : ContentPage
{
	public ProfileView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Profile view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}