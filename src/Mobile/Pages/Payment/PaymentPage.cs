namespace XClaim.Mobile.Pages.Payment;

public class PaymentPage : ContentPage
{
    public PaymentPage()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Payment view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}