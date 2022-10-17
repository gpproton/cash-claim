using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Review;

public class ReviewActionView : ContentPage
{
	public ReviewActionView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim review view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}