namespace XClaim.Mobile.Pages.Profile;

public class BankFormPage : ContentPage
{
	public BankFormPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Bank form view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}