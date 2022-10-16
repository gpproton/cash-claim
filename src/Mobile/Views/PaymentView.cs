using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views;

public class PaymentView : ContentPage
{
	public PaymentView() {
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { Text = "Payment view!" }.TextCenterHorizontal().TextCenterVertical()
			}
		};
	}
}