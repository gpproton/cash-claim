using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Payment;

public class PaymentDetailView : ContentPage
{
	public PaymentDetailView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
                new Label { Text = "Payment detail view!" }.TextCenterHorizontal().TextCenterVertical()
            }
		};
	}
}