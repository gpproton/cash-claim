using MauiPopup.Views;
using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Home.Component;

public partial class HomeEventPop : BasePopupPage {
    [BindableProp(DefaultBindingMode = ((int)BindingMode.TwoWay))]
    private RecentActions _item;

    enum LevelSection {
        First,
        Second,
    }

    public HomeEventPop(RecentActions recents) {
        _item = recents;
        this.HorizontalOptions = LayoutOptions.Fill;
        this.VerticalOptions = LayoutOptions.End;
        Content = new VerticalStackLayout {
            Padding = 8,
            Spacing = 5,
            MinimumHeightRequest = 320,
            HorizontalOptions = LayoutOptions.Center,
            Children = {
                new Label().Text(Item.Name).Font(size: 18)
                .CenterHorizontal(),
                new HorizontalStackLayout {
                    new Label().Text(Item.Time.ToString("yyyy-MMM-dd"))
                    .Font(size: 12),
                    new Label().Text(".")
                    .Margins(4, 0, 4, 0)
                    .Font(size: 12),
                    new Label().Text(Item.Category)
                    .Font(size: 12),
                }.CenterHorizontal().Margins(0, 2, 0, 8),
                new Image().Source(new FontImageSource() {
                    FontFamily = "FARegular",
                    Glyph = FA.Regular.CircleCheck,
                    Color = Colors.LightSeaGreen
                }).CenterHorizontal().Size(72)
                .Margins(0, 16, 0, 16),
                new Label().Text("Completed")
                    .CenterHorizontal(),
                new Label().Text("₦" + string.Format("{0:N0}", Item.Amount))
                    .Font(size: 32, family: "RobotoMedium")
                    .CenterHorizontal()
            }
        };
    }
}
