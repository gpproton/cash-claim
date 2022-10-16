using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Claim;

public class ClaimFormView : ContentPage
{
	public ClaimFormView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}