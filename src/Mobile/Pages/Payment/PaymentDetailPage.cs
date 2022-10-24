namespace XClaim.Mobile.Pages.Payment;

public class PaymentDetailPage : ContentPage
{
	public PaymentDetailPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Payment detail view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}