using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views;

public class HomeView : ContentPage
{
	public HomeView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				 new Label { Text = "Home view!" }.TextCenterHorizontal().TextCenterVertical()
			}
		};
	}
}
