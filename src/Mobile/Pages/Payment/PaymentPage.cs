using XClaim.Mobile.Views;

namespace XClaim.Mobile.Pages.Payment;

public class PaymentPage : BasePage<PaymentViewModel> {
    public PaymentPage(PaymentViewModel vm) : base(vm) => Build();

    private void Build() {
        Title = "Payments";
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Content = new VerticalStackLayout {
            Children = {
                new EmptyItemView().Margins(0, 56)
            }
        };
    }
}

public class PaymentViewModel : BaseViewModel { }
