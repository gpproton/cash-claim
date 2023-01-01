using MauiPopup.Views;
using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Payment.Component;

public partial class PaymentPop : BasePopupPage {
    private enum SectionLevel {
        First,
        Second,
        Third,
        Fourth
    }

    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private PaymentDto _item;

    public PaymentPop(PaymentDto item) {
        _item = item;
        HorizontalOptions = LayoutOptions.Fill;
        VerticalOptions = LayoutOptions.End;
        BackgroundColor = Colors.Transparent;
        Content = new Grid {
            Padding = 8,
            MinimumHeightRequest = 320,
            HorizontalOptions = LayoutOptions.Center,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Auto),
                (SectionLevel.Third, Star),
                (SectionLevel.Fourth, Auto)
            ),
            Children = {
                new Label().Text(Item.Name).Font(size: 18)
                    .CenterHorizontal().Row(SectionLevel.First),
                new HorizontalStackLayout {
                        new Label().Text(Item.Time.ToString("yyyy-MMM-dd"))
                            .Font(size: 12),
                        new Label().Text(".")
                            .Margins(4, 0, 4, 0)
                            .Font(size: 12),
                        new Label().Text(Item.Category)
                            .Font(size: 12)
                    }.CenterHorizontal().Margins(0, 2, 0, 8)
                    .Row(SectionLevel.Second),

                new Image().Source(new FontImageSource() {
                        FontFamily = "FARegular",
                        Glyph = FA.Regular.Clock,
                        Color = Colors.DodgerBlue
                    }).CenterHorizontal().Size(72)
                    .Margins(0, 16, 0, 16)
                    .Row(SectionLevel.Third),

                new VerticalStackLayout {
                    Children = {
                        new Label().Text("Pending")
                            .CenterHorizontal(),
                        new Label().Text(AppConst.Naira + string.Format("{0:N0}", Item.Amount))
                            .Font(size: 32, family: "RobotoMedium")
                            .CenterHorizontal()
                    }
                }.Row(SectionLevel.Fourth)
            }
        };
    }
}