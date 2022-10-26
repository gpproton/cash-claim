using Microsoft.Maui.Controls.Shapes;

namespace XClaim.Mobile.Templates;

public partial class RangeFilterToolbar : Grid
{
    static Page CurrentPage => Application.Current?.MainPage ?? throw new NullReferenceException();

#pragma warning disable IDE0051 // Remove unused private members rule
    [AutoBindable]
    private readonly string _search;

    [AutoBindable]
    private readonly bool _showSearch;

    [AutoBindable(DefaultValue = "DateTime.Now.AddDays(-7)")]
    private readonly DateTime _startDate;

    [AutoBindable(DefaultValue = "DateTime.Now")]
    private readonly DateTime _endDate;
#pragma warning restore IDE0051 // Restore unused private members rule
    enum FrameColumn { First, Second, Third }
    public RangeFilterToolbar() => Build();

    void Build() {
        Margin = 8;
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
                            .DynamicResource(Label.TextColorProperty, "Secondary")
                            .Bind(Label.TextProperty, nameof(StartDate),
                                source: this,
                                convert: (DateTime time) => time.ToDateOnly().ToString("yyyy-MMM-dd").ToUpper()
                             )
                            .Column(FrameColumn.First),
                            new Rectangle()
                            .DynamicResource(BackgroundColorProperty, "Secondary")
                            .Size(12, 4)
                            .Center()
                            .Column(FrameColumn.Second),
                            new Label()
                            .Bind(Label.TextProperty,
                                nameof(EndDate),
                                source: this,
                                convert: (DateTime time) => time.ToDateOnly().ToString("yyyy-MMM-dd").ToUpper()
                            )
                            .DynamicResource(Label.TextColorProperty, "Secondary")
                            .Column(FrameColumn.Third)
                        }
                    }.Column(FrameColumn.First)
                }
            }
        }
        .DynamicResource(StyleProperty, "FieldControl")
        .Bind(IsVisibleProperty, nameof(ShowSearch), source: this, convert: (bool value) => !value)
        .TapGesture(async () => 
        await PopupExtensions.ShowPopupAsync<Popup>(CurrentPage,
                new Popup () {
                    VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Start,
                    Color = Colors.Transparent,
                    Content = new Border {
                        BackgroundColor = Colors.White,
                        MinimumHeightRequest = 120,
                        MinimumWidthRequest = 320,
                        StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) },
                        Content = new StackLayout {
                            Children = {
                                new Label().Text("Select Range")
                                .DynamicResource(Label.TextColorProperty, "Primary")
                                .Font(size: 22, family: "RobotoRegular")
                                .CenterHorizontal().Margins(0, 4, 0, 4),
                                new CustomDatePicker { BackgroundColor = Colors.Transparent, Format = "yyyy-MMMM-dd" }
                                .FillHorizontal()
                                .Bind(nameof(StartDate), source: this)
                                .DynamicResource(CustomDatePicker.TextColorProperty, "Primary"),
                                new CustomDatePicker { BackgroundColor = Colors.Transparent, Format = "yyyy-MMMM-dd" }
                                .FillHorizontal()
                                .Margins(0, 8, 0, 0)
                                .Bind(nameof(EndDate), source: this)
                                .DynamicResource(CustomDatePicker.TextColorProperty, "Primary")
                            }
                        }
                    }.Padding(16).FillHorizontal()
                }
            )
        ));

        Children.Add(new Grid {
            Children = {
                new Border().DynamicResource(StyleProperty, "FieldControl"),
                new CustomEntry()
                .Placeholder("Search")
                .Bind(CustomEntry.TextProperty, nameof(Search), source: this)
                .DynamicResource(StyleProperty, "CustomEntry")
            }
        }
        .Bind(IsVisibleProperty, nameof(ShowSearch), source: this));

        Children.Add(new Button {
            CornerRadius = 6,
            ImageSource = new FontImageSource() {
                FontFamily = "FASolid",
                Color = Colors.White,
                Size = 18,
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
