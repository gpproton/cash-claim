using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Claim;

public class ClaimDetailView : ContentPage
{
	public ClaimDetailView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim detail view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}