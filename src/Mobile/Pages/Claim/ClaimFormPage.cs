namespace XClaim.Mobile.Pages.Claim;

public class ClaimFormPage : ContentPage
{
	public ClaimFormPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Claim form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}