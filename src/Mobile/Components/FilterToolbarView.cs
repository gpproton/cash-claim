using Microsoft.Maui.Controls.Shapes;
using XClaim.Common.Extensions;

namespace XClaim.Mobile.Components;

public partial class FilterToolbarView : Grid {
    private static Page CurrentPage => Application.Current?.MainPage ?? throw new NullReferenceException();

#pragma warning disable IDE0051
#pragma warning disable CS0169
    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private string _search = string.Empty;

    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private bool _showSearch = false;

    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private DateTime _startDate = DateTime.Now.AddDays(-7);

    [BindableProp(DefaultBindingMode = (int)BindingMode.TwoWay)]
    private DateTime _endDate = DateTime.Now;

    private enum FrameColumn {
        First,
        Second,
        Third
    }

    public FilterToolbarView() {
        Build();
    }

    private void Build() {
        Margin = new Thickness { Top = 4, Left = 0, Right = 0, Bottom = 0 };
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
                                        .Margins(4, 0, 4, 0)
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
            }.Style(SharedStyle.BoxFormField)
            .Bind(IsVisibleProperty, nameof(ShowSearch), source: this, convert: (bool value) => !value)
            .TapGesture(async () => await MauiPopup.PopupAction.DisplayPopup(new DateRangePop()
                .Bind(DateRangePop.StartDateProperty, nameof(StartDate), source: this)
                .Bind(DateRangePop.EndDateProperty, nameof(EndDate), source: this))
            ));

        Children.Add(new Grid {
                Children = {
                    new Border().Style(SharedStyle.BoxFormField),
                    new TextField { Keyboard = Keyboard.Text, BorderColor = Colors.Transparent }
                    .Bind(TextField.TextProperty, nameof(Search), source: this)
                }
            }.Bind(IsVisibleProperty, nameof(ShowSearch), source: this));
    }
}