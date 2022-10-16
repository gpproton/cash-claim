using CommunityToolkit.Maui.Markup;

namespace XClaim.Mobile.Views.Payment;

public class PaymentView : ContentPage
{
    public PaymentView()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Payment view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}