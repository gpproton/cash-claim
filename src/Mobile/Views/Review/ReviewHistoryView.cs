using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Review;

public class ReviewHistoryView : ContentPage
{
	public ReviewHistoryView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim history view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}