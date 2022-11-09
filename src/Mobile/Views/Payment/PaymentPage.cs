namespace XClaim.Mobile.Views.Payment;

public class PaymentPage : BaseView<PaymentViewModel> {
    public PaymentPage(PaymentViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Sliders
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Build();
    }

    protected override void Build() {
        Title = "Payments";
        Content = new VerticalStackLayout {
            Children = {
                new EmptyItemView().Margins(0, 56)
            }
        };
    }
}

public class PaymentViewModel : BaseViewModel { }
