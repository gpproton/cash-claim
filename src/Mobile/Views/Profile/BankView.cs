using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class BankView : ContentPage
{
	public BankView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Bank view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}