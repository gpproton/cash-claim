using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Profile;

public class BankFormView : ContentPage
{
	public BankFormView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Bank form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}