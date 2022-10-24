namespace XClaim.Mobile.Pages.Claim;

public class ClaimDetailPage : ContentPage
{
	public ClaimDetailPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim detail view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}