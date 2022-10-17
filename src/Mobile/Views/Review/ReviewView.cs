using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Review;

public class ReviewView : ContentPage
{
	public ReviewView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim pending view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}