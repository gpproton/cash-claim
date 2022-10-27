namespace XClaim.Mobile.Pages.Payment;

public class PaymentPage : BasePage<PaymentViewModel>
{
    public PaymentPage(PaymentViewModel vm) : base(vm) => Build();

    void Build()
    {
        Title = "Payments";
        ToolbarItems.Add(new ToolbarItem
        {
            IconImageSource = new FontImageSource
            {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { Text = "Payment view!" }.TextCenterHorizontal().TextCenterVertical()
            }
        };
    }
}

public class PaymentViewModel : BaseViewModel { }
