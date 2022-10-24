namespace XClaim.Mobile.Pages.Review;

public class ReviewPage : BasePage
{
	public ReviewPage() => Content = new VerticalStackLayout
    {
        Children = {
                new Label { Text = "Claim pending view!" }.TextCenterHorizontal().TextCenterVertical()
            }
    };
}