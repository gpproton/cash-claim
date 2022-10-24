namespace XClaim.Mobile.Pages.Review;

public class ReviewPage : ContentPage
{
	public ReviewPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim pending view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}