using Microsoft.Maui.Controls.Shapes;

namespace XClaim.Mobile.Views;

public partial class FilterToolbarView : Grid {
    private static Page CurrentPage => Application.Current?.MainPage ?? throw new NullReferenceException();

#pragma warning disable IDE0051
#pragma warning disable CS0169
    [AutoBindable]
    private readonly string _search;

    [AutoBindable]
    private readonly bool _showSearch;

    [AutoBindable(DefaultValue = "DateTime.Now.AddDays(-7)")]
    private readonly DateTime _startDate;

    [AutoBindable(DefaultValue = "DateTime.Now")]
    private readonly DateTime _endDate;

    private enum FrameColumn { First, Second, Third }
    public FilterToolbarView() => Build();

    private void Build() {
        Margin = new Thickness { Top = 4, Left = 8, Right = 8, Bottom = 0 };
        ColumnDefinitions = Columns.Define(
            (FrameColumn.First, Star),
            (FrameColumn.Second, Auto)
        );

        Children.Add(new Border {
            Content = new Grid {
                ColumnDefinitions = Columns.Define(
                    (FrameColumn.First, Star),
                    (FrameColumn.Second, Auto)
                ),
                Children = {
                    new Grid {
                        ColumnDefinitions = Columns.Define(
                            (FrameColumn.First, Auto),
                            (FrameColumn.Second, Star),
                            (FrameColumn.Third, Auto)
                        ),
                        Children = {
                            new Label()
                            .DynamicResource(Label.TextColorProperty, "Primary")
                            .Bind(Label.TextProperty, nameof(StartDate),
                                source: this,
                                convert: (DateTime time) => time.ToDateOnly().ToString("dd MMM yyyy")
                            ).CenterVertical()
                            .Column(FrameColumn.First),
                            new Rectangle()
                            .DynamicResource(BackgroundColorProperty, "Primary")
                            .Size(12, 4)
                            .Center()
                            .Column(FrameColumn.Second),
                            new Label()
                            .Bind(Label.TextProperty,
                                nameof(EndDate),
                                source: this,
                                convert: (DateTime time) => time.ToDateOnly().ToString("dd MMM yyyy")
                            ).CenterVertical()
                            .DynamicResource(Label.TextColorProperty, "Primary")
                            .Column(FrameColumn.Third)
                        }
                    }.CenterVertical()
                    .Column(FrameColumn.First)
                }
            }
        }
        .DynamicResource(StyleProperty, "FieldControl")
        .Bind(IsVisibleProperty, nameof(ShowSearch), source: this, convert: (bool value) => !value)
        .TapGesture(async () =>
        await CurrentPage.ShowPopupAsync(new Popup {
                VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Start,
                Color = Colors.Transparent,
                Content = new Border {
                    BackgroundColor = Colors.White,
                    MinimumHeightRequest = 120,
                    MinimumWidthRequest = 320,
                    StrokeShape = new RoundRectangle {
                        CornerRadius = new CornerRadius(10)
                    },
                    Content = new StackLayout {
                        Children = {
                            new Label().Text("Select Range")
                            .DynamicResource(Label.TextColorProperty, "Primary")
                            .Font(size: 22, family: "RobotoRegular")
                            .CenterHorizontal().Margins(0, 4, 0, 4),
                            new CustomDatePicker {
                                BackgroundColor = Colors.Transparent,
                                Format = "yyyy-MMMM-dd"
                            }
                            .FillHorizontal()
                            .Bind(nameof(StartDate), source: this)
                            .DynamicResource(DatePicker.TextColorProperty, "Primary"),
                            new CustomDatePicker {
                                BackgroundColor = Colors.Transparent,
                                Format = "yyyy-MMMM-dd"
                            }
                            .FillHorizontal()
                            .Margins(0, 8, 0, 0)
                            .Bind(nameof(EndDate), source: this)
                            .DynamicResource(DatePicker.TextColorProperty, "Primary")
                        }
                    }
                }.Padding(16).FillHorizontal()
            }
        )
        ));

        Children.Add(new Grid {
            Children = {
                new Border().DynamicResource(StyleProperty, "FieldControl"),
                new SearchBar { Placeholder = "Search.." }
                .Bind(SearchBar.TextProperty, nameof(Search), source: this)
                .DynamicResource(StyleProperty, "SearchEntry")
            }
        }
        .Bind(IsVisibleProperty, nameof(ShowSearch), source: this));

        Children.Add(new Button {
            CornerRadius = 6,
            ImageSource = new FontImageSource() {
                FontFamily = "FASolid",
                Color = Colors.White,
                Size = 18
            }
            .Bind(
                FontImageSource.GlyphProperty,
                nameof(ShowSearch),
                source: this,
                convert: (bool value) => value ? FA.Solid.MagnifyingGlass : FA.Solid.Sliders
            )
        }
        .Height(46)
        .DynamicResource(BackgroundColorProperty, "Primary")
        .Paddings(16, 0, 16, 0)
        .Margins(4, 0, 0, 0)
        .Invoke(l => l.Clicked += (sender, obj) => ShowSearch = !ShowSearch)
        .Column(FrameColumn.Second));
    }
}
