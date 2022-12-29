using Microsoft.Maui.Controls.Shapes;
using XClaim.Mobile.Views.Profile;
using XClaim.Mobile.Views.Claim;
using XClaim.Common.Enums;
using XClaim.Common.Dtos;
using XClaim.Common.Extensions;

namespace XClaim.Mobile.Views.Home;

internal enum PageRow {
    First,
    Second,
    Third,
    Fourth
}

internal enum HeaderRows {
    First,
    Second
}

internal enum HeaderColumns {
    First,
    Second,
    Third
}

internal enum ListTitleColumn {
    First,
    Second
}

public class HomeView : BaseView<HomeViewModel> {
    public HomeView(HomeViewModel vm) : base(vm) {
        Build();
    }

    protected override void Build() {
        Content = new Grid() {
            RowDefinitions = Rows.Define(
                (PageRow.First, 85),
                (PageRow.Second, 115),
                (PageRow.Third, Star),
                (PageRow.Fourth, Auto)
            ),
            Children = {
                new Grid() {
                        ColumnDefinitions = Columns.Define(
                            (HeaderColumns.First, Auto),
                            (HeaderColumns.Second, Star),
                            (HeaderColumns.Third, Auto)
                        ),
                        Children = {
                            new AvatarView() {
                                    Content = new Image().Source(new FontImageSource() {
                                        FontFamily = "FASolid",
                                        Glyph = FA.Solid.User,
                                        Color = Colors.White
                                    }).Size(28)
                                }.Size(54, 54)
                                .CenterVertical()
                                .DynamicResource(BackgroundColorProperty, "Gray300")
                                .TapGesture(async () => await Shell.Current.GoToAsync(nameof(ProfileView)))
                                .Column(HeaderColumns.First),
                            new StackLayout {
                                    Children = {
                                        new Label().Text("Hello")
                                            .DynamicResource(Label.TextColorProperty, "Secondary"),
                                        new Label()
                                            .Bind(Label.TextProperty, "Status.FirstName")
                                            .Font(size: 20, family: "RobotoBold")
                                            .Margins(0, -5, 0, 0)
                                            .DynamicResource(Label.TextColorProperty, "Gray500")
                                    }
                                }.Margins(8, 16, 0, 0)
                                .Column(HeaderColumns.Second),
                            new Image().Source(new FontImageSource() {
                                    FontFamily = "FASolid",
                                    Glyph = FA.Solid.Bell
                                }.DynamicResource(FontImageSource.ColorProperty, "Primary"))
                                .Size(28)
                                .CenterVertical()
                                .TapGesture(async () =>
                                    await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(NotificationView)}"))
                                .Column(HeaderColumns.Third)
                        }
                    }
                    .Paddings(24, 8, 24, 8)
                    .Row(PageRow.First),
                new Border() {
                        Padding = 16,
                        StrokeThickness = 0F,
                        StrokeShape = new RoundRectangle {
                            CornerRadius = new CornerRadius(10)
                        },
                        Background = Gradients.AppGradient,
                        Shadow = new Shadow {
                            Offset = new Point(4, 8),
                            Opacity = 0.5F,
                            Radius = 5,
                            Brush = new LinearGradientBrush {
                                GradientStops = {
                                    new GradientStop {
                                        Offset = 0.1F,
                                        Color = Colors.Grey
                                    },
                                    new GradientStop {
                                        Offset = 1.0F,
                                        Color = Colors.LightGray
                                    }
                                }
                            }
                        },
                        Content = new StackLayout() {
                            Children = {
                                new Label()
                                    .Text("Pending Claims")
                                    .Font(size: 14)
                                    .TextColor(Colors.White)
                                    .Margins(0, 0, 0, 4),
                                new Label()
                                    .TextColor(Colors.White)
                                    .Font(size: 32, family: "RobotoBold")
                                    .Bind(Label.TextProperty, "Status.Balance",
                                        convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                            }
                        }
                    }
                    .Margins(24, 6, 24, 6)
                    .Row(PageRow.Second),
                    new Grid() {
                        RowDefinitions = Rows.Define(
                            (PageRow.First, Auto),
                            (PageRow.Second, Star)
                        ),
                        Children = {
                        new Grid() {
                            ColumnDefinitions = Columns.Define(
                                (ListTitleColumn.First, Star),
                                (ListTitleColumn.Second, Auto)
                            ),
                            Padding = 8,
                            Children = {
                                new Label()
                                    .Text("Recents")
                                    .Font(size: 16)
                                    .Column(ListTitleColumn.First)
                                    .DynamicResource(Label.TextColorProperty, "Gray300"),
                                new Label()
                                    .Text("See all")
                                    .Font(size: 16)
                                    .TapGesture(async () => await Shell.Current.GoToAsync($"//{nameof(ClaimView)}"))
                                    .Column(ListTitleColumn.Second)
                                    .DynamicResource(Label.TextColorProperty, "Primary")
                            }
                        }.Row(PageRow.First),
                        new RefreshView {
                                Content = new CollectionView() {
                                    SelectionMode = SelectionMode.None,
                                    EmptyView = "No recent event"
                                }
                                .Bind(ItemsView.ItemsSourceProperty, nameof(HomeViewModel.RecentItems))
                                .Bind(SelectableItemsView.SelectedItemProperty,
                                    nameof(HomeViewModel.SelectedRecentItem))
                                .ItemTemplate(new DataTemplate(() => new Grid {
                                    ColumnDefinitions = Columns.Define(
                                        (PageRow.First, Auto),
                                        (PageRow.Second, Star),
                                        (PageRow.Third, Auto)
                                    ),
                                    RowDefinitions = Rows.Define(
                                        (PageRow.First, Auto),
                                        (PageRow.Second, Auto),
                                        (PageRow.Third, 1)
                                    ),
                                    Children = {
                                        new Label { Padding = 1, Margin = 2, TextColor = Color.FromRgba("#7F7F7F") }
                                            .Font(size: 16)
                                            .Bind(Label.TextProperty, nameof(RecentActions.Name))
                                            .Row(PageRow.First)
                                            .Column(PageRow.First),
                                        new HorizontalStackLayout {
                                                Children = {
                                                    new Label { Padding = 1, Margin = 2 }
                                                        .Font(size: 11)
                                                        .Bind(Label.TextProperty, nameof(RecentActions.Category)),
                                                    new Label { Padding = 1, Margin = 2 }
                                                        .Font(size: 11)
                                                        .Text("."),
                                                    new Label { Padding = 1, Margin = 2 }
                                                        .Font(size: 11)
                                                        .Bind(Label.TextProperty, nameof(RecentActions.Time),
                                                            convert: (DateTime value) => value.TimeAgo())
                                                }
                                            }.Row(PageRow.Second)
                                            .Column(PageRow.First),
                                        new Label { TextColor = Colors.LightSeaGreen }
                                            .Font(size: 22, family: "RobotoMedium")
                                            .Bind(Label.TextProperty, nameof(RecentActions.Amount),
                                                convert: (decimal value) => "₦" + string.Format("{0:N0}", value))
                                            .MinWidth(105)
                                            .Row(PageRow.First)
                                            .RowSpan(2)
                                            .Column(PageRow.Third)
                                            .CenterVertical()
                                            .CenterHorizontal(),
                                        new BoxView()
                                            .DynamicResource(StyleProperty, "SeparatorLine")
                                            .Row(PageRow.Third)
                                            .ColumnSpan(3)
                                    }
                                }.Paddings(4, 2, 4, 4)))
                        }.Row(PageRow.Second)
                        .Bind(RefreshView.IsRefreshingProperty, nameof(HomeViewModel.IsRefreshing))
                        .Bind(RefreshView.CommandProperty, nameof(HomeViewModel.RefreshRecentsCommand))
                    }
                    }
                    .Margins(8, 16, 8, 8)
                    .Row(PageRow.Third),

                new Button().Text("New Request")
                    .DynamicResource(StyleProperty, "ButtonLargePrimary")
                    .CenterVertical()
                    .Margins(24, 16, 24, 24)
                    .BindCommand(nameof(HomeViewModel.ToClaimFormCommand))
                    .Row(PageRow.Fourth)
            }
        };
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        BindingContext.LoadDefaultsCommand.Execute(null);
    }
}

public partial class HomeViewModel : BaseViewModel {
    [ObservableProperty] private ObservableCollection<RecentActions> _recentItems;

    [ObservableProperty] private bool _isRefreshing;

    [ObservableProperty] private RecentActions _selectedRecentItem;

    [ObservableProperty] private bool _loading = true;

    [ObservableProperty] private UserProfile _status;

    [RelayCommand]
    private async Task LoadDefaults() {
        Loading = true;
        await Task.Delay(500);
        Status = new UserProfile("Saurav", "Argawal", UserPermission.Administrator, 0, 10000);
        RecentItems = new ObservableCollection<RecentActions> {
            new("Travel expense calabar", "Transport", 7000, DateTime.Now.AddHours(-4)),
            new("20 Litre Petrol", "Fuel", 1000, DateTime.Now.AddDays(-1)),
            new("Spectranet 4G max", "Internet", 30000, DateTime.Now.AddDays(-3))
        };
        Loading = false;
    }

    [RelayCommand]
    private async Task RefreshRecents() {
        IsRefreshing = true;
        await Task.Delay(1500);
        IsRefreshing = false;
    }

    [RelayCommand]
    private async void ToClaimForm() {
        await Shell.Current.GoToAsync($"///{nameof(HomeView)}/{nameof(ClaimFormView)}");
    }
}