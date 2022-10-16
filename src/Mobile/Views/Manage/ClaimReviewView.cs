using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Manage;

public class ClaimReviewView : ContentPage
{
	public ClaimReviewView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim review view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}