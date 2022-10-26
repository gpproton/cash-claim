using XClaim.Mobile.ViewModel;

namespace XClaim.Mobile.Pages.Payment;

public class PaymentPage : BasePage<PaymentViewModel>
{
    public PaymentPage(PaymentViewModel paymentVm) : base(paymentVm) => Build();

    void Build()
    {
        Title = "Payments";
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Payment view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public class PaymentViewModel : BaseViewModel { }
