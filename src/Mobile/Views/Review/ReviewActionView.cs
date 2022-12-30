using XClaim.Common.Dtos;

namespace XClaim.Mobile.Views.Review;

public class ReviewActionView : BaseView<ReviewActionViewModel> {
    private enum SectionLevel {
        First,
        Second,
        Third,
        Fourth
    }

    public ReviewActionView(ReviewActionViewModel vm) : base(vm) {
        ToolbarItems.Add(new ToolbarItem {
            IconImageSource = new FontImageSource {
                FontFamily = "FASolid",
                Glyph = FA.Solid.Download,
                Size = 24
            }.DynamicResource(FontImageSource.ColorProperty, "Primary")
        });
        Build();
    }

    protected override void Build() {
        this.Bind(TitleProperty, "Item.Name");
        Content = new Grid {
            Padding = 16,
            RowDefinitions = Rows.Define(
                (SectionLevel.First, Auto),
                (SectionLevel.Second, Star),
                (SectionLevel.Third, Auto),
                (SectionLevel.Fourth, Auto)
            ),
            Children = {
                new VerticalStackLayout {
                        Spacing = 2,
                        Children = {
                            new Label().Bind(Label.TextProperty, "Item.Name")
                                .Font(size: 18)
                                .CenterHorizontal(),
                            new Label().Text("Firstname Lastname")
                                .Font(size: 14, family: "RobotoMedium")
                                .CenterHorizontal()
                        }
                    }.CenterHorizontal()
                    .Row(SectionLevel.First),

                new Image().Source("money_payments.svg")
                    .CenterHorizontal().MinHeight(256)
                    .Margins(24, 0, 24, 0)
                    .Row(SectionLevel.Second),

                new VerticalStackLayout {
                        Spacing = 15,
                        Children = {
                            new VerticalStackLayout {
                                    new HorizontalStackLayout {
                                        new Label { Padding = 1, Margin = 2 }
                                            .Font(size: 12)
                                            .Bind(Label.TextProperty, "Item.Time",
                                                convert: (DateTime value) => value.ToString("yy-MMM-dd HH:mm")),
                                        new Label { Padding = 1, Margin = 2 }
                                            .Font(size: 12)
                                            .Text("."),
                                        new Label { Padding = 1, Margin = 2 }
                                            .Font(size: 12)
                                            .Bind(Label.TextProperty, "Item.Category")
                                    },
                                    new Label().Bind(Label.TextProperty, "Item.Notes")
                                        .Font(size: 14)
                                        .CenterHorizontal()
                                }.Margins(0, 0, 0, 24)
                                .CenterHorizontal(),
                            new Label().Bind(Label.TextProperty, "Item.Amount",
                                    convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                                .Font(size: 32, family: "RobotoMedium")
                                .CenterHorizontal()
                        }
                    }.Margins(0, 0, 0, 24)
                    .Row(SectionLevel.Third),

                new VerticalStackLayout {
                        new Button { HeightRequest = 48 }
                            .Text("Confirm")
                            .FillHorizontal()
                            .BackgroundColor(Colors.ForestGreen),
                        new Button { HeightRequest = 48, TextColor = Colors.Red }
                            .Text("Reject")
                            .FillHorizontal()
                            .BackgroundColor(Colors.Transparent)
                    }
                    .FillHorizontal()
                    .Row(SectionLevel.Fourth)
            }
        };
    }
}

[QueryProperty(nameof(Item), "Item")]
public partial class ReviewActionViewModel : BaseViewModel {
    [ObservableProperty] private ReviewDto _item;
}