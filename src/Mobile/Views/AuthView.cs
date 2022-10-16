using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views;

public class AuthView : ContentPage
{
	public AuthView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Authentication view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}