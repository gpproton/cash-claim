namespace XClaim.Mobile.Pages.Review;

public class ReviewActionPage : ContentPage
{
	public ReviewActionPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim review view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}