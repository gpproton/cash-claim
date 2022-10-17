using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class PasswordView : ContentPage
{
	public PasswordView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Password reset view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}